using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    [Serializable]
    class ActivationLinear : IActivationFunction
    {
        public double Calculate(double d)
        {
            return d;
        }

        public List<double> Calculate(List<double> outputs)
        {
            throw new NotImplementedException();
        }

        public double CalculateDerivative(double d)
        {
            return 1;
        }
    }
}
