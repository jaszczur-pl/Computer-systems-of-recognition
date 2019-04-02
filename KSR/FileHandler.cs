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
        const string stopwordsPath = @"..\..\Resources\stopwords.txt";
        const string sgmFilesDirectory = @"..\..\Resources";

        public void WriteParentNode(string filePath) {

            var lines = File.ReadAllLines(filePath).ToList();

            if (!lines.ElementAt(1).Equals("<ROOT>")) {
                lines.Insert(1, "<ROOT>");
                lines.Add("</ROOT>");
                File.WriteAllLines(filePath, lines);
            }
        }

        public string GetStopwords() {
            TextReader reader = new StreamReader(stopwordsPath);

            return reader.ReadToEnd();
        }

        public string[] GetAllSgmFilePaths() {
            return Directory.GetFiles(sgmFilesDirectory, "*sgm");
        }
    }
}
