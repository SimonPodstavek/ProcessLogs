using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        internal static void VerifyXMLStructure(byte[] byteXMLContent)
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
        private static void ReadAndVerifyXMLStructure(string XMLFilePath)
        {
            byte[] aggregateXML = File.ReadAllBytes(XMLFilePath);
            StructureVerification.VerifyXMLStructure(aggregateXML);
            Array.Clear(aggregateXML, 0, aggregateXML.Length);
            aggregateXML = null;

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();

        }

        internal static bool HasCorrectXMLStructure(string logXMLPath, string errorMessage)
        {
            try
            {
                ReadAndVerifyXMLStructure(logXMLPath);
                return true;
            }
            catch (XmlException ex)
            {
                Program.LogEvent(errorMessage);
                Program.LogEvent($"Cesta súboru: {logXMLPath}");
                Program.LogEvent($"Chyba: {ex.Message}");
                Program.LogEvent($"Riadok: {ex.LineNumber}");
                Program.LogEvent($"Pozícia na riadku: {ex.LinePosition}");
                return false;
            }
        }

    }

}   
