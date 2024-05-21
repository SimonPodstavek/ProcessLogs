using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ProcessLogs.logs;


namespace ProcessLogs.utilities
{
    internal  static class ProcessLog
    {
        private static List<byte[]> GetEnclosedSequences(byte[] logBytes, byte[] logXMLOpeningSequence, byte[] logXMLClosingSequence)
        {

            List<byte[]> XMLByteSequences= new List<byte[]>();
            int currentPos = 0;
            while(currentPos < logBytes.Length -  logXMLOpeningSequence.Length)
            {
                int startingPos = FindSequence(currentPos, logBytes, logXMLOpeningSequence);
                if(startingPos == -1)
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
            return XMLByteSequences;
        }

        private static int FindSequence(int startingPos, byte[] haystack, byte[] needle)
        {
            bool found = false;
            for(int offset = startingPos; offset < haystack.Length;offset++)
            {
                found = true;
                for(int i = 0; i < needle.Length; i++)
                {
                    if (haystack[offset+i] != needle[i])
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


        private static bool VerifyXMLSequencesIntegrity(Logs logObject)
        {

            bool isValid = true;
            foreach((int index, byte[] XMLByteSequence) in logObject.XMLByteSequences.Enumerate())
            {
                List<byte[]> dataBytesSequence = new List<byte[]>();

                dataBytesSequence = GetEnclosedSequences(XMLByteSequence, Configuration.ByteSequences.logXMLDataOpeningSequence, Configuration.ByteSequences.logXMLDataClosingSequence);


                //Return an error if there are multiple sequences of the same file 
                if(dataBytesSequence.Count != 0)
                {
                    MessageBox.Show("Chyba 107: V súbore " + logObject.fileName + " v XML log-u č. " + index + " sa nenachádza element <Data> alebo sa v ňom nachádza viac ako raz" ,"Nesprávna štruktúra XML dát", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    isValid = false;
                }

                //Select the only available byte sequence
                byte[] dataBytes = dataBytesSequence[0];

                IntegrityVerification.ComputeSha1Hash(dataBytes);

            }
                return isValid;
        }

        internal static void ProcessLogBytes(Logs logObject)
        {

            logObject.XMLByteSequences = GetEnclosedSequences(logObject.byteLogContent, 
                Configuration.ByteSequences.logXMLOpeningSequence, 
                Configuration.ByteSequences.logXMLClosingSequence);

            VerifyXMLSequencesIntegrity(logObject);




            return;
            //return XMLByteSequences;


        }
    }
}
