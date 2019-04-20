﻿using System;
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
        private readonly Dictionary<string, IMetric> dicMetrics = new Dictionary<string, IMetric>() {
            { "Euklidesowa", new EuclideanMetric()},
            { "Uliczna", new ManhattanMetric()},
            { "Czebyszewa", new MaximumMetric()},
            { "MinMax", new MinMaxMetric()},
            { "MinMax2", new MinMax2Metric()},
        };

        private readonly Dictionary<string, double> dicTrainingSet = new Dictionary<string, double>() {
            { "20%", 0.2},
            { "40%", 0.4},
            { "60%", 0.6},
            { "80%", 0.8},
        };

        private readonly string allSerializedArticlesPath = @"..\..\Resources\all_articles.binary";
        private List<string> keywords = new List<string> { "usa", "germany", "cocoa" };
        //mocks - to be changed


        public void MainProcess() {
            List<string> userKeywords = new List<string>() { "usa" };
            string stringOfWords = "american dream";
            string label = "PLACES";
            int neighboursNumber = 15;
            double trainingSetSize = 0.6;
            double testingSetSize = 1.0 - trainingSetSize;
            IMetric metric = new EuclideanMetric();

            XmlHandler XmlHandler = new XmlHandler();
            FileHandler fileHandler = new FileHandler();

            //temporary block of code - start
            //XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
            //XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc, label);
            //ArticleRepo articleRepo = new ArticleRepo(xmlNodeList, label);

            //articleRepo.CleanUpTextAndRemoveStopwords();
            //articleRepo.PerformStemming();

            //fileHandler.Serialize(articleRepo, allSerializedArticlesPath);
            //temporary block of code - end

            ArticleRepo articleRepoDeserialized = new ArticleRepo();
            articleRepoDeserialized = fileHandler.Deserialize(allSerializedArticlesPath);
            ArticleRepo trainingSet = articleRepoDeserialized.SelectTrainigSet(articleRepoDeserialized, trainingSetSize);
            ArticleRepo testingSet = articleRepoDeserialized.SelectTestingSet(articleRepoDeserialized, testingSetSize);

            Extractor extractor = new Extractor();

            foreach (Article article in articleRepoDeserialized.articles) {
                article.WordCounter = extractor.CountAllWords(article.Text);
                article.KeywordCounter = extractor.CountKeywords(keywords, article.Text);
                article.hasExistingKeyword = extractor.CheckExistingKeywords(article.KeywordCounter, article.Text);
                article.KeywordFirstPosition = extractor.CheckKeywordPosition(keywords, article.Text);
                article.KeywordFrequency = extractor.CheckKeywordFrequency(article.KeywordCounter, article.WordCounter);
                article.HasStringOfWords = extractor.CheckStringOfWords(stringOfWords, article.Text);
                article.SetAllCharacteristicsValue();
            }


            Article A = new Article { Label = "usa", ID = "1", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article B = new Article { Label = "germany", ID = "2", AllCharacteristicValues = new List<double> { 5.0, 7.0, 9.0 } };
            Article C = new Article { Label = "usa", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article D = new Article { Label = "poland", ID = "4", AllCharacteristicValues = new List<double> { 6.0, 8.0, 4.0 } };
            Article E = new Article { Label = "poland", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };

            ArticleRepo trainingRep = new ArticleRepo();
            trainingRep.articles = new List<Article> { A, B, D };

            ArticleRepo testedRep = new ArticleRepo();
            testedRep.articles = new List<Article> { C, E };


            double acc = extractor.Classify(trainingRep, testedRep, neighboursNumber, metric);

            //double acc = extractor.CalculateGeneralNGrams("programmer", "programming");

            Console.WriteLine(acc);

            List<double> listOne = new List<double> { 1, 90, 3, 3 };
            List<double> listTwo = new List<double> { 7, 3, 5, 5 };

            IMetric met = new MinMax2Metric();
            double res = met.CalculateDistance(listOne, listTwo);
            Console.WriteLine(res);
        }

        public double MainProcess(List<string> userKeywords, string stringOfWords, string sTrainingSet, int neighbours, string sMetric, string label) {

            double trainingSetSize = dicTrainingSet[sTrainingSet];
            double testingSetSize = 1.0 - trainingSetSize;
            IMetric metric = dicMetrics[sMetric];

            XmlHandler XmlHandler = new XmlHandler();
            FileHandler fileHandler = new FileHandler();

            //XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
            //XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc, label);
            //ArticleRepo articleRepo = new ArticleRepo(xmlNodeList, label);

            //articleRepo.CleanUpTextAndRemoveStopwords();
            //articleRepo.PerformStemming();

            //fileHandler.Serialize(articleRepo, allSerializedArticlesPath);

            ArticleRepo articleRepoDeserialized = new ArticleRepo();
            articleRepoDeserialized = fileHandler.Deserialize(allSerializedArticlesPath);
            ArticleRepo trainingSet = articleRepoDeserialized.SelectTrainigSet(articleRepoDeserialized, trainingSetSize);
            ArticleRepo testingSet = articleRepoDeserialized.SelectTestingSet(articleRepoDeserialized, testingSetSize);

            Extractor extractor = new Extractor();

            foreach (Article article in articleRepoDeserialized.articles) {
                article.WordCounter = extractor.CountAllWords(article.Text);
                article.KeywordCounter = extractor.CountKeywords(keywords, article.Text);
                article.hasExistingKeyword = extractor.CheckExistingKeywords(article.KeywordCounter, article.Text);
                article.KeywordFirstPosition = extractor.CheckKeywordPosition(keywords, article.Text);
                article.KeywordFrequency = extractor.CheckKeywordFrequency(article.KeywordCounter, article.WordCounter);
                article.HasStringOfWords = extractor.CheckStringOfWords(stringOfWords, article.Text);
                article.SetAllCharacteristicsValue();
            }

            Article A = new Article { Label = "usa", ID = "1", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article B = new Article { Label = "germany", ID = "2", AllCharacteristicValues = new List<double> { 5.0, 7.0, 9.0 } };
            Article C = new Article { Label = "usa", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };
            Article D = new Article { Label = "poland", ID = "4", AllCharacteristicValues = new List<double> { 6.0, 8.0, 4.0 } };
            Article E = new Article { Label = "poland", ID = "3", AllCharacteristicValues = new List<double> { 1.0, 2.0, 3.0 } };

            ArticleRepo trainingRep = new ArticleRepo();
            trainingRep.articles = new List<Article> { A, B, D };

            ArticleRepo testedRep = new ArticleRepo();
            testedRep.articles = new List<Article> { C, E };

            //double acc = extractor.Classify(trainingRep, testedRep, neighbours, metric);

            double acc = extractor.CalculateGeneralNGrams("programmer", "programming");

            Console.WriteLine(acc);

            List<double> listOne = new List<double> { 1, 90, 3, 3 };
            List<double> listTwo = new List<double> { 7, 3, 5, 5 };

            IMetric met = new MinMax2Metric();
            double res = met.CalculateDistance(listOne, listTwo);
            Console.WriteLine(res);

            return acc;
        }

    }


}
