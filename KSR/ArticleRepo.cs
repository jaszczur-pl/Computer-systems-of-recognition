using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using Iveonik.Stemmers;

namespace KSR
{
    [Serializable]
    class ArticleRepo
    {
        public List<Article> articles { get; set; }

        public ArticleRepo() { }

        public ArticleRepo(XmlNodeList xmlNodeList) {
            articles = new List<Article>();

            foreach (XmlNode node in xmlNodeList) {
                Article article = new Article();

                article.ID = node.Attributes["NEWID"].InnerXml;
                if (node.SelectSingleNode("PLACES/D") == null) {
                    article.Label = "None";
                }
                else {
                    article.Label = node.SelectSingleNode("PLACES/D").InnerText;
                }
                //article.Label = node.SelectSingleNode("PLACES/D").InnerText;
                article.Text = node.SelectSingleNode("TEXT/BODY").InnerText;

                articles.Add(article);
            }
        }

        public void CleanUpTextAndRemoveStopwords() {
            List<string> punctations = new List<string>(new string[] { ".", ",", ":", ";", "-", "!", "?", "/", "\\" });
            List<string> stoplist = BuildStoplist();
           

            //Remove all punctations, stopwords and whitespaces
            foreach(Article article in articles) {
                StringBuilder sb = new StringBuilder(article.Text.ToLower());
                sb.Replace("\r\n", " ");

                punctations.ForEach(punct => sb.Replace(punct, " "));
                stoplist.ForEach(stopword => sb.Replace(stopword, " "));

                article.Text = Regex.Replace(sb.ToString(), @"\s+", " ");
            }
        }

        public void PerformStemming() {
            EnglishStemmer stemmer = new EnglishStemmer();

            foreach (Article article in articles) {
                string text = article.Text;

                char[] delimiters = new char[] { ' ' };

                foreach (string word in text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)) {
                    text = text.Replace(word, stemmer.Stem(word));
                }

                article.Text = text;
            }
        }

        private static List<string> BuildStoplist() {
            FileHandler fileHandler = new FileHandler();
            List<string> stoplistRegex = fileHandler.GetStopwords2();
            stoplistRegex = stoplistRegex.Select(stopword => " " + stopword + " ").ToList();

            return stoplistRegex;
        }



    }
}
