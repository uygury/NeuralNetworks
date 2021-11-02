using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public class StepActivationFunction : IActivationFunction
    {
        private double _treshold;
        public StepActivationFunction(double treshold)
        {
            _treshold = treshold;
        }
        public double Calculate(double d)
        {
            return Convert.ToDouble(d > _treshold);
        }

        public List<double> Calculate(List<double> outputs)
        {
            throw new NotImplementedException();
        }

        public double CalculateDerivative(double d)
        {
            throw new NeuralNetworkError("Can't use the step activation function where a derivative is required.");
        }        
    }
}
