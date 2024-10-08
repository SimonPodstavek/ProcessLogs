﻿using ProcessLogs.logs;
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


        private interface IVerifyStructure
        {
            void ValidateXMLStructure(byte[] byteXMLContent);
        }

        internal class VerifyByteXMLStructure : IVerifyStructure
        {
            public void ValidateXMLStructure(byte[] byteXMLContent)
            {
                using (MemoryStream memoryStream = new MemoryStream(byteXMLContent))
                {
                    //Create an XmlReader from the MemoryStream
                    //if there is an error it's callers responsibility to handle it
                    using (XmlReader xmlReader = XmlReader.Create(memoryStream))
                    {
                        while (xmlReader.Read())
                        {
                        }
                    }
                }
            }
        }

        private class VerifyAggregateByteXMLStructure : IVerifyStructure
        {
            public void ValidateXMLStructure(byte[] byteXMLContent)
            {
                using (MemoryStream memoryStream = new MemoryStream(byteXMLContent))
                {
                    //Create an XmlReader from the MemoryStream
                    //if there is an error it's callers responsibility to handle it
                    using (XmlReader xmlReader = XmlReader.Create(memoryStream))
                    {

                        //Verify that the file contains XML declaration by going to the next element until the declaration is found
                        bool containsDeclaration = false;
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.XmlDeclaration)
                            {
                                containsDeclaration = true;
                                break;
                            }
                        }


                        if (!containsDeclaration) throw new AggregateFileIncorrectStructure("Chyba 115: Agregátny súbor neobsahuje deklaráciu");

                        //Locate the first element and verify that it's AGGREGATEXML
                        xmlReader.MoveToContent();

                        // Check if the first element is <AGGREGATEXML>
                        if (xmlReader.NodeType != XmlNodeType.Element || xmlReader.Name != "AGGREGATEXML")
                        {
                            throw new AggregateFileIncorrectStructure();
                        }

                        // Navigate through the XML to find the last element
                        string lastElementName = null;
                        while (xmlReader.Read())
                        {
                            if (xmlReader.NodeType == XmlNodeType.EndElement)
                            {
                                lastElementName = xmlReader.Name;
                            }

                            if(xmlReader.NodeType == XmlNodeType.Element && xmlReader.Name == "Hash" && Configuration.Settings.verifyAggregateXMLStructureOnLoad)
                            {
                                string recordHash = xmlReader.ReadElementContentAsString();
                                recordHash = LogClass.FormatHash(recordHash);

                                Configuration.instanceDependent.registeredHashes.Add(recordHash);
                            }


                            
                        }

                        // Check if the last element is <AGGREGATEXML> if verifying aggregate file
                        if (lastElementName != "AGGREGATEXML")
                        {
                            throw new AggregateFileIncorrectStructure();
                        }
                    }
                }
            }
        }



        internal class XMLValidator
        {
            internal static bool ValidateXMLStructure(string logXMLPath, string errorMessage = "Štruktúra XML súboru nie je platná", bool checkAggregateFileStructure = false)
            {
                //Verify that the user has read permission for the file
                if (!AccessControlUtils.VerifyFileReadPermission(logXMLPath))
                {
                    return false;
                }

                //Read bytes and load them into memory
                byte[] byteXMLContent = File.ReadAllBytes(logXMLPath);
                
                //ValidateXMLStructure structure
                bool response = ValidationMediator(byteXMLContent, errorMessage, checkAggregateFileStructure);


                return response;
            }


            internal static bool ValidateXMLStructure(byte[] byteXMLContent, string errorMessage = "Štruktúra XML súboru nie je platná", bool checkAggregateFileStructure = false)
            {
                return ValidationMediator(byteXMLContent,errorMessage, checkAggregateFileStructure);
            }

            private static bool ValidationMediator(byte[] byteXMLContent, string errorMessage, bool checkAggregateFileStructure)
            {
                IVerifyStructure verificator;

                try
                {
                    
                    if (checkAggregateFileStructure)
                    {
                        verificator = new VerifyAggregateByteXMLStructure();
                    }
                    else
                    {
                        verificator = new VerifyByteXMLStructure();
                    }

                    verificator.ValidateXMLStructure(byteXMLContent);
                    return true;

                }
                catch (XmlException ex)
                {
                    if (Configuration.Settings.isVerbose || checkAggregateFileStructure)
                    {
                        Program.LogEvent(errorMessage);
                        Program.LogEvent($"Chyba: {ex.Message}");
                        Program.LogEvent($"Riadok: {ex.LineNumber}");
                        Program.LogEvent($"Pozícia na riadku: {ex.LinePosition}");

                    }
                    return false;
                }
                catch (AggregateFileIncorrectStructure ex)
                {
                    Program.LogEvent("Chyba 115: Agregátny XML súbor musí obsahovať deklaráciu XML (<?xml version=\"1.0\" encoding=\"UTF-8\"?>).");
                    Program.LogEvent("Agregátny XML súbor musí obsahovať element (<AGGREGATEXML>).");
                    Program.LogEvent("Štruktúra pre platný agregátny XML súbor (<?xml version=\"1.0\" encoding=\"UTF-8\"?><AGGREGATEXML></AGGREGATEXML>).");
                    Program.LogEvent($"Stack trace: {ex.StackTrace}");
                    return false;
                }
            }
        }


    }
}  
