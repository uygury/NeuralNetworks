using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    [Serializable]
    public class Neuron : INeuron
    {
        public Guid Id { get; private set; }
        public double Output { get; set; }
        public double Bias { get; set; }//bias nöron ın özelliği galiba
        public double Gradient { get; set; }
        public double BiasDelta { get; set; }
        public Layer InWhichLayer { get; set; }
        public List<double> Inputs { get; set; }
        public List<double> InputWeights { get; set; }
        public List<double> Deltas { get; set; }
        //public List<double> OutputWeights { get ; set ; }
        public IActivationFunction ActivationFunction { get; set; }
        public Neuron()
        {
            Id = Guid.NewGuid();
            //Inputs = new List<double>();//layer ctor'da ayarlanıyor
            //InputWeights = new List<double>();//OutputWeights = new List<double>();
        }
        public Neuron(IActivationFunction acF) : this()
        {
            ActivationFunction = acF;
            Bias = Utils.Randomize(-1, 1);
        }
        public double CalculateOutput()
        {
            if (ActivationFunction == null) throw new NeuralNetworkError("Activation function not defined");
            /*#1
            if (InWhichLayer.Type == LayerType.Input) return ActivationFunction.Calculate(WeightedSumFunction(Inputs));
            //return ActivationFunction.Calculate(WeightedSumFunction(InWhichLayer.Previous.Outputs[Id]));
            //yada
            //burada feedforward işlemi otomatik yapılıyor gibi
            List<double> outputsOfPreviousLayer = new List<double>();
            foreach (Neuron nrn in InWhichLayer.Previous.Neurons)
            {
                outputsOfPreviousLayer.Add(nrn.Output);
            }
            return ActivationFunction.Calculate(WeightedSumFunction(outputsOfPreviousLayer));
            */
            //#2bu daha doğru galiba(inputs 0 olduğu için her layerdaki nöron birbiriyle aynı çıktıyı veriyor(ACF(0+bias)))
            //CalculateOutput() çağırılmadan önce bir önceki layer'ın output ları bir sonrakinin inputlarına ATANMIŞ olmalı(feedforward)
            return ActivationFunction.Calculate(WeightedSumFunction(Inputs));
        }
        private double WeightedSumFunction(List<double> inputs)
        {
            double top = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                top += inputs[i] * InputWeights[i];
            }
            return (top + Bias);
        }
    }
}
