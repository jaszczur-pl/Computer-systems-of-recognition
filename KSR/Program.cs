using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KSR
{
    class Program
    {
        static void Main(string[] args) {

            string[] allFilePaths = Directory.GetFiles("C:\\Users\\maciej.jaszczura\\OneDrive - Accenture\\!Sync\\Downloads\\reuters21578.tar\\", "*sgm");
            FileHandler fileHandler = new FileHandler();
            SgmlToXmlParser sgmlParser = new SgmlToXmlParser();
            XmlDocument xmlDoc = sgmlParser.GetXmlDoc(allFilePaths[0]);
            allFilePaths = allFilePaths.Where(x => x != allFilePaths[0]).ToArray();

            foreach (string singleFilePath in allFilePaths) {
                fileHandler.writeParentNode(singleFilePath);
                XmlDocument tempXmlDoc = sgmlParser.GetXmlDoc(singleFilePath);

                foreach (XmlNode tempChildNode in tempXmlDoc.DocumentElement.ChildNodes) {
                    XmlNode newNode = xmlDoc.ImportNode(tempChildNode, true);
                    xmlDoc.DocumentElement.AppendChild(newNode);
                }
            }

            XmlNode xmlRoot = xmlDoc.DocumentElement;
            int xmlNodes = xmlRoot.ChildNodes.Count;
            XmlNode firstXmlNode = xmlRoot.ChildNodes.Item(1999);

            Console.WriteLine(firstXmlNode.OuterXml);
            Console.WriteLine(xmlNodes);
        }
    }
}
