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
        private readonly Dictionary<string, IMetric> metrics = new Dictionary<string, IMetric>() {
            { "Euklidesowa", new EuclideanMetric()},
            { "Uliczna", new ManhattanMetric()},
            { "Czebyszewa", new MaximumMetric()},
            { "MinMax", new MinMaxMetric()},
            { "MinMax2", new MinMax2Metric()},
        };

        private readonly Dictionary<string, double> trainingSet = new Dictionary<string, double>() {
            { "20%", 0.2},
            { "40%", 0.4},
            { "60%", 0.6},
            { "80%", 0.8},
        };

        private readonly List<string> places = new List<string>() {
            "usa",
            "france",
            "uk",
            "canada",
            "japan",
            "west-germany"
        };

        private readonly string allSerializedArticlesPath = @"..\..\Resources\all_articles.binary";

        public double MainProcess(string selectedTrainingSet, 
            int neighbours, string selectedMetric, string label, string labelToClassify, Dictionary<string,bool> characteristics) {

            //Initial processing (sgml to xml conversion.. etc.
            double trainingSetSize = this.trainingSet[selectedTrainingSet];
            double testingSetSize = 1.0 - trainingSetSize;
            IMetric metric = metrics[selectedMetric];

            ArticleRepo articleRepo = new ArticleRepo();
            XmlHandler XmlHandler = new XmlHandler();
            FileHandler fileHandler = new FileHandler();
            string lastLabel = fileHandler.ReadLabelFromFile();


            if(lastLabel != label) {
                XmlDocument xmlDoc = XmlHandler.GetMergedXmlDocuments();
                XmlNodeList xmlNodeList = XmlHandler.GetAllCorrectNodes(xmlDoc, label);
                articleRepo = new ArticleRepo(xmlNodeList, label);
                articleRepo.SelectValidArticles(places);

                articleRepo.CleanUpTextAndRemoveStopwords();
                articleRepo.PerformStemmingAndListWords();

                fileHandler.Serialize(articleRepo, allSerializedArticlesPath);

                fileHandler.WriteLabelToFile(label);
            } else {
                articleRepo = fileHandler.Deserialize(allSerializedArticlesPath);
            }

            //Mark training and testing set
            ArticleRepo trainingSet = articleRepo.SelectTrainigSet(articleRepo, trainingSetSize);
            trainingSet.articles = articleRepo.SelectValidNumberOfArticles(places, trainingSet.articles);

            ArticleRepo testingSet = articleRepo.SelectTestingSet(articleRepo, testingSetSize);
            testingSet.articles = testingSet.articles.Where(i => i.Label == labelToClassify).ToList();

            List<Article> processingList = trainingSet.articles.Concat(testingSet.articles).ToList();

            //Prepare Extracts
            Extractor extractor = new Extractor();
            List<Article> trainingArticlesWithLabel = trainingSet.articles.Where(i => i.Label == labelToClassify).ToList();
            string calcKeyword = extractor.GetKeyword(trainingArticlesWithLabel);

            foreach (Article article in processingList) {
                article.AllCharacteristicValues = new List<double>();
            }

            if (characteristics["numberOfWords"]) {
                processingList = extractor.CountAllWords(processingList);
            }
            if (characteristics["numberOfKeywords"]) {
                processingList = extractor.CountKeywords(calcKeyword, processingList);
            }
            if (characteristics["hasKeyword"]) {
                processingList = extractor.CheckExistingKeywords(processingList);
            }
            if (characteristics["keywordPosition"]) {
                processingList = extractor.CheckKeywordPosition(calcKeyword, processingList);
            }
            if (characteristics["keywordFrequency"]) {
                processingList = extractor.CheckKeywordFrequency(calcKeyword, processingList);
            }

            double acc = extractor.Classify(trainingSet, testingSet, neighbours, metric);

            return acc;
        }
    }


}
