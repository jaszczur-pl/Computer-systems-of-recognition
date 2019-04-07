using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using System.IO;

namespace KSR
{
    class XmlHandler
    {
        public XmlDocument GetMergedXmlDocuments() {

            FileHandler fileHandler = new FileHandler();
            string[] allFilePaths = fileHandler.GetAllSgmFilePaths();

            SgmlToXmlParser sgmlParser = new SgmlToXmlParser();
            XmlDocument xmlDoc = sgmlParser.GetXmlDoc(allFilePaths[0]);
            XmlNodeList xmlNodeList;

            //omit first file path in array for further processing
            allFilePaths = allFilePaths.Where(x => x != allFilePaths[0]).ToArray();

            foreach (string singleFilePath in allFilePaths) {
                fileHandler.WriteParentNode(singleFilePath);
                XmlDocument tempXmlDoc = sgmlParser.GetXmlDoc(singleFilePath);

                foreach (XmlNode tempChildNode in tempXmlDoc.DocumentElement.ChildNodes) {
                    XmlNode newNode = xmlDoc.ImportNode(tempChildNode, true);
                    xmlDoc.DocumentElement.AppendChild(newNode);
                }
            }

            return xmlDoc;
        }

        public XmlNodeList ConvertXmlDocToXmlList(XmlDocument xmlDoc) {
            return xmlDoc.DocumentElement.ChildNodes;
        }

        public XmlNodeList GetAllCorrectNodes(XmlDocument xmlDoc) {
            
            XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("REUTERS[TEXT[count(BODY)>0]]");

            return nodeList;
        }
    }
}
