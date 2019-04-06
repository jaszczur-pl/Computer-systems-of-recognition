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

            Processing process = new Processing();
            process.MainProcess();

            //XmlNodeList nodeListPlacesUsa = xmlRoot.SelectNodes("REUTERS[PLACES/D='usa' and PLACES[count(D)=1]]");
        }
    }
}
