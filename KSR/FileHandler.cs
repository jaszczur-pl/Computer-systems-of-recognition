using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.IO;

namespace KSR
{
    class FileHandler
    {
        public void writeParentNode(string filePath) {

            var lines = File.ReadAllLines(filePath).ToList();

            if (!lines.ElementAt(1).Equals("<ROOT>")) {
                lines.Insert(1, "<ROOT>");
                lines.Add("</ROOT>");
                File.WriteAllLines(filePath, lines);
            }
        }
    }
}
