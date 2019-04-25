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
        public int CountAllWords(string text) {
            char[] delimiters = new char[] { ' ' };

            int cnt = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            return cnt;
        }

        public int CountKeywords(string keyword, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();

                string stemmedWord = stemmer.Stem(keyword);
                char[] delimiters = new char[] { ' ' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int cnt = 0;
                int i = 0;

                while (i < words.Length) {
                    if (stemmedWord == words[i]) {
                        cnt++;
                    }
                    i++;
                }

            return cnt;
        }

        public int CheckExistingKeywords(int keywordsCounter, string text) {

            int hasExistingKeyword;

                if (keywordsCounter == 0) {
                    hasExistingKeyword = 0;
                }
                else {
                    hasExistingKeyword = 1;
                }

            return hasExistingKeyword;
        }

        public double CheckKeywordFrequency(int keywordCounter, int numberOfWordsInText) {

            double keywordFrequency = Math.Round((double)keywordCounter/ numberOfWordsInText, 3);

            return keywordFrequency;
        }

        public int CheckStringOfWordsInt(string stringOfWords, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            stringOfWords = stringOfWords.ToLower();

            char[] delimiters = new char[] { ' ' };

            foreach (string word in stringOfWords.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)) {
                stringOfWords = stringOfWords.Replace(word, stemmer.Stem(word));
            }

            bool hasString = Regex.IsMatch(text, stringOfWords);

            if (hasString) {
                return 1;
            } else {
                return 0;
            }
        }

        public double CheckKeywordPosition(string keyword, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();

            string stemmedWord = stemmer.Stem(keyword);
            int position = 100;

            char[] delimiters = new char[] { ' ' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);
            int wordsCnt = words.Length;

            int i = 0;

            while (i < words.Length) {
                if (keyword == words[i]) {
                    position = i + 1;
                    break;
                }
                i++;
            }

            if (position < 10) {
                return 1;
            } else if (position < 20) {
                return 0.75;
            } else if (position < 30) {
                return 0.5;
            } else if (position < 40) {
                return 0.25;
            } else {
                return 0;
            }
        }


        public Dictionary<string, int> CountKeywords(List<string> listOfwords, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            Dictionary<string, int> keywordCounters = new Dictionary<string, int>();

            foreach (string word in listOfwords) {
                string stemmedWord = stemmer.Stem(word);
                char[] delimiters = new char[] { ' ' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int cnt = 0;
                int i = 0;

                while (i < words.Length) {
                    if (stemmedWord == words[i]) {
                        cnt++;
                    }
                    i++;
                }
                keywordCounters[word] = cnt;
            }

            return keywordCounters;
        }

        public Dictionary<string, bool> CheckExistingKeywords(Dictionary<string, int> keywordsCounter, string text) {

            Dictionary<string, bool> hasExistingKeyword = new Dictionary<string, bool>();

            foreach (KeyValuePair<string, int> entry in keywordsCounter) {
                if(entry.Value == 0) {
                    hasExistingKeyword[entry.Key] = false;
                }
                else {
                    hasExistingKeyword[entry.Key] = true;
                }
            }

            return hasExistingKeyword;
        }

        public Dictionary<string, double> CheckKeywordFrequency(Dictionary<string, int> keywordCounter, int numberOfWordsInText) {
            Dictionary<string, double> keywordsFrequency = new Dictionary<string, double>();

            foreach (KeyValuePair<string, int> entry in keywordCounter) {
                keywordsFrequency[entry.Key] = Math.Round((double)entry.Value / numberOfWordsInText, 3);
            }

            return keywordsFrequency;
        }

        public bool CheckStringOfWords (string stringOfWords, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            stringOfWords = stringOfWords.ToLower();

            char[] delimiters = new char[] { ' ' };

            foreach (string word in stringOfWords.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)) {
                stringOfWords = stringOfWords.Replace(word, stemmer.Stem(word));
            }

            bool hasString = Regex.IsMatch(text, stringOfWords);

            return hasString;
        }

        //check the position of the word from the beginning of the text
        public Dictionary<string, int> CheckKeywordPosition(List<string> listOfWords, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            Dictionary<string, int> keywordsPosition = new Dictionary<string, int>();

            foreach(string word in listOfWords) {
                string stemmedWord = stemmer.Stem(word);
                int position = -1;

                char[] delimiters = new char[] { ' ' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int i = 0;
                while (i < words.Length) {
                    if (word == words[i]) {
                        position = i + 1;
                        break;
                    }
                    i++;
                }
                keywordsPosition[word] = position;
            }

            return keywordsPosition;
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

        public double Classify(ArticleRepo trainingSet, ArticleRepo testedSet, int neighboursNumber, IMetric metric) {

            Dictionary<Article[], double> distancesDict = new Dictionary<Article[], double>();
            List<string> trainingLabels = new List<string>();

            int truePositiveCounter = 0;
            int testedSetSize = testedSet.articles.Count;

            foreach(Article testedArticle in testedSet.articles) {

                foreach(Article trainingArticle in trainingSet.articles) {
                    double distance = metric.CalculateDistance(trainingArticle.AllCharacteristicValues, testedArticle.AllCharacteristicValues);
                    Article[] articleIDPair = { testedArticle, trainingArticle };
                    distancesDict[articleIDPair] = distance;
                }

                var sortedDict = (from entry
                                 in distancesDict
                                  orderby entry.Value ascending
                                  select entry).Take(neighboursNumber);

                foreach(var item in sortedDict) {
                    string trainingLabel = item.Key.ElementAt(1).Label;
                    trainingLabels.Add(trainingLabel);
                }

                string testedLabel = trainingLabels.GroupBy(x => x).OrderByDescending(x => x.Count()).First().Key;

                if(testedLabel == testedArticle.Label) {
                    truePositiveCounter++;
                }
            }

            double accuracy = (double)truePositiveCounter / testedSetSize;

            return accuracy;
        }
    }
}
