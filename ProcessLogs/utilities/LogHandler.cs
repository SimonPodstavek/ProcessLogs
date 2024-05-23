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

        internal static byte[][] GetEnclosedSequences(byte[] logBytes, byte[] logXMLOpeningSequence, byte[] logXMLClosingSequence)
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

        //This function converts hex frmo string to hex in bytes. E.g. string "0DFA3D" would be converted to bytes {0D,FA,3D}
        internal static byte[] HexStringToByteArray(string hex)
        {
            try { 
                byte[] bytes = new byte[hex.Length / 2];
                for (int i = 0; i < hex.Length; i += 2)
                {
                    bytes[i / 2] = Convert.ToByte(hex.Substring(i, 2), 16);
                }
                return bytes;
            }catch(Exception ex)
            {
                throw new Exception("Chyba 110: Pri konverzii Hash z reťazca sa vyskytla chyba.", ex);
            }
        }



        internal static void ProcessLog(Logs logObject)
        {
            if (logObject == null)
                return;

            //Get byte content of a log
            try
            {
                logObject.LogContent = File.ReadAllBytes(logObject.filePath);
            }
            catch (Exception ex)
            {
                throw new Exception("Chyba 108: Pri čítaní bajtov sa vyskytla chyba.", ex);
            }

            //Get byte sequences of a log
            logObject.XMLSequences = GetEnclosedSequences(logObject.LogContent,
                Configuration.ByteSequences.logXMLOpeningSequence,
                Configuration.ByteSequences.logXMLClosingSequence);

            //If there aren't any XML sections in a log, notify the user.
            //Allow the user to bypass the error and skip the file.
            if (logObject.XMLSequences.Count() == 0)
            {
                DialogResult continueProcessing = MessageBox.Show("Chyba 103: Log" + logObject.filePath + " neobsahuje ani jednu XML sekciu. Preskočiť záznam a pokračovať?", "Chýbajúci záznam", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (continueProcessing == DialogResult.No)
                {
                    throw new Exception("Chyba 103: Log neobsahuje XML sekcie.");
                }
            }


            List<Logs.record> tmpLogRecords = new List<Logs.record> ();
            //Create log record object and give it corresponding XML content

            foreach ((int index, byte[] byteXMLSequence) in logObject.XMLSequences.Enumerate())
            {
                try
                {
                    Logs.record currentRecord = new Logs.record();
                    currentRecord.byteXMLSequence = byteXMLSequence;
                    tmpLogRecords.Add(currentRecord);
                    int nu = 0;
                    Console.Write(0 / nu);
                }
                catch (Exception ex)
                {
                    throw new Exception($"Chyba 108: Pri pridávaní {index+1}. XML sekcie v súbore sa vyskytla chyba.", ex);
                }
            }


            //Convert tmp List to array and release it from memory
            logObject.logRecords = tmpLogRecords.ToArray();
            tmpLogRecords = null;



            //Get contents of <Hash> tag for every record
            if (!Logs.FindXMLHash(logObject))
                throw new Exception("Pri vyhľadávaní hash v XML sekcii nastala neočakávaná chyba.");

            //Verify hash located in logs with computed SHA1 hash for every record
            if (!Logs.VerifyXMLSequencesIntegrity(logObject))
                throw new Exception("Pri overovaní hash nastala neočakávaná chyba.");

            return;

        }
    }
}
