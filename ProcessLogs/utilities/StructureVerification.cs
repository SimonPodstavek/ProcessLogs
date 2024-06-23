using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProcessLogs.utilities
{
    internal class StructureVerification
    {
        private static void VerifyXMLStructure(byte[] byteXMLContent)
        {
            using (MemoryStream memoryStream = new MemoryStream(byteXMLContent))
            {
                try
                {
                    // Create an XmlReader from the MemoryStream
                    using (XmlReader xmlReader = XmlReader.Create(memoryStream))
                    {
                        // Read and process the XML
                        while (xmlReader.Read())
                        {
                        }
                    }
                }
                catch (XmlException ex)
                {
                    throw new Exception($"Štruktúra XML súboru je poškodená!", ex);
                }
            }


        }
        internal static void ReadAndVerifyXMLStructure(string aggregateXMLPath)
        {
            byte[] aggregateXML = File.ReadAllBytes(aggregateXMLPath);
            StructureVerification.VerifyXMLStructure(aggregateXML);
            Array.Clear(aggregateXML, 0, aggregateXML.Length);
            aggregateXML = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

        }
    }

}   
