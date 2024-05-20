using System;
using System.Collections.Generic;
using System.Deployment.Internal;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProcessLogs.utilities
{
    internal  static class ProcessLog
    {
        private static List<byte[]> GetXMLByteSectionsFromLogBytes(byte[] logBytes, byte[] logXMLOpeningSequence, byte[] logXMLClosingSequence)
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
                    if (i > 2)
                    {
                        Console.WriteLine(1);
                    }

                }
                if (found)
                {
                    return offset;
                }
            }
            return -1;
        }


        private static bool VerifyIntegrity()
        {
            bool isValid = false;

            return isValid;
        }

        internal static List<byte[]> ProcessLogBytes(byte[] logBytes)
        {
            List<byte[]> XMLByteSequences = GetXMLByteSectionsFromLogBytes(logBytes, 
                Configuration.ByteSequences.logXMLOpeningSequence, 
                Configuration.ByteSequences.logXMLClosingSequence);

            
            
            return XMLByteSequences;


        }
    }
}
