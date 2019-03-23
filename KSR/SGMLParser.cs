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
    class SgmlToXmlParser
    {
        public XmlDocument GetXmlDoc(string filePath) {
            TextReader reader = new StreamReader(filePath);

            SgmlReader sgmlReader = new SgmlReader();
            sgmlReader.IgnoreDtd = true;
            sgmlReader.WhitespaceHandling = WhitespaceHandling.All;
            sgmlReader.InputStream = reader;

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.PreserveWhitespace = false;
            xmlDoc.XmlResolver = null;
            xmlDoc.Load(sgmlReader);

            return xmlDoc;
        }

    }
}
