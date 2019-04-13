using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using KSR.View;

namespace KSR
{
    class Program
    {
        [STAThread]
        static void Main(string[] args) {

            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());

            Processing process = new Processing();
            process.MainProcess();

            //XmlNodeList nodeListPlacesUsa = xmlRoot.SelectNodes("REUTERS[PLACES/D='usa' and PLACES[count(D)=1]]");
        }
    }
}
