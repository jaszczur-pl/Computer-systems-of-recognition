using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Sgml;

namespace KSR
{
    class SGMLParser
    {
        private const string filePath = "E:\\Studia - informatyka\\6 semestr\\KSR\\reuters21578\\reut2-000.sgm";
        private const string dtdPath = "E:\\Studia - informatyka\\6 semestr\\KSR\\reuters21578\\lewis.dtd";

        public XmlDocument GetXmlDoc() {
            TextReader reader = new StreamReader(filePath);

            SgmlReader sgmlReader = new SgmlReader();
            sgmlReader.IgnoreDtd = true;
            //sgmlReader.SystemLiteral = dtdPath;
            sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
            sgmlReader.InputStream = reader;

            //create XML document
            //List<XmlDocument> xmlDocList = new List<XmlDocument>();

                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.PreserveWhitespace = true;
                xmlDoc.XmlResolver = null;
                xmlDoc.Load(sgmlReader);

                //xmlDocList.Add(xmlDoc);


            return xmlDoc;
        }

        /*public void readFile() {
            try {
                string line = null;
                TextReader readFile = new StreamReader(V);
                while (true) {
                    line = readFile.ReadLine();
                    if (line != null) {
                        Console.WriteLine(line);
                    }
                }
            }
            catch (IOException ex) {
                Console.WriteLine(ex.ToString());
            }
        } */

    }
}
