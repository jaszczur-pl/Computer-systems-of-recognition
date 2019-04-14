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

        public int WordCounter { get; set; }
        public bool HasStringOfWords { get; set; }
        public Dictionary<string, bool> hasExistingKeyword { get; set; }
        public Dictionary<string, int> KeywordCounter { get; set; }
        public Dictionary<string, int> KeywordFirstPosition { get; set; }
        public Dictionary<string, int> UserKeywordCounter { get; set; }
        public Dictionary<string, double> KeywordFrequency { get; set; }

        public List<double> AllCharacteristicValues { get; set; }

        public void SetAllCharacteristicsValue() {
            AllCharacteristicValues = new List<double>();
            AllCharacteristicValues.Add(WordCounter);

            if(HasStringOfWords == true) {
                AllCharacteristicValues.Add(1.0);
            }
            else {
                AllCharacteristicValues.Add(0);
            }

            foreach (KeyValuePair<string, bool> entry in hasExistingKeyword) {
                if (entry.Value == true) {
                    AllCharacteristicValues.Add(1.0);
                }
                else {
                    AllCharacteristicValues.Add(0);
                }
            }

            foreach (KeyValuePair<string, int> entry in KeywordCounter) {
                AllCharacteristicValues.Add(entry.Value);
            }

            foreach (KeyValuePair<string, int> entry in KeywordFirstPosition) {
                AllCharacteristicValues.Add(entry.Value);
            }

            foreach (KeyValuePair<string, int> entry in UserKeywordCounter) {
                AllCharacteristicValues.Add(entry.Value);
            }

            foreach (KeyValuePair<string, double> entry in KeywordFrequency) {
                AllCharacteristicValues.Add(entry.Value);
            }

        }
    }
}
