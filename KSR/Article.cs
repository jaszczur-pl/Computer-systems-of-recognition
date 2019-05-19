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

        public List<string> Words { get; set; }
        public List<double> AllCharacteristicValues { get; set; }
    }
}
