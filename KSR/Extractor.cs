using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Iveonik.Stemmers;
using KSR.Metrics;

namespace KSR
{
    class Extractor
    {
        public string GetKeyword(List<Article> articles) {

            Dictionary<string, int> words = new Dictionary<string, int>();

            foreach(Article article in articles) {
                foreach(string w in article.Words) {
                    if (!words.ContainsKey(w)) {
                        words.Add(w, 1);
                    }
                    else {
                        words[w] += 1;
                    }
                }
            }

            words = words.OrderByDescending(v => v.Value).ToDictionary(x => x.Key, x => x.Value);
            string keyword = words.OrderByDescending(v => v.Value).First().Key;

            return keyword;
        }

        public List<Article> CountAllWords(List<Article> articles) {

            double max = 0;
            double min = articles[0].Words.Count;

            foreach(Article article in articles) {

                int cnt = article.Words.Count;
                article.AllCharacteristicValues.Add(cnt);

                if (max < cnt) {
                    max = cnt;
                }

                if (min > cnt) {
                    min = cnt;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public List<Article> CountWordsWith4CharsOrLess(List<Article> articles) {

            double max = 0;
            double min = articles[0].Words.Count;

            foreach (Article article in articles) {

                int cnt = 0;

                foreach(string word in article.Words) {
                    if(word.Length <= 4) {
                        cnt++;
                    }
                }

                article.AllCharacteristicValues.Add(cnt);

                if (max < cnt) {
                    max = cnt;
                }

                if (min > cnt) {
                    min = cnt;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public List<Article> CountWordsWithMoreThan4Chars(List<Article> articles) {

            double max = 0;
            double min = articles[0].Words.Count;

            foreach (Article article in articles) {

                int cnt = 0;

                foreach (string word in article.Words) {
                    if (word.Length > 4) {
                        cnt++;
                    }
                }

                article.AllCharacteristicValues.Add(cnt);

                if (max < cnt) {
                    max = cnt;
                }

                if (min > cnt) {
                    min = cnt;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public List<Article> CountKeywords(string keyword, List<Article> articles) {
            EnglishStemmer stemmer = new EnglishStemmer();

            string stemmedWord = stemmer.Stem(keyword);
            int max = 0;
            int min = 1000;

            foreach(Article article in articles) {
                int cnt = 0;
                int i = 0;

                while (i < article.Words.Count) {
                    if (stemmedWord == article.Words[i]) {
                        cnt++;
                    }
                    i++;
                }

                article.AllCharacteristicValues.Add(cnt);

                if (max < cnt) {
                    max = cnt;
                }

                if (min > cnt) {
                    min = cnt;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public List<Article> CheckExistingKeywords(List<Article> articles) {

            int hasExistingKeyword;
            foreach (Article article in articles) {
                double keywordsCounter = article.AllCharacteristicValues.Last();

                if (keywordsCounter == 0) {
                    hasExistingKeyword = 0;
                }
                else {
                    hasExistingKeyword = 1;
                }

                article.AllCharacteristicValues.Add(hasExistingKeyword);
            }
            
            return articles;
        }

        public List<Article> CheckKeywordFrequency(string keyword, List<Article> articles) {

            EnglishStemmer stemmer = new EnglishStemmer();

            string stemmedWord = stemmer.Stem(keyword);
            double max = 0;
            double min = 2;

            foreach(Article article in articles) {
                double textCnt = article.Words.Count;
                double keywordCnt = 0;
                int i = 0;

                while (i < textCnt) {
                    if (stemmedWord == article.Words[i]) {
                        keywordCnt++;
                    }
                    i++;
                }

                double freq = (keywordCnt / textCnt);
                article.AllCharacteristicValues.Add(freq);

                if (max < freq) {
                    max = freq;
                }

                if (min > freq) {
                    min = freq;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public List<Article> CheckKeywordPosition(string keyword, List<Article> articles) {
            EnglishStemmer stemmer = new EnglishStemmer();

            string stemmedWord = stemmer.Stem(keyword);
            int max = 100;
            int min = 1000;

            foreach (Article article in articles) {
                int position = 100;
                int i = 0;

                while (i < article.Words.Count) {
                    if (keyword == article.Words[i]) {
                        if (i >= 100) {
                            position = 0;
                            break;
                        }
                        else {
                            position -= i;
                            break;
                        }
                    }
                    i++;
                }

                article.AllCharacteristicValues.Add(position);

                if (min > position) {
                    min = position;
                }
            }

            int elements = articles[0].AllCharacteristicValues.Count;

            foreach (Article article in articles) {
                double oldValue = article.AllCharacteristicValues.Last();
                double newValue = CalcMinMaxNormalization(oldValue, max, min);
                article.AllCharacteristicValues[elements - 1] = newValue;
            }

            return articles;
        }

        public double CalculateGeneralNGrams(string firstWord, string secondWord) {

            int firstWordLength = firstWord.Length;
            int secondWordLength = secondWord.Length;

            int max = Math.Max(firstWordLength, secondWordLength);
            int counter = 0;

            for (int stringLen = 1; stringLen <= firstWordLength; stringLen++) {
                for (int i = 0; i < firstWordLength - stringLen + 1; i++) {
                    string subFirstWord = firstWord.Substring(i, stringLen);

                    for (int j = 0; j <= firstWordLength - stringLen + 1; j++) {
                        string subSecondWord = secondWord.Substring(j, stringLen);
                        if (subFirstWord == subSecondWord) {
                            counter++;
                            break;
                        }
                    }
                }
            }

            double result = (double) 2* counter / (max * max + max);

            return result;
        }

        public int Classify(ArticleRepo trainingSet, ArticleRepo testedSet, int neighboursNumber, IMetric metric) {

            Dictionary<Article[], double> distancesDict = new Dictionary<Article[], double>();
            List<string> trainingLabels = new List<string>();

            int truePositiveCounter = 0;
            

            foreach(Article testedArticle in testedSet.articles) {
                

                foreach (Article trainingArticle in trainingSet.articles) {
                    double distance = metric.CalculateDistance(trainingArticle.AllCharacteristicValues, testedArticle.AllCharacteristicValues);
                    Article[] articleIDPair = { testedArticle, trainingArticle };
                    distancesDict[articleIDPair] = distance;
                }

                var sortedDict = distancesDict.OrderBy(x => x.Value).Take(neighboursNumber);

                foreach (var item in sortedDict) {
                    string trainingLabel = item.Key.ElementAt(1).Label;
                    trainingLabels.Add(trainingLabel);
                }

                string testedLabel = trainingLabels.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

                if(testedLabel == testedArticle.Label) {
                    truePositiveCounter++;
                }

                trainingLabels.Clear();
                distancesDict.Clear();
            }

            return truePositiveCounter;
        }

        private static double CalcMinMaxNormalization(double probe, double max, double min) {
            return (probe - min) / (max - min);
        }
    }
}
