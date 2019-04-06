using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Iveonik.Stemmers;

namespace KSR
{
    class Extractor
    {
        public int CountAllWords(string text) {
            char[] delimiters = new char[] { ' ' };

            int cnt = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries).Length;

            return cnt;
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

        public Dictionary<string, bool> CheckExistingKeywords(List<string> listOfwords, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            Dictionary<string, bool> hasExistingKeyword = new Dictionary<string, bool>();

            foreach (string word in listOfwords) {
                string stemmedWord = stemmer.Stem(word);
                char[] delimiters = new char[] { ' ' };
                string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

                int cnt = 0;
                int i = 0;
                hasExistingKeyword[word] = false;

                while (i < words.Length) {
                    if (stemmedWord == words[i]) {
                        hasExistingKeyword[word] = true;
                    }
                    i++;
                }
                
            }

            return hasExistingKeyword;
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

        //check the position of the word from the beginning of the text
        public int CheckKeywordPosition(string word, string text) {
            EnglishStemmer stemmer = new EnglishStemmer();
            word = stemmer.Stem(word);
            int position = -1;

            char[] delimiters = new char[] { ' ' };
            string[] words = text.Split(delimiters, StringSplitOptions.RemoveEmptyEntries);

            int i = 0;
            while (i < words.Length)
            {
                if(word == words[i]) {
                    position = i + 1;
                    break;
                }
                i++;
            }

            return position;
        }
    }
}
