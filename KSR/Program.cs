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
            SGMLParser sgmlParser = new SGMLParser();
            XmlDocument xmlDoc = sgmlParser.GetXmlDoc();
            
            Console.WriteLine(xmlDoc.ParentNode);
        }
    }
}
