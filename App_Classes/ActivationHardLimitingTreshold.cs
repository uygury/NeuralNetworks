using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    class ActivationHardLimitingTreshold : IActivationFunction
    {
        public double Calculate(double d)
        {
            return d < 0 ? 0 : 1;
        }

        public List<double> Calculate(List<double> outputs)
        {
            throw new NotImplementedException();
        }

        public double CalculateDerivative(double d)
        {
            throw new NeuralNetworkError("Can't use the hard limiting activation function where a derivative is required.");
        }
    }
}
