using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public interface INormalizer
    {
        double Normalize(double val, double[] array);
        double DeNormalize(double val, double[] array);
    }
}
