using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    [Serializable]
    class ActivationSigmoid : IActivationFunction
    {
        public double Calculate(double d)
        {
            if (d < -45.0) return 0.0;
            else if (d > 45.0) return 1.0;
            return 1.0 / (1 + Math.Exp(-1 * d));//1/1+(e^-d)
        }

        public List<double> Calculate(List<double> outputs)
        {
            throw new NotImplementedException();
        }

        public double CalculateDerivative(double d)
        {
            return d * (1.0 - d);
        }
    }
}
