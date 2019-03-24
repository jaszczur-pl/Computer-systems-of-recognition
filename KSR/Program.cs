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

            //west-germany, usa, france, uk, canada, japan 

            string[] allFilePaths = Directory.GetFiles("C:\\Users\\maciej.jaszczura\\OneDrive - Accenture\\!Sync\\Downloads\\reuters21578.tar\\", "*sgm");
            FileHandler fileHandler = new FileHandler();
            SgmlToXmlParser sgmlParser = new SgmlToXmlParser();
            XmlDocument xmlDoc = sgmlParser.GetXmlDoc(allFilePaths[0]);

            //omit first file path in array for further processing
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
            XmlNodeList nodeListPlacesUsa = xmlRoot.SelectNodes("REUTERS[PLACES/D='usa' and PLACES[count(D)=1]]");
            XmlNodeList nodeListPlacesWestGermany = xmlRoot.SelectNodes("REUTERS[PLACES/D='west-germany' and PLACES[count(D)=1]]");
            XmlNodeList nodeListPlacesFrance = xmlRoot.SelectNodes("REUTERS[PLACES/D='france' and PLACES[count(D)=1]]");
            XmlNodeList nodeListPlacesUk = xmlRoot.SelectNodes("REUTERS[PLACES/D='uk' and PLACES[count(D)=1]]");
            XmlNodeList nodeListPlacesCanada = xmlRoot.SelectNodes("REUTERS[PLACES/D='canada' and PLACES[count(D)=1]]");
            XmlNodeList nodeListPlacesJapan = xmlRoot.SelectNodes("REUTERS[PLACES/D='japan' and PLACES[count(D)=1]]");

            XmlNodeList nodeListTopicsEarn = xmlRoot.SelectNodes("REUTERS[TOPICS/D='earn' and TOPICS[count(D)=1]]");
            XmlNodeList nodeListTopicsInterest = xmlRoot.SelectNodes("REUTERS[TOPICS/D='interest' and TOPICS[count(D)=1]]");
            XmlNodeList nodeListTopicsCoffee = xmlRoot.SelectNodes("REUTERS[TOPICS/D='coffee' and TOPICS[count(D)=1]]");
            XmlNodeList nodeListTopicsMoneyFx = xmlRoot.SelectNodes("REUTERS[TOPICS/D='money-fx' and TOPICS[count(D)=1]]");
            XmlNodeList nodeListTopicsCrude = xmlRoot.SelectNodes("REUTERS[TOPICS/D='crude' and TOPICS[count(D)=1]]");

            int a = nodeListTopicsEarn.Count;
            int b = nodeListTopicsInterest.Count;
            int c = nodeListTopicsCoffee.Count;
            int d = nodeListTopicsCrude.Count;
            int e = nodeListTopicsMoneyFx.Count;

            Console.WriteLine(a);
            Console.WriteLine(b);
            Console.WriteLine(c);
            Console.WriteLine(d);
            Console.WriteLine(e);
            Console.WriteLine(nodeListTopicsEarn.Item(0).OuterXml);
        }
    }
}
