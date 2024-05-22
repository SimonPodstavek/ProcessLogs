using System;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using ProcessLogs.logs;


namespace ProcessLogs.utilities
{
    internal static class LogHandler
    {


        private static byte[][] GetEnclosedSequences(byte[] logBytes, byte[] logXMLOpeningSequence, byte[] logXMLClosingSequence)
        {

            List<byte[]> XMLByteSequences = new List<byte[]>();
            int currentPos = 0;
            while (currentPos < logBytes.Length - logXMLOpeningSequence.Length)
            {
                int startingPos = FindSequence(currentPos, logBytes, logXMLOpeningSequence);
                if (startingPos == -1)
                {
                    break;
                }

                int endingPos = FindSequence(currentPos, logBytes, logXMLClosingSequence);
                if (endingPos == -1)
                {
                    break;
                }

                int sequenceLength = endingPos + logXMLClosingSequence.Length - startingPos;
                byte[] XMLByteSequence = new byte[sequenceLength];

                Array.Copy(logBytes, startingPos, XMLByteSequence, 0, sequenceLength);
                XMLByteSequences.Add(XMLByteSequence);
                currentPos = endingPos + logXMLClosingSequence.Length;
            }
            return XMLByteSequences.ToArray();
        }

        private static int FindSequence(int startingPos, byte[] haystack, byte[] needle)
        {
            bool found = false;
            for (int offset = startingPos; offset < haystack.Length; offset++)
            {
                found = true;
                for (int i = 0; i < needle.Length; i++)
                {
                    if (haystack[offset + i] != needle[i])
                    {
                        found = false;
                        break;
                    }

                }
                if (found)
                {
                    return offset;
                }
            }
            return -1;
        }




        //This function takes a byte array and character to be replaced. Optionally it accepts replacement byte.
        //If the replacement a byte is empty, the occurence of old char will be removed from the byte array.
        internal static byte[] FindAndReplaceByte(byte[] byteArray, byte oldChar, byte? newChar = null)
        {
            byte[] resultAray;
            int originalLength = byteArray.Count();

            if (newChar == null)
            {
                return byteArray.Where(x => x != oldChar).ToArray();
            }

            resultAray = new byte[originalLength];
            foreach ((int index, byte value) in byteArray.Enumerate())
            {
                if (value == oldChar)
                {
                    resultAray[index] = (byte)newChar;
                }
            }
            return resultAray;
        }

        static byte[] HexStringToByteArray(string hex)
        {
            try { 
                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < hex.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
                return bytes;
            }catch(Exception exc)
            {
                MessageBox.Show("Chyba 110: Pri konverzii Hash z reťazca sa vyskytla chyba.", "Chyba konverzie", MessageBoxButtons.OK, MessageBoxIcon.Error);
                byte[] errBytes = new byte[20];
                for (int i = 0; i < 20; i++)
                {
                    errBytes[i] = 0xFF;
                }
                return errBytes;
            }
        }


        private static bool FindXMLHash(Logs logObject)
        {
            Logs.record[] logRecords = logObject.logRecords;

            foreach (Logs.record logRecord in logRecords)
            {

                string hashString;
                byte[] byteXMLContent = logRecord.byteXMLSequence;
                byte[][] byteXMLHashes = GetEnclosedSequences(byteXMLContent,
                    Configuration.ByteSequences.logXMLHashOpeningSequence,
                    Configuration.ByteSequences.logXMLHashClosingSequence);

                if (byteXMLHashes.Length != 1)
                {
                    MessageBox.Show("Chyba 108: Pri čítaní hash integrity XML súboru" + logObject.filePath + "sa vyskytla chyba.", "Chyba čítania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //Convert hash(hex) from byte to UTF-8 string.
                hashString = Encoding.UTF8.GetString(byteXMLHashes[0]);
                hashString = hashString.Substring(6, 40);

                //Split string and turn it into hash.
                logRecord.XMLHash = HexStringToByteArray(hashString);
            }

            return true;
        }

        private static bool VerifyXMLSequencesIntegrity(Logs logObject)
        {
            Logs.record[] logRecords = logObject.logRecords;

            foreach ((int index, Logs.record logRecord) in logRecords.Enumerate())
            {

                byte[][] dataBytesSequence = GetEnclosedSequences(logRecord.byteXMLSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);


                //Return an error if there are multiple sequences of the same file 
                if (dataBytesSequence.Length != 1)
                {
                    MessageBox.Show("Chyba 107: V súbore " + logObject.fileName + " v XML log-u č. " + index + " sa nenachádza element <Data> alebo sa v ňom nachádza viac ako raz", "Nesprávna štruktúra XML dát", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }

                //Select the only available byte sequence
                logRecord.computedHash = IntegrityVerification.ComputeSha1Hash(dataBytesSequence[0]);

                if (!logRecord.computedHash.SequenceEqual(logRecord.XMLHash))
                {
                    Console.WriteLine("Nezhoda SHA1 hash pri " + logObject.filePath) ;
                    //return false;
                }
            }
            return true;
        }

        internal static bool ProcessLog(Logs logObject)
        {
            if (logObject == null)
                return false;

            //Get byte content of a log
            try
            {
                logObject.LogContent = File.ReadAllBytes(logObject.filePath);
            }
            catch (Exception exc)
            {
                MessageBox.Show("Chyba 108: Pri čítaní bytov súboru" + logObject.filePath + " sa vyskytla chyba\r\n" + exc + ".", "Chyba čítania", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            //Get byte sequences of a log
            logObject.XMLSequences = GetEnclosedSequences(logObject.LogContent,
                Configuration.ByteSequences.logXMLOpeningSequence,
                Configuration.ByteSequences.logXMLClosingSequence);

            //If there aren't any XML sections in a log, raise an error
            if (logObject.XMLSequences.Count() == 0)
            {
                DialogResult continueProcessing = MessageBox.Show("Chyba 103: Log" + logObject.filePath + " neobsahuje ani jednu XML sekciu. Preskočiť záznam a pokračovať?", "Chýbajúci záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (continueProcessing == DialogResult.No)
                {
                    return false;
                }
            }


            List<Logs.record> tmpLogRecords = new List<Logs.record> ();
            //Create log record object and give it corresponding XML content
            foreach (byte[] byteXMLSequence in logObject.XMLSequences)
            {
                Logs.record currentRecord = new Logs.record();
                currentRecord.byteXMLSequence = byteXMLSequence;
                tmpLogRecords.Add(currentRecord);
            }

            //Convert tmp List to array and release it from memory
            logObject.logRecords = tmpLogRecords.ToArray();
            tmpLogRecords = null;



            //Get contents of <Hash> tag for every record
            if(!FindXMLHash(logObject))
                return false;

            //Verify hash located in logs with computed SHA1 hash
            if (!VerifyXMLSequencesIntegrity(logObject)) 
                return false;

            return true;

        }
    }
}
