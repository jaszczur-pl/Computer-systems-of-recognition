using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using KSR.Metrics;

namespace KSR
{
    class Processing
    {
        private readonly string allSerializedArticlesPath = @"..\..\Resources\all_articles.binary";
        private List<string> keywords = new List<string> { "usa", "germany", "cocoa" };
        //mocks - to be changed
        private List<string> userKeywords = new List<string>() { "usa"};
        private string stringOfWords = "american dream";

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
                article.UserKeywordCounter = extractor.CountKeywords(userKeywords, article.Text);
                article.hasExistingKeyword = extractor.CheckExistingKeywords(article.KeywordCounter, article.Text);
                article.KeywordFirstPosition = extractor.CheckKeywordPosition(keywords, article.Text);
                article.KeywordFrequency = extractor.CheckKeywordFrequency(article.KeywordCounter, article.WordCounter);
                article.HasStringOfWords = extractor.CheckStringOfWords(stringOfWords, article.Text);
                article.SetAllCharacteristicsValue();
            }


            //int elementNumber = 1;
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).WordCounter);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["america"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["germany"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).hasExistingKeyword["cocoa"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["america"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["germany"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordCounter["cocoa"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).UserKeywordCounter["america"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFirstPosition["america"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFirstPosition["germany"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).KeywordFrequency["america"]);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).HasStringOfWords);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Text);
            //Console.WriteLine(articleRepoDeserialized.articles.ElementAt(elementNumber).Label);
            //Console.ReadKey();

            Article A = new Article { Label = "usa", ID = "1", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article B = new Article { Label = "germany", ID = "2", AllCharacteristicValues = new List<double> { 5.0, 7.0, 9.0 } };
            Article C = new Article { Label = "usa", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article D = new Article { Label = "poland", ID = "4", AllCharacteristicValues = new List<double> { 6.0, 8.0, 4.0 } };
            Article E = new Article { Label = "poland", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };

            ArticleRepo trainingRep = new ArticleRepo();
            trainingRep.articles = new List<Article> { A, B, D };

            ArticleRepo testedRep = new ArticleRepo();
            testedRep.articles = new List<Article> { C, E };

            int neighboursNumber = 15;
            IMetric metric = new EuclideanMetric();
            double acc = extractor.Classify(trainingRep, testedRep, neighboursNumber, metric);

            //double acc = extractor.calculateGeneralNGrams("programmer", "programming");

            Console.WriteLine(acc);

            List<double> listOne = new List<double> { 1, 90, 3, 3 };
            List<double> listTwo = new List<double> { 7, 3, 5, 5 };

            IMetric met = new MinMaxMetric();
            double res = met.CalculateDistance(listOne, listTwo);
            Console.WriteLine(res);
        }

    }


}
