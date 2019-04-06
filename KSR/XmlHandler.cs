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
        ////Test method - need to be removed before final version
        //public void Test() {
        //    string text = " ABC Abc aBC abc cos abcde";
        //    string expression = @"\s(?i)(abc)\s";

        //    string newText = Regex.Replace(text, expression, " ");
        //    string newText2 = Regex.Replace(newText, expression, " ");
        //    Console.WriteLine(newText2);
        //}

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


        public int Classify(List<XmlNode> fullSet) {

            List<XmlNode> trainingSet = new List<XmlNode>();
            List<XmlNode> learningSet = new List<XmlNode>();

            int numberOfElements = fullSet.Count;
            int numberOfTrainingElements = Convert.ToInt32(0.6 * numberOfElements);
            int truePositiveCounter = 0;
            int k = 15;

            for (int i=0; i < numberOfTrainingElements; i++) {
                trainingSet.Add(fullSet.ElementAt(i));
            }

            for (int i = numberOfTrainingElements; i < numberOfElements; i++) {
                learningSet.Add(fullSet.ElementAt(i));   
            }



            return 0;
        }
    }
}
