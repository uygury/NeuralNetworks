using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    [Serializable]
    public class NeuralNetwork
    {
        public Guid Id { get; private set; }
        private double GlobalError { get; set; }
        private int SetSize { get; set; }
        private LinkedList<Layer> _layerList;
        /// <summary>
        /// Layer listesini sıralı olarak tutar.
        /// </summary>
        public LinkedList<Layer> LayerList
        {
            get { return _layerList; }
            set { _layerList = value; }
        }
        /// <summary>
        /// networuk çıktısını tutar
        /// </summary>
        List<double> networkOut;
        /// <summary>
        /// Network'un Input Layer'ı
        /// </summary>
        public Layer InputLayer { get; set; }
        /// <summary>
        /// Network'un Output Layer'ı
        /// </summary>
        public Layer OutputLayer { get; set; }
        /// <summary>
        /// Dosyadan ağ parametrelerini yükleyerek yeni bir ağ oluşturur
        /// </summary>
        /// <param name="fileName">ağın yükleneceği dosya adı</param>
        public NeuralNetwork(string fileName)
        {
            NeuralNetwork nn = LoadNetwork(fileName);
            Id = nn.Id; GlobalError = nn.GlobalError; SetSize = nn.SetSize;
            LayerList = nn.LayerList; networkOut = nn.networkOut;
            InputLayer = nn.InputLayer; OutputLayer = nn.OutputLayer;
            //TODO foreach ler ile layer ve nöronların parametrelerini yükle
        }
        /// <summary>
        /// yeni bir neural network tanımlar
        /// </summary>
        /// <param name="layerlar">networkteki layerların listesi</param>
        public NeuralNetwork(List<Layer> layerlar)
        {
            Id = Guid.NewGuid();
            InputLayer = OutputLayer = null;
            LayerList = new LinkedList<Layer>();
            int i = 0;
            foreach (Layer lyr in layerlar)
            {
                if (lyr.Type == LayerType.Input)
                {
                    lyr.Next = layerlar[++i];
                    LayerList.AddFirst(lyr);
                    InputLayer = lyr;
                }
                else if (lyr.Type == LayerType.Hidden)
                {
                    lyr.Next = layerlar[++i];
                    LinkedListNode<Layer> lastNode = LayerList.Last;//hiddenlar input-output arasına tanımlanma sırasına göre eklenir
                    LayerList.AddAfter(lastNode, lyr);
                }
                else if (lyr.Type == LayerType.Output)
                {
                    lyr.Next = null;
                    LayerList.AddLast(lyr);
                    OutputLayer = lyr;
                    networkOut = new List<double>(lyr.NeuronCount);
                    for (int j = 0; j < lyr.NeuronCount; j++) networkOut.Add(0.0);//indexleyebilmek için initialise et
                }
            }
        }
        /// <summary>
        /// Network'e verilen input pattern'ın çıktısını hesaplar
        /// </summary>
        /// <param name="inputToNetwork">Network'e verilen input pattern</param>
        /// <returns></returns>
        public List<double> ComputeOutputs(List<double>inputToNetwork)
        {
            foreach (Layer lyr in LayerList)
            {
                if (lyr.Type==LayerType.Input)
                {
                    lyr.DataToInputLayer.Clear();
                    inputToNetwork.ForEach(x=>lyr.DataToInputLayer.Add(x));
                    int i = 0;
                    foreach (Neuron inputNeuron in lyr.Neurons)
                    {
                        inputNeuron.Inputs[0] = inputToNetwork[i++];//girdiyi ver
                        inputNeuron.Output=inputNeuron.CalculateOutput();//çıktıyı hesapla
                        foreach (Neuron nextLayerNeuron in lyr.Next.Neurons)
                        {
                            //sonraki layerın nöronlarının inputs listinin indexi önceki layer nöronuyla aynı olan indexine outputu ver
                            nextLayerNeuron.Inputs[lyr.Neurons.IndexOf(inputNeuron)] = inputNeuron.Output;
                        }
                    }
                }
                else if (lyr.Type == LayerType.Hidden)
                {
                    foreach (Neuron hiddenNeuron in lyr.Neurons)
                    {
                        hiddenNeuron.Output=hiddenNeuron.CalculateOutput();
                        foreach (Neuron nextLayerNeuron in lyr.Next.Neurons)
                            nextLayerNeuron.Inputs[lyr.Neurons.IndexOf(hiddenNeuron)] = hiddenNeuron.Output;
                    }
                }
                else if (lyr.Type == LayerType.Output)
                {
                    foreach (Neuron outputNeuron in lyr.Neurons)
                    {
                        outputNeuron.Output=outputNeuron.CalculateOutput();
                        //networkOut.Add(outputNeuron.Output);
                        networkOut[lyr.Neurons.IndexOf(outputNeuron)] = outputNeuron.Output;
                    }
                    lyr.DataFromOutputLayer.Clear();
                    networkOut.ForEach(x => lyr.DataFromOutputLayer.Add(x));
                }
            }
            //-------------------------------
            return networkOut;
        }
        /// <summary>
        /// ağa girdi değerlerini vererek eğitir
        /// </summary>
        /// <param name="inputPattern">ağa verilen girdi değerleri</param>
        /// <param name="expectedPattern">ağdan beklenilen çıktı değerleri</param>
        /// <param name="learningRate">learning rate</param>
        /// <param name="momentum">momentum</param>
        /// <param name="maxEpoch">maximum iterasyon sayısı</param>
        /// <param name="errorTreshold">global hata eşik değeri</param>
        public void NewTrain(double[][] trainingSet,double[][]expectedSet, double learningRate, double momentum, int maxEpoch, double errorTreshold)
        {
            int patternIndex = 0; int epoch = 0; double calculatedError = double.MaxValue;
            List<double> networkOut;
            do
            {
                networkOut = ComputeOutputs(trainingSet[patternIndex].ToList());//feedforward
                calculatedError = UpdateError(networkOut, expectedSet[patternIndex].ToList());//global error hesapla
                //backpropogation
                for (Layer lyr = LayerList.Last(); lyr.Type != LayerType.Input; lyr = lyr.Previous)
                {
                    if (lyr.Type == LayerType.Output)//compute gradients of output nodes
                    {
                        foreach (Neuron outputNeuron in lyr.Neurons)
                            outputNeuron.Gradient = outputNeuron.ActivationFunction.CalculateDerivative(outputNeuron.Output) * (expectedSet[patternIndex].ToList()[lyr.Neurons.IndexOf(outputNeuron)] - outputNeuron.Output);//eski hali:expectedPattern[lyr.Neurons.IndexOf(outputNeuron)]
                    }
                    else if (lyr.Type == LayerType.Hidden)//compute gradients of hidden nodes
                    {
                        double sum;
                        foreach (Neuron hiddenNeuron in lyr.Neurons)
                        {
                            sum = 0.0;
                            foreach (Neuron outputNeuron in LayerList.Last().Neurons)
                                sum += outputNeuron.Gradient * outputNeuron.InputWeights[lyr.Neurons.IndexOf(hiddenNeuron)];
                            hiddenNeuron.Gradient = hiddenNeuron.ActivationFunction.CalculateDerivative(hiddenNeuron.Output) * sum;
                        }
                    }
                }
                //update all weights and biases
                int i; double newDelta; double momentumFactor;
                for (Layer lyr = LayerList.Last(); lyr.Type != LayerType.Input; lyr = lyr.Previous)
                {
                    if (lyr.Type == LayerType.Output)//update output layer weights and biases
                    {
                        foreach (Neuron outputNeuron in lyr.Neurons)
                        {
                            foreach (Neuron hiddenNeuron in lyr.Previous.Neurons)//weights
                            {
                                i = lyr.Previous.Neurons.IndexOf(hiddenNeuron);
                                newDelta = learningRate * outputNeuron.Gradient * hiddenNeuron.Output;
                                momentumFactor = momentum * outputNeuron.Deltas[i];
                                outputNeuron.InputWeights[i] += (newDelta + momentumFactor);
                                outputNeuron.Deltas[i] = newDelta;
                            }
                            //biases
                            newDelta = learningRate * outputNeuron.Gradient;
                            momentumFactor = momentum * outputNeuron.BiasDelta;
                            outputNeuron.Bias += (newDelta + momentumFactor);
                            outputNeuron.BiasDelta = newDelta;
                        }
                    }
                    else if (lyr.Type == LayerType.Hidden)//update hidden layer weights and biases
                    {
                        foreach (Neuron hiddenNeuron in lyr.Neurons)//weights
                        {
                            foreach (Neuron previousNeuron in lyr.Previous.Neurons)
                            {
                                i = lyr.Previous.Neurons.IndexOf(previousNeuron);
                                newDelta = learningRate * hiddenNeuron.Gradient * previousNeuron.Output;
                                momentumFactor = momentum * hiddenNeuron.Deltas[i];
                                hiddenNeuron.InputWeights[i] += (newDelta + momentumFactor);
                                hiddenNeuron.Deltas[i] = newDelta;
                            }
                            //biases
                            newDelta = learningRate * hiddenNeuron.Gradient;
                            momentumFactor = momentum * hiddenNeuron.BiasDelta;
                            hiddenNeuron.Bias += (newDelta + momentumFactor);
                            hiddenNeuron.BiasDelta = newDelta;
                        }
                    }
                }
                epoch++;
                patternIndex = epoch % trainingSet.Length/*GetLength(0)*/;//pattern index=epoch % trainingSet satır sayısı
            } while (epoch < maxEpoch || calculatedError > errorTreshold);
            NetworkReport.TotalEpoch = epoch;
            NetworkReport.LastError = calculatedError;
        }
        /// <summary>
        /// ağın global hatasını hesaplar(least mean square)
        /// </summary>
        /// <param name="computed">hesaplanan çıktı değerleri</param>
        /// <param name="desired">beklenen çıktı değerleri</param>
        /// <returns></returns>
        private double UpdateError(List<double> computed, List<double> desired)
        {
            GlobalError = 0.0; SetSize = 0; double delta = 0.0;
            for (int i = 0; i < computed.Count; i++)
            {
                delta = desired[i] - computed[i];
                GlobalError += delta * delta;
                SetSize += desired.Count;
            }
            return Math.Sqrt(GlobalError / SetSize);
        }
        /// <summary>
        /// Network'un çıktısını döndürür
        /// </summary>
        /// <returns></returns>
        public List<double> ShowNetworkOutput()
        {
            List<double> sonuc = new List<double>();
            foreach (Neuron nrn in LayerList.Last().Neurons)//output layer'ın nöronlarında...
                sonuc.Add(nrn.Output);
            return sonuc;
        }
        /// <summary>
        /// Ağın tüm parametrelerini kaydeder
        /// </summary>
        /// <param name="fileName">ağın kaydedileceği dosya adı</param>
        public void SaveNetwork(string fileName)
        {
            //network'ü ni serialise et kaydet
            BinaryFormatter binFor = new BinaryFormatter();
            FileStream fStream = new FileStream(fileName, FileMode.Create, FileAccess.Write);
            binFor.Serialize(fStream, this);
            fStream.Close();
        }

        public NeuralNetwork LoadNetwork(string fileName)
        {
            BinaryFormatter binfor = new BinaryFormatter();
            FileStream fStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
            NeuralNetwork NN = (NeuralNetwork)binfor.Deserialize(fStream);
            fStream.Close();
            return NN;
        }
    }
}
