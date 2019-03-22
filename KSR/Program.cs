using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KSR
{
    class Program
    {
        static void Main(string[] args) {

            string filePath = "C:\\Users\\maciej.jaszczura\\OneDrive - Accenture\\!Sync\\Downloads\\reuters21578.tar\\reut2-000.sgm";

            FileHandler fileHandler = new FileHandler();
            fileHandler.writeParentNode(filePath);
            SGMLParser sgmlParser = new SGMLParser();
            XmlDocument xmlDoc = sgmlParser.GetXmlDoc(filePath);
            Console.WriteLine(xmlDoc.OuterXml);
        }
    }
}
