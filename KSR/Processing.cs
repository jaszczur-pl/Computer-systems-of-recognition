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
        //mocks - to be changed
        private List<string> userKeywords = new List<string>() { "america"};
        private string stringOfWords = "american dream";

        public void MainProcess() {
            
            XmlHandler XmlHandler = new XmlHandler();
            FileHandler fileHandler = new FileHandler();

            XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
            XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc);
            ArticleRepo articleRepo = new ArticleRepo(xmlNodeList);

            articleRepo.CleanUpTextAndRemoveStopwords();
            articleRepo.PerformStemming();

            fileHandler.Serialize(articleRepo, allSerializedArticlesPath);

            ArticleRepo articleRepoDeserialized = new ArticleRepo();
            articleRepoDeserialized = fileHandler.Deserialize(allSerializedArticlesPath);

            Extractor extractor = new Extractor();

            foreach (Article article in articleRepoDeserialized.articles) {
                article.WordCounter = extractor.CountAllWords(article.Text);
                article.KeywordCounter = extractor.CountKeywords(keywords, article.Text);
                article.UserKeywordCounter = extractor.CountKeywords(userKeywords, article.Text);
                article.hasExistingKeyword = extractor.CheckExistingKeywords(article.KeywordCounter, article.Text);
                article.KeywordFirstPosition = extractor.CheckKeywordPosition(keywords, article.Text);
                article.KeywordFrequency = extractor.CheckKeywordFrequency(article.KeywordCounter, article.WordCounter);
                article.HasStringOfWords = extractor.CheckStringOfWords(stringOfWords, article.Text);
            }


            int elementNumber = 1;
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).WordCounter);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["germany"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["cocoa"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["germany"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["cocoa"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).UserKeywordCounter["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFirstPosition["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFirstPosition["germany"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFrequency["america"]);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).HasStringOfWords);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Text);
            Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Label);
            Console.ReadKey();


        }

    }


}
