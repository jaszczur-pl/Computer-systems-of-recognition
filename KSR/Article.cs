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
        public Dictionary<string, int> Vector { get; set; }
        public string Text { get; set; }

        public int WordCounter { get; set; }
        public int StringCounter { get; set; }
        public Dictionary<string, bool> hasExistingKeyword { get; set; }
        public Dictionary<string, bool> hasExistingUserKeyword { get; set; }
        public Dictionary<string, int> KeywordCounter { get; set; }
        public Dictionary<string, int> UserKeywordCounter { get; set; }
        public Dictionary<string, double> KeywordFrequency { get; set; }
    }
}
