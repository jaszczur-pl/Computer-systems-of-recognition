using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    class MaximumMetric:IMetric
    {
        public double CalculateDistance(List<double> appointedAttributes, List<double> testedAttributes) {
            double distance = 0;
            double maximum = 0;

            for (int i = 0; i < appointedAttributes.Count; i++) {
                distance = Math.Abs((appointedAttributes.ElementAt(i) - testedAttributes.ElementAt(i)));

                if(distance > maximum) {
                    maximum = distance;
                }
            }

            return maximum;
        }
    }
}
