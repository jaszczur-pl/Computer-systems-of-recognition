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
        private readonly string allSerializedArticlesPath = @"..\..\Resources\all_articles.binary";
        private List<string> keywords = new List<string> { "america", "germany", "cocoa" };
        private List<string> userKeywords = new List<string>();
        private string stringOfWords = "new york";

        public void MainProcess() {
            
            XmlHandler XmlHandler = new XmlHandler();
            FileHandler fileHandler = new FileHandler();

            //XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
            //XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc);
            //ArticleRepo articleRepo = new ArticleRepo(xmlNodeList);

            //articleRepo.CleanUpTextAndRemoveStopwords();
            //articleRepo.PerformStemming();

            //fileHandler.Serialize(articleRepo, allSerializedArticlesPath);

            ArticleRepo articleRepoDeserialized = new ArticleRepo();
            articleRepoDeserialized = fileHandler.Deserialize(allSerializedArticlesPath);

            Extractor extractor = new Extractor();

            foreach (Article article in articleRepoDeserialized.articles) {
                article.WordCounter = extractor.CountAllWords(article.Text);
                article.KeywordCounter = extractor.CountKeywords(keywords, article.Text);
                article.hasExistingKeyword = extractor.CheckExistingKeywords(article.KeywordCounter, article.Text);
                int keywordPosition = extractor.CheckKeywordPosition("america", article.Text);

            }


            int elementNumber = 1;
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).WordCounter);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["germany"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["cocoa"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["germany"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["cocoa"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Text);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Label);
            Console.ReadKey();


        }

    }


}
