using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    class MinMaxMetric : IMetric
    {
        //metryka działa podobnie jak uliczna z tym, że odrzucana jest najmniejsza i największa wartość odległości pomiędzy pojedynczymi cechami

        public double CalculateDistance(List<double> appointedAttributes, List<double> testedAttributes) {
            double distance = 0;
            List<double> distancesList = new List<double>();

            for (int i = 0; i < appointedAttributes.Count; i++) {
                distancesList.Add(Math.Abs((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i))));
                distance += Math.Abs((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i)));
            }

            double max = distancesList.Max();
            double min = distancesList.Min();

            distance = distance - max - min;

            return distance;
        }
    }
}
