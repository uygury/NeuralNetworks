using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public enum LayerType { Input, Hidden, Output };
    [Serializable]
    public class Layer
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public LayerType Type { get; set; }
        List<Neuron> _neuronList;
        public List<Neuron> Neurons { get { return _neuronList; } set { _neuronList = value; } }
        public int NeuronCount { get { return _neuronList.Count; } }
        public bool IsInput { get { return Previous == null; } }
        public bool IsOutput { get { return Next == null; } }
        public bool IsHidden { get { return (Next != null) && (Previous != null); } }
        public Layer Previous { get; private set; }
        public Layer Next { get; internal set; }
        public List<double> DataToInputLayer { get; set; }
        public List<double> DataFromOutputLayer { get; set; }
        //public Dictionary<Guid,List<double>> Inputs { get; set; }//hangi nörondan gelen inputlar
        //public Dictionary<Guid, List<double>> Outputs { get; set; }//hangi nörona giden outputlar
        /// <summary>
        /// yeni bir layer yaratır
        /// </summary>
        /// <param name="name">layer adı</param>
        /// <param name="neuronCount">layerdaki nöron sayısı</param>
        /// <param name="type">layer'ın tipi(input,hidden,output)</param>
        /// <param name="acF">layerdaki nöronların kullanacağı aktivasyon fonksiyonu</param>
        /// <param name="previousLayer">bir önceki layer(input layer için null)</param>
        public Layer(string name, int neuronCount, LayerType type, IActivationFunction acF, Layer previousLayer = null)
        {
            //tanımlama örnek:
            //input=new Layer("input",3,LayerType.Input,acf,null);
            //hidden=new Layer("hidden",3,LayerType.Hidden,acf,input);
            //output=new Layer("output",3,LayerType.Output,acf,hidden);
            //bu şekilde previous layer atanmış olur
            Id = Guid.NewGuid();
            Name = name;
            Type = type;
            Neurons = new List<Neuron>(neuronCount);
            //Inputs = new Dictionary<Guid, List<double>>();
            //Outputs = new Dictionary<Guid, List<double>>();
            if (type == LayerType.Input) DataToInputLayer = new List<double>(neuronCount);
            else if (type == LayerType.Output) DataFromOutputLayer = new List<double>(neuronCount);
            else if (type == LayerType.Hidden) DataToInputLayer = DataFromOutputLayer = null;
            Previous = Next = null;//next network constructorda set ediliyor
            if (previousLayer != null) Previous = previousLayer;
            if (type == LayerType.Input)//input layer ise...
            {
                for (int i = 0; i < neuronCount; i++)
                {
                    Neuron n = new Neuron(acF);
                    n.Bias = 0.0;//input nöronlarda bias etkisiz olmalı
                    n.Inputs = new List<double>(1);//input nöronların inputs.count 1 olacak
                    n.InputWeights = new List<double> { 1.0 };//input nöronlarının weight ler 1 olmalı
                    n.Inputs.Add(0);//input layerın nöronlarının inputları 1 adet
                    //n.InputWeights.Add(1);//input layer weights 1 olacak                   
                    n.InWhichLayer = this;
                    _neuronList.Add(n);
                }
            }
            else if (type == LayerType.Hidden || type == LayerType.Output)//ara katmanlar ise...
            {
                for (int i = 0; i < neuronCount; i++)
                {
                    Neuron n = new Neuron(acF);
                    n.Inputs = new List<double>(Previous.NeuronCount);
                    n.InputWeights = new List<double>(Previous.NeuronCount);
                    n.Deltas = new List<double>(Previous.NeuronCount);
                    for (int j = 0; j < Previous.NeuronCount; j++)//nöronlarının input weight lerini randomize
                    {
                        //n.Inputs[j]=0.0;//başlangıçta inputlar 0
                        //n.InputWeights[j]=Utils.Randomize(-1.0, 1.0);
                        n.Inputs.Add(0.0);
                        n.InputWeights.Add(Utils.Randomize(-1.0, 1.0));
                        n.Deltas.Add(0.0);
                    }
                    n.InWhichLayer = this;
                    _neuronList.Add(n);
                }
            }
        }
    }
}
