using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public interface IActivationFunction
    {
        double Calculate(double d);
        List<double> Calculate(List<double> outputs);
        double CalculateDerivative(double d);
    }
}
