using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace KSR
{
    class Processing
    {
        XmlHandler XmlHandler { get; set; }

        public void MainProcess() {

            XmlHandler = new XmlHandler();
            XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
            XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc);

            //XmlNodeList nodeList = xmlDoc.DocumentElement.SelectNodes("REUTERS[PLACES[count(D)>1] or PLACES[count(D)=0]]");

            //foreach (XmlNode node in nodeList) {
            //    xmlDoc.DocumentElement.RemoveChild(node);
            //}

            //XmlHandler xmlHandler = new XmlHandler();
            //string stopwordsRegex = xmlHandler.BuildStopwordsRegex(stopwordsPath);

            //xmlDoc = xmlHandler.RemoveStopWords(xmlDoc, stopwordsRegex);
            //xmlDoc.Save(xmlDocPath);
        }

    }


}
