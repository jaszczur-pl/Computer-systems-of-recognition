using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    class MinMax2Metric: IMetric
    {
        //Metryka pobiera najmniejsza i największa wartość odległości pomiędzy pojedynczymi cechami i zwraca ich różnicę
        public double CalculateDistance(List<double> appointedAttributes, List<double> testedAttributes) {
            List<double> distancesList = new List<double>();

            for (int i = 0; i < appointedAttributes.Count; i++) {
                distancesList.Add(Math.Abs((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i))));
            }

            double max = distancesList.Max();
            double min = distancesList.Min();

            return max - min;
        }
    }
}
