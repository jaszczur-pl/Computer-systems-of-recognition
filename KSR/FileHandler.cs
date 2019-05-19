using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace KSR
{
    class FileHandler
    {
        const string stopwordsPath = @"..\..\Resources\stopwords.txt";
        const string labelFilePath = @"..\..\Resources\label.txt";
        const string sgmFilesDirectory = @"..\..\Resources";

        public void WriteParentNode(string filePath) {

            var lines = File.ReadAllLines(filePath).ToList();

            if (!lines.ElementAt(1).Equals("<ROOT>")) {
                lines.Insert(1, "<ROOT>");
                lines.Add("</ROOT>");
                File.WriteAllLines(filePath, lines);
            }
        }

        public List<string> GetStopwords2() {
            return File.ReadAllLines(stopwordsPath).ToList();
        }

        public string[] GetAllSgmFilePaths() {
            return Directory.GetFiles(sgmFilesDirectory, "*sgm");
        }

        public void Serialize(object o, string path) {

            BinaryFormatter bf = new BinaryFormatter();
            FileStream fsout = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None);

            try {
                using (fsout) {
                    bf.Serialize(fsout, o);
                }
            }
            catch (Exception e) {
                Console.WriteLine(e.StackTrace);
            } finally {
                fsout.Dispose();
            }
        }

        public ArticleRepo Deserialize(string path) {

            ArticleRepo articleRepo = new ArticleRepo();

            BinaryFormatter bf = new BinaryFormatter();

            FileStream fsin = new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.None);

            try {
                using (fsin) {
                    articleRepo = (ArticleRepo)bf.Deserialize(fsin);
                }
            } catch(Exception e) {
                Console.WriteLine(e.StackTrace);
            }
            finally {
                fsin.Dispose();
            }

            return articleRepo;
        }

        public void WriteLabelToFile(string label) {

            File.WriteAllText(labelFilePath, label);
        }

        public string ReadLabelFromFile() {
            return File.ReadAllText(labelFilePath);
        }
    }
}
