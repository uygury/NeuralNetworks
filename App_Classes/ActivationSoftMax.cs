using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public class ActivationSoftMax:IActivationFunction
    {
        /// <summary>
        /// çıktı değerlerinin toplanı 1 olacak şekilde ölçekleyerek döndürür
        /// </summary>
        /// <param name="outputs">output layer'ın çıktı listesi</param>
        /// <returns>double list</returns>
        public List<double> Calculate(List<double> outputs)
        {
            double max = outputs[0];
            foreach (double d in outputs)//listedeki max ı bul
                if (d > max) max = d;
            double scaleFactor = 0.0;
            foreach (double d in outputs)
                scaleFactor += Math.Exp(d-max);//sum of exp(each val-max)
            List<double> result = new List<double>(outputs.Count);
            foreach (double d in outputs)
                result.Add(Math.Exp(d - max) / scaleFactor);
            return result;
        }

        public double Calculate(double d)
        {
            throw new NeuralNetworkError("not used with a single value");
        }

        public List<double> CalculateDerivative(List<double> outputs)
        {
            List<double>sonuc=new List<double>(outputs.Count);
            foreach (double val in outputs)
                sonuc.Add(CalculateDerivative(val));
            return sonuc;
        }

        public double CalculateDerivative(double d)
        {
            return (d*(1-d));
        }
    }
}
