using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    class ManhattanMetric
    {
        public double CalculateDistance(List<double> appointedAttributes, List<double> testedAttributes) {
            double distance = 0;

            for (int i = 0; i < appointedAttributes.Count; i++) {
                distance += Math.Abs((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i)));
            }

            return distance;
        }
    }
}
