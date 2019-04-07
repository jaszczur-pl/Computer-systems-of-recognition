using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KSR.Metrics
{
    interface IMetric
    {
        double CalculateDistance(List<double> a, List<double> b);
    }
}
