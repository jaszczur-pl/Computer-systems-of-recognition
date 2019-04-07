using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    class EuclideanMetric:IMetric
    {
        public double CalculateDistance(List<double> appointedAttributes, List<double> testedAttributes) {
            double distance = 0;

            for (int i = 0; i < appointedAttributes.Count; i++) {
                distance += Math.Pow((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i)), 2);
            }

            distance = Math.Sqrt(distance);

            return distance;
        }
    }
}
