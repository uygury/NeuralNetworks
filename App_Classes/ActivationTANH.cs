using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    class ActivationTANH : IActivationFunction
    {
        public double Calculate(double d)
        {
            if (d < -45.0) return 0.0;
            else if (d > 45.0) return 1.0;
            return (Math.Exp(d * 2.0) - 1.0) / (Math.Exp(d * 2.0) + 1);
        }

        public List<double> Calculate(List<double> outputs)
        {
            throw new NotImplementedException();
        }

        public double CalculateDerivative(double d)
        {
            return (1.0 - Math.Pow(Calculate(d), 2.0));
        }
    }
}
