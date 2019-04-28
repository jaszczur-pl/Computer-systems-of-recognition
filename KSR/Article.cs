using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR
{
    [Serializable]
    class Article {
        public string ID { get; set; }
        public string Label { get; set; }
        public string Text { get; set; }

        public double WordCounter { get; set; }
        public double HasStringOfWords { get; set; }
        public double HasExistingKeyword { get; set; }
        public double KeywordCounter { get; set; }
        public double KeywordFirstPosition { get; set; }
        public double KeywordFrequency { get; set; }

        public List<double> AllCharacteristicValues { get; set; }

        //public int WordCounter { get; set; }
        //public bool HasStringOfWords { get; set; }
        //public Dictionary<string, bool> hasExistingKeyword { get; set; }
        //public Dictionary<string, int> KeywordCounter { get; set; }
        //public Dictionary<string, int> KeywordFirstPosition { get; set; }
        //public Dictionary<string, double> KeywordFrequency { get; set; }

        //propositions?
        //public int NumberOfNumbers;
        //public int NumberOfCharactersInText;
        //public int NumberOfWordsWithLessThan5Chars;
        //public string KeyWord;

        public void SetAllCharacteristicsValue() {
            AllCharacteristicValues = new List<double>();

            AllCharacteristicValues.Add(WordCounter);
            AllCharacteristicValues.Add(KeywordCounter);
            AllCharacteristicValues.Add(HasExistingKeyword);
            AllCharacteristicValues.Add(KeywordFirstPosition);
            AllCharacteristicValues.Add(KeywordFrequency);
            AllCharacteristicValues.Add(HasStringOfWords);
        }
        //public void SetAllCharacteristicsValue() {
        //    AllCharacteristicValues = new List<double>();
        //    AllCharacteristicValues.Add(WordCounter);

        //    if(HasStringOfWords == true) {
        //        AllCharacteristicValues.Add(1.0);
        //    }
        //    else {
        //        AllCharacteristicValues.Add(0);
        //    }

        //    foreach (KeyValuePair<string, bool> entry in hasExistingKeyword) {
        //        if (entry.Value == true) {
        //            AllCharacteristicValues.Add(1.0);
        //        }
        //        else {
        //            AllCharacteristicValues.Add(0);
        //        }
        //    }

        //    foreach (KeyValuePair<string, int> entry in KeywordCounter) {
        //        AllCharacteristicValues.Add(entry.Value);
        //    }

        //    foreach (KeyValuePair<string, int> entry in KeywordFirstPosition) {
        //        AllCharacteristicValues.Add(entry.Value);
        //    }

        //    foreach (KeyValuePair<string, double> entry in KeywordFrequency) {
        //        AllCharacteristicValues.Add(entry.Value);
        //    }

        //}
    }
}
