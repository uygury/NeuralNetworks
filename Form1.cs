using MyNetwork.App_Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyNetwork
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            listBox1.DrawMode = DrawMode.OwnerDrawFixed;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                Layer inputLayer = new Layer("Input", 2, LayerType.Input, new ActivationSigmoid(), null);
                Layer hiddenLayer = new Layer("Hidden", 3, LayerType.Hidden, new ActivationSigmoid(), inputLayer);
                Layer outputLayer = new Layer("Output", 2, LayerType.Output, new ActivationSigmoid(), hiddenLayer);
                NeuralNetwork myNetwork = new NeuralNetwork(new List<Layer> { inputLayer, hiddenLayer, outputLayer });
                //Raporla(myNetwork);
                //---------------------------------------------------------------
                /*
                Layer inputLayer1 = new Layer("Input", 4, LayerType.Input, new ActivationSigmoid(), null);
                Layer hiddenLayer1 = new Layer("Hidden", 4, LayerType.Hidden, new ActivationSigmoid(), inputLayer1);
                Layer outputLayer1 = new Layer("Output", 1, LayerType.Output, new ActivationSigmoid(), hiddenLayer1);
                NeuralNetwork myNetwork1 = new NeuralNetwork(new List<Layer> { inputLayer1, hiddenLayer1, outputLayer1 });
                double[][] trainingSet = new double[][]
                {
                   new double[]{1.0,1.1,1.2,1.3},
                   new double[]{2.0,2.1,2.2,2.3},
                   new double[]{3.0,3.1,3.2,3.3},
                   new double[]{4.0,4.1,4.2,4.3},
                };
                double[][] expectedSet = new double[][]
                {
                   new double[]{1.0},
                   new double[]{2.0}, 
                   new double[]{3.0},
                   new double[]{4.0},
                };
                myNetwork1.NewTrain(trainingSet,expectedSet,0.1,0.1,1000,0.01);
                double[][] testSet = new double[][]
                {
                   new double[]{5.0,5.1,5.2,5.3},
                   new double[]{6.0,6.1,6.2,6.3},
                   new double[]{7.0,7.1,7.2,7.3},
                   new double[]{8.0,8.1,8.2,8.3},
                };
                foreach (double[] inputPattern in testSet)
                    foreach (double d in myNetwork1.ComputeOutputs(inputPattern.ToList()))
                        listBox1.Items.Add(d);
                
                */
                //XOR----------------------
                /*
                
                */
                //2 ile çarpma--------------------------------------------
                /*
                Layer inputLayer4 = new Layer("Input", 2, LayerType.Input, new ActivationSigmoid(), null);
                Layer hiddenLayer4 = new Layer("Hidden", 5, LayerType.Hidden, new ActivationSigmoid(), inputLayer4);
                Layer outputLayer4 = new Layer("Output", 1, LayerType.Output, new ActivationSigmoid(), hiddenLayer4);
                NeuralNetwork myNetwork4 = new NeuralNetwork(new List<Layer> { inputLayer4, hiddenLayer4, outputLayer4 });
                //girdi seti x/10 ile NORMALİZE edildi
                double[][] trainingSet3 = new double[][]
                {
                   new double[]{ 0.2, 0.2},
                   new double[]{ 0.2, 0.4},
                   new double[]{ 0.2, 0.6},
                   new double[]{ 0.2, 0.8},
                   new double[]{ 0.2, 1.0},
                };
                //x/100 ile normalize edildi
                double[][] expectedSet3 = new double[][]
                {
                   new double[]{0.04},
                   new double[]{0.08},
                   new double[]{0.12},
                   new double[]{0.16},
                   new double[]{0.20},
                };
                myNetwork4.NewTrain(trainingSet3, expectedSet3, 0.1, 0.01, 100000, 0.000001);//0.05, 0.1, 100000, 0.000001
                double[][] testSet3 = new double[][]
                {
                   new double[]{ 0.2, 0.1},
                   new double[]{ 0.2, 0.3},
                   new double[]{ 0.2, 0.5},
                   new double[]{ 0.2, 0.7},
                   new double[]{ 0.2, 0.9},
                };

                listBox1.Items.Add("2 ile çarpma(x/10 normalizasyon)--------------------------");
                foreach (double[] inputPattern in testSet3)
                    foreach (double d in myNetwork4.ComputeOutputs(inputPattern.ToList()))
                        listBox1.Items.Add(d * 100);
                listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
                listBox1.Items.Add("last error:" + NetworkReport.LastError);
                */
                //normalize ile deneme
                /*
                
                
                */
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }

        }
        private void button1_Click(object sender, EventArgs e)//ağları yükle ve raporla
        {
            NeuralNetwork nn2ileCarpma = new NeuralNetwork("2ileCarpma.net");
            Raporla(nn2ileCarpma, true);
            NeuralNetwork nn5ileCarpma = new NeuralNetwork("5ileCarpma.net");
            Raporla(nn5ileCarpma, true);
            //TODO bumlara ComputeOutputs ile denemeler yap doğru çalışıyorlar mı diye
        }

        private void btnTekCift_Click(object sender, EventArgs e)
        {
            //Tek çift---------------------------------------
            Layer inputLayer2 = new Layer("Input", 1, LayerType.Input, new ActivationSigmoid(), null);
            Layer hiddenLayer2 = new Layer("Hidden", 3, LayerType.Hidden, new ActivationSigmoid(), inputLayer2);
            Layer outputLayer2 = new Layer("Output", 2, LayerType.Output, new ActivationSigmoid(), hiddenLayer2);
            NeuralNetwork myNetwork2 = new NeuralNetwork(new List<Layer> { inputLayer2, hiddenLayer2, outputLayer2 });
            MinMaxNormalizer minMaxNorm = new MinMaxNormalizer();
            GaussianNormalizer gNorm = new GaussianNormalizer();
            RoundFilter roundFilter = new RoundFilter();
            double[] DataSet = { 0.0, 1.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0, 11.0, 12.0, 13.0, 14.0, 15.0, 16.0, 17.0, 18.0, 19.0, 20.0 };
            double[][] trainingSet1 = new double[][]
            {
                   new double[]{1.0},//tek-çift
                   new double[]{18.0},
                   new double[]{9.0},
                   new double[]{14.0},
                   new double[]{5.0},
                   new double[]{12.0},
                   new double[]{7.0},
                   new double[]{16.0},
                   new double[]{3.0},
                   new double[]{10.0},
            };
            double[][] expectedSet1 = new double[][]
            {
                   new double[]{1,0},//tek
                   new double[]{0,1},//çift
                   new double[]{1,0},
                   new double[]{0,1},
                   new double[]{1,0},
                   new double[]{0,1},
                   new double[]{1,0},
                   new double[]{0,1},
                   new double[]{1,0},
                   new double[]{0,1},
            };

            double[][] testSet1 = new double[][]
            {
                   new double[]{2.0},
                   new double[]{4.0},
                   new double[]{6.0},
                   new double[]{8.0},
                   new double[]{11.0},
            };
            double[][] testSet2 = new double[][]
            {
                new double[]{1.0},
                new double[]{3.0},
                new double[]{5.0},
                new double[]{7.0},
                new double[]{9.0},
                new double[]{2.0},
                new double[]{4.0},
                new double[]{6.0},
                new double[]{8.0},
            };
            //normalizasyonlar---------------------------
            //TODO sonuçalrı denormalize ETMEDEN al,expected normalize etmeden sigmoid ile çalışıyor
            //hepsini normalize edip hidden'ı sadece sigmoid,diğerlerini linear yapınca tesr sınıflama yapıyor
            //1. yöntem--------------------------------
            #region 1. yöntem
            double[][] trainingSet1Normalized = gNorm.Normalize(trainingSet1);
            double[][] testSet1Normalized = gNorm.Normalize(testSet1);
            double[][] testSet2Normalized = gNorm.Normalize(testSet2);
            myNetwork2.NewTrain(trainingSet1Normalized, expectedSet1, 0.1, 0.7, 100000, 0.00001);
            #region sonuçları listele
            listBox1.Items.Add("1. yöntem:------------------");
            string satir = "";
            listBox1.Items.Add("TestSet1:-------:");
            foreach (double[] inputPattern in testSet1Normalized)
            {
                satir = "";
                foreach (double d in myNetwork2.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(d, 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet1)----------------:");
            foreach (double[] inputPattern in testSet1Normalized)
            {
                myNetwork2.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork2.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(n.Output);
                }
            }
            listBox1.Items.Add("TestSet2:-------:");
            foreach (double[] inputPattern in testSet2Normalized)
            {
                satir = "";
                foreach (double d in myNetwork2.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(d, 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet2)----------------:");

            foreach (double[] inputPattern in testSet2Normalized)
            {
                myNetwork2.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork2.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(n.Output);
                }
            }
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
            #endregion
            #endregion
            //END 1. yöntem----------------------------------
            //2. yöntem(all dataset e göre norm)
            #region 2. yöntem
            SelectNormalizer normalizerSec = new SelectNormalizer();
            trainingSet1 = normalizerSec.Normalize(trainingSet1, DataSet, AllNormalizers.GaussianNormalizer);
            //expectedSet1 = normalizerSec.Normalize(expectedSet1, DataSet, AllNormalizers.GaussianNormalizer);
            testSet1 = normalizerSec.Normalize(testSet1, DataSet, AllNormalizers.GaussianNormalizer);
            testSet2 = normalizerSec.Normalize(testSet2, DataSet, AllNormalizers.GaussianNormalizer);
            myNetwork2.NewTrain(trainingSet1, expectedSet1, 0.1, 0.3, 10000, 0.0001);
            #region sonuçları listele
            listBox1.Items.Add("2. yöntem:------------------");
            listBox1.Items.Add("TestSet1:-------:");
            foreach (double[] inputPattern in testSet1Normalized)
            {
                satir = "";
                foreach (double d in myNetwork2.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(d, 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet1)----------------:");
            foreach (double[] inputPattern in testSet1Normalized)
            {
                myNetwork2.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork2.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(n.Output);
                }
            }
            listBox1.Items.Add("TestSet2:-------:");
            foreach (double[] inputPattern in testSet2Normalized)
            {
                satir = "";
                foreach (double d in myNetwork2.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(d, 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet2)----------------:");

            foreach (double[] inputPattern in testSet2Normalized)
            {
                myNetwork2.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork2.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(n.Output);
                }
            }
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
            #endregion
            #endregion
            //3. yöntem hepsi normalize acLinear ile
            #region 3. yöntem
            Layer inputLayer3 = new Layer("Input", 1, LayerType.Input, new ActivationLinear(), null);
            Layer hiddenLayer3 = new Layer("Hidden", 3, LayerType.Hidden, new ActivationSigmoid(), inputLayer3);
            Layer outputLayer3 = new Layer("Output", 2, LayerType.Output, new ActivationLinear(), hiddenLayer3);
            NeuralNetwork myNetwork3 = new NeuralNetwork(new List<Layer> { inputLayer3, hiddenLayer3, outputLayer3 });
            expectedSet1 = normalizerSec.Normalize(expectedSet1, DataSet, AllNormalizers.GaussianNormalizer);//diğerleri yukarıda normalize edildi
            myNetwork3.NewTrain(trainingSet1, expectedSet1, 0.1, 0.6, 10000, 0.0001);
            #region sonuçları listele
            listBox1.Items.Add("3. yöntem:------------------");
            listBox1.Items.Add("TestSet1:-------:");
            foreach (double[] inputPattern in testSet1)
            {
                satir = "";
                foreach (double d in myNetwork3.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(gNorm.DeNormalize(d, DataSet), 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet1)----------------:");
            foreach (double[] inputPattern in testSet1)
            {
                myNetwork3.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork3.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(gNorm.DeNormalize(n.Output, DataSet));
                }
            }
            listBox1.Items.Add("TestSet2:-------:");
            foreach (double[] inputPattern in testSet2)
            {
                satir = "";
                foreach (double d in myNetwork3.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(gNorm.DeNormalize(d, DataSet), 0.15).ToString() + "       ";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("çıktı nöronlarının değerleri(testSet2)----------------:");

            foreach (double[] inputPattern in testSet2)
            {
                myNetwork3.ComputeOutputs(inputPattern.ToList());
                foreach (Neuron n in myNetwork3.LayerList.Last().Neurons)
                {
                    listBox1.Items.Add(gNorm.DeNormalize(n.Output, DataSet));
                }
            }
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
            #endregion
            #endregion
        }

        private void x2Normalizasyonla_Click(object sender, EventArgs e)
        {
            Layer inputLayer5 = new Layer("Input", 2, LayerType.Input, new ActivationLinear(), null);
            Layer hiddenLayer5 = new Layer("Hidden", 5, LayerType.Hidden, new ActivationSigmoid(), inputLayer5);
            Layer outputLayer5 = new Layer("Output", 1, LayerType.Output, new ActivationLinear(), hiddenLayer5);//dikkat linear()
            NeuralNetwork myNetwork5 = new NeuralNetwork(new List<Layer> { inputLayer5, hiddenLayer5, outputLayer5 });
            listBox1.Items.Clear();
            listBox1.Items.Add("2 ile çarpma(MinMax or Gauss normalizasyon)--------------------------:");
            //normalized setleri oluştur
            MinMaxNormalizer minMaxNorm = new MinMaxNormalizer();
            GaussianNormalizer gNorm = new GaussianNormalizer();
            RoundFilter roundFilter = new RoundFilter();
            double[] DataSet = { 0.0, 2.0, 3.0, 4.0, 5.0, 6.0, 7.0, 8.0, 9.0, 10.0 };
            double[][] trainingSet4 = new double[][] {//[6][2]
                    new double[2],//2x0
                    new double[2],//2x2
                    new double[2],//2x4
                    new double[2],//2x6
                    new double[2],//2x8
                    new double[2] //2x10
                };
            double[][] expectedSet4 = new double[][] {//[6][1]
                    new double[1],//0
                    new double[1],//4
                    new double[1],//8
                    new double[1],//12
                    new double[1],//16
                    new double[1],//20
                };
            double[][] testSet4 = new double[][] {
                    new double[2],//2x1
                    new double[2],//2x3
                    new double[2],//2x5
                    new double[2],//2x7
                    new double[2] //2x9
                };
            for (int i = 0; i < 6; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    if (j == 0)
                    {
                        trainingSet4[i][j] = gNorm.Normalize(2.0, DataSet);
                        if (i != 5) testSet4[i][j] = gNorm.Normalize(2.0, DataSet);
                    }
                    else
                    {
                        trainingSet4[i][j] = gNorm.Normalize(((double)i) * 2, DataSet);
                        if (i != 5) testSet4[i][j] = gNorm.Normalize((((double)i + 1) * 2) - 1, DataSet);
                    }
                }
            }
            expectedSet4[0][0] = gNorm.Normalize(0, DataSet);
            expectedSet4[1][0] = gNorm.Normalize(4, DataSet);
            expectedSet4[2][0] = gNorm.Normalize(8, DataSet);
            expectedSet4[3][0] = gNorm.Normalize(12, DataSet);
            expectedSet4[4][0] = gNorm.Normalize(16, DataSet);
            expectedSet4[5][0] = gNorm.Normalize(20, DataSet);
            //setleri göster
            listBox1.Items.Add("training set(after normalized):");
            string satir = "";
            for (int i = 0; i < 6; i++)
            {
                satir = "";
                for (int j = 0; j < 2; j++) satir += trainingSet4[i][j] + ",";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("expected set(after normalized):");
            for (int i = 0; i < 6; i++)
            {
                satir = "";
                for (int j = 0; j < 1; j++) satir += expectedSet4[i][j] + ",";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("test set(after normalized):");
            for (int i = 0; i < 5; i++)
            {
                satir = "";
                for (int j = 0; j < 2; j++) satir += testSet4[i][j] + ",";
                listBox1.Items.Add(satir);
            }
            myNetwork5.NewTrain(trainingSet4, expectedSet4, 0.1, 0.9, 100000, 0.000001);//0.1, 0.9, 100000 , 0.000001
            myNetwork5.SaveNetwork("2ileCarpma.net");//ağı kaydet
            listBox1.Items.Add("ağın test seti için çıktıları:");
            foreach (double[] inputPattern in testSet4)
                foreach (double d in myNetwork5.ComputeOutputs(inputPattern.ToList()))
                    listBox1.Items.Add(roundFilter.Filter(gNorm.DeNormalize(d, DataSet), 0.05));
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
        }

        private void btnx5Normalizasyonla_Click(object sender, EventArgs e)
        {
            //dataset loader ile 5 ile çarpma
            listBox1.Items.Clear();
            listBox1.Items.Add("5 ile çarpma(dataset loader ile)--------------------------:");
            //allDataSet normalizasyonda kullanılacak
            DataSetLoader dSetLoader = new DataSetLoader();//tüm veriyi normalizasyonda kullanılacak 1D diziye yüklemek için
            double[] allDataSet5 = Utils.Transform2DArrayTo1D(dSetLoader.LoadData(@"C:\data files\besle carpma\alldata.txt", 22, 1, '*', null));//normaliz etmeden yükle
            DataSetLoader dSetLoader1 = new DataSetLoader(allDataSet5);
            GaussianNormalizer gNorm = new GaussianNormalizer();
            RoundFilter roundFilter = new RoundFilter();
            string satir = "";
            double[][] trainset5ler = dSetLoader1.LoadData(@"C:\data files\besle carpma\train set.txt", 6, 2, '*', gNorm);//normalize ederek yükle
            double[][] testset5ler = dSetLoader1.LoadData(@"C:\data files\besle carpma\test set.txt", 6, 2, '*', gNorm);
            double[][] expectedset5ler = dSetLoader1.LoadData(@"C:\data files\besle carpma\expected set.txt", 6, 1, '*', gNorm);
            //setleri göster
            #region setleri göster
            listBox1.Items.Add("all data set:");
            foreach (double d in allDataSet5)
                listBox1.Items.Add(d);
            listBox1.Items.Add("train set:");
            foreach (double[] inputPattern in trainset5ler)
            {
                satir = "";
                foreach (double d in inputPattern)
                    satir += d + "-";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("test set:");
            foreach (double[] inputPattern in testset5ler)
            {
                satir = "";
                foreach (double d in inputPattern)
                    satir += d + "-";
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("expected set:");
            foreach (double[] inputPattern in expectedset5ler)
            {
                satir = "";
                foreach (double d in inputPattern)
                    satir += d + "-";
                listBox1.Items.Add(satir);
            }
            #endregion
            Layer inputLayer5ler = new Layer("Input", 2, LayerType.Input, new ActivationLinear(), null);
            Layer hiddenLayer5ler = new Layer("Hidden", 5, LayerType.Hidden, new ActivationSigmoid(), inputLayer5ler);
            Layer outputLayer5ler = new Layer("Output", 1, LayerType.Output, new ActivationLinear(), hiddenLayer5ler);//dikkat linear()
            NeuralNetwork myNetwork5ler = new NeuralNetwork(new List<Layer> { inputLayer5ler, hiddenLayer5ler, outputLayer5ler });
            myNetwork5ler.NewTrain(trainset5ler, expectedset5ler, 0.1, 0.3, 100000, 0.000001);//0.1, 0.9, 100000 , 0.000001
            listBox1.Items.Add("ağın test seti için çıktıları:");
            foreach (double[] inputPattern in testset5ler)
                foreach (double d in myNetwork5ler.ComputeOutputs(inputPattern.ToList()))
                    listBox1.Items.Add(roundFilter.Filter(gNorm.DeNormalize(d, allDataSet5), 0.05));
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
            myNetwork5ler.SaveNetwork("5ileCarpma.net");//ağı kaydet
        }

        private void btnXOR_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
            RoundFilter rFilt = new RoundFilter();
            Layer inputLayer3 = new Layer("Input", 2, LayerType.Input, new ActivationSigmoid(), null);
            Layer hiddenLayer3 = new Layer("Hidden", 3, LayerType.Hidden, new ActivationSigmoid(), inputLayer3);
            Layer outputLayer3 = new Layer("Output", 1, LayerType.Output, new ActivationSigmoid(), hiddenLayer3);
            NeuralNetwork myNetwork3 = new NeuralNetwork(new List<Layer> { inputLayer3, hiddenLayer3, outputLayer3 });
            double[][] trainingSet2 = new double[][]
            {
                   new double[]{0.0,0.0},
                   new double[]{1.0,0.0},
                   new double[]{0.0,1.0},
                   new double[]{1.0,1.0},
            };
            double[][] expectedSet2 = new double[][]
            {
                   new double[]{0.0},
                   new double[]{1.0},
                   new double[]{1.0},
                   new double[]{0.0},
            };
            myNetwork3.NewTrain(trainingSet2, expectedSet2, 0.3, 0.1, 10000, 0.01);//0.05, 0.01, 10000, 0.01
            myNetwork3.SaveNetwork("XOR.net");
            double[][] testSet2 = new double[][]
            {
                   new double[]{0.0,0.0},
                   new double[]{1.0,0.0},
                   new double[]{0.0,1.0},
                   new double[]{1.0,1.0},
            };
            listBox1.Items.Add("XOR--------------------------");
            foreach (double[] inputPattern in testSet2)
                foreach (double d in myNetwork3.ComputeOutputs(inputPattern.ToList()))
                    listBox1.Items.Add(rFilt.Filter(d, 0.05));//0.05 hatayla yuvarla
            listBox1.Items.Add("toplam epoch:" + NetworkReport.TotalEpoch);
            listBox1.Items.Add("last error:" + NetworkReport.LastError);
        }

        private void Raporla(NeuralNetwork netW, bool yukleneniRaporla = false)
        {
            if (yukleneniRaporla == false)
                netW.ComputeOutputs(new List<double> { 1.0, 2.0 });

            //listBox1.Items.Clear();
            listBox1.Items.Add("Ağ:" + netW.Id.ToString());
            listBox1.Items.Add("Layerlar:-----------------");
            foreach (Layer layer in netW.LayerList)
            {
                listBox1.Items.Add("    Adı:" + layer.Name);
                listBox1.Items.Add("    Id:" + layer.Id);
                listBox1.Items.Add("    Tipi:" + layer.Type.ToString());
                listBox1.Items.Add("    Nöron Sayısı:" + layer.NeuronCount);
                listBox1.Items.Add("    Nöronları:------------------");
                int nrnIndex = 1;
                foreach (Neuron nrn in layer.Neurons)
                {
                    listBox1.Items.Add("        Id:" + nrn.Id);
                    listBox1.Items.Add("        Bulunduğu Layer:" + nrn.InWhichLayer.Name);
                    listBox1.Items.Add("        Bias:" + nrn.Bias);
                    listBox1.Items.Add("        Inputs:");
                    foreach (double dbl in nrn.Inputs)
                        listBox1.Items.Add("        " + dbl);
                    listBox1.Items.Add("        Input Weights:");
                    foreach (double dbl in nrn.InputWeights)
                        listBox1.Items.Add("        " + dbl);
                    listBox1.Items.Add("        Output of neuron[" + nrnIndex++ + "]:");
                    listBox1.Items.Add("        " + nrn.Output);
                    listBox1.Items.Add("        ---------------------------");
                }
                if (layer.IsInput) listBox1.Items.Add("   IsInput=true");
                else if (layer.IsHidden) listBox1.Items.Add("   IsHidden=true");
                else if (layer.IsOutput) listBox1.Items.Add("   IsOutput=true");
                if (layer.Previous != null) listBox1.Items.Add("   Önceki Layer:" + layer.Previous.Name);
                else listBox1.Items.Add("   Önceki Layer:YOK");
                if (layer.Next != null) listBox1.Items.Add("   Sonraki Layer:" + layer.Next.Name);
                else listBox1.Items.Add("   Sonraki Layer:YOK");
                listBox1.Items.Add("-------------------------");
            }
            listBox1.Items.Add("Ağ Çıktısı:------------------");
            foreach (double d in netW.ShowNetworkOutput())
            {
                listBox1.Items.Add(d);
            }
        }

        private void listBox1_DrawItem(object sender, DrawItemEventArgs e)
        {
            Font f = e.Font;
            Font f1 = e.Font;
            /*if (e.Index == 0|| e.Index == 1||e.Index == 2)*/ //bold yapılacak satırın indexi
            f = new Font(e.Font, FontStyle.Bold);
            f1 = new Font(e.Font, FontStyle.Regular);
            e.DrawBackground();
            //e.Graphics.DrawString(((ListBox)(sender)).Items[e.Index].ToString(), f, new SolidBrush(e.ForeColor), e.Bounds);
            string satir = ((ListBox)(sender)).Items[e.Index].ToString();

            if (satir.Contains(":"))
            {
                string baslik = satir.Substring(0, satir.IndexOf(":") + 1);
                string bilgi = satir.Substring(satir.IndexOf(":") + 1);
                e.Graphics.DrawString(baslik, f, new SolidBrush(e.ForeColor), e.Bounds);
                e.Graphics.DrawString(bilgi, f1, new SolidBrush(e.ForeColor), new Rectangle(e.Bounds.Left + 150, e.Bounds.Top, e.Bounds.Width, e.Bounds.Height));
            }
            else
                e.Graphics.DrawString(((ListBox)(sender)).Items[e.Index].ToString(), f1, new SolidBrush(e.ForeColor), e.Bounds);

            e.DrawFocusRectangle();
        }

        private void btnTekCiftBinary_Click(object sender, EventArgs e)
        {
            DataRepresentor dRep = new DataRepresentor();
            //testler
            #region testler
            /*
            listBox1.Items.Clear();
            
            double[] x = new double[32];
            string satir = "";
            for (int i = 0; i < 10; i++)
            {
                satir = "";
                x = dRep.BinaryConverter((double)i, 32);
                foreach (double d in x)
                    satir += d;
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("XOR:---------------------------");
            for (int i = 0; i < 10; i++)
            {
                satir = "";
                x = dRep.BinaryConverterAND((double)i, 32);
                foreach (double d in x)
                    satir += d;
                listBox1.Items.Add(satir);
            }
            listBox1.Items.Add("Binary Convert All Data:---------------");
            double[][] testData = new double[][] {new double[]{0}, new double[] { 1}, new double[] { 2}, new double[] {3 }, new double[] { 4}, new double[] {5 }, new double[] {6 }, new double[] {7 }, new double[] {8 }, new double[] {9 } };
            double[][] returnedData = dRep.BinaryLikeRepresentor(testData, 32, true);
            satir = "";
            foreach (double[] arr in returnedData)
            {
                satir = "";
                foreach (double d in arr)
                {
                    satir += d;
                }
                listBox1.Items.Add(satir);
            }
            */
            //her matrisi aynı sekans kullanarak senkronize bir şekilde karıştırma
            /*
            List<double[][]> testList = new List<double[][]> {
                new double[][]{ new double[] { 1,1 },new double[] { 2,2 },new double[] { 3,3 },new double[] { 4,4 },new double[] { 5,5 },new double[] { 6,6 } },
                new double[][]{ new double[] { 1,1 },new double[] { 2,2 },new double[] { 3,3 },new double[] { 4,4 },new double[] { 5,5 },new double[] { 6,6 } },
                new double[][]{ new double[] { 1,1 },new double[] { 2,2 },new double[] { 3,3 },new double[] { 4,4 },new double[] { 5,5 },new double[] { 6,6 } },
                new double[][]{ new double[] { 1,1 },new double[] { 2,2 },new double[] { 3,3 },new double[] { 4,4 },new double[] { 5,5 },new double[] { 6,6 } },
                new double[][]{ new double[] { 1,1 },new double[] { 2,2 },new double[] { 3,3 },new double[] { 4,4 },new double[] { 5,5 },new double[] { 6,6 } },
            };
            testList = Utils.ShuffleData(new Random().Next(), testList);
            string satir = "";
            foreach (double[][] matrix in testList)
            {
                foreach (double[] arr in matrix)
                {
                    satir = "";
                    foreach (double d in arr)
                    {
                        satir += d + ",";
                    }
                    listBox1.Items.Add(satir);
                }
                listBox1.Items.Add("------");
            }
            */
            #endregion
            double[][] trainSet, testSet, expectedSet;
            RoundFilter roundFilter = new RoundFilter();
            new DataSetLoader(0.80).PrepareAllDataMatrices(@"C:\data files\TekCift\tekCift_16Bit_AllData.txt", out trainSet, out expectedSet , out testSet,' ',',',null);
            double[][] trainSetBinary = dRep.BinaryLikeRepresentor(trainSet, 16, false);
            double[][] testSetBinary = dRep.BinaryLikeRepresentor(testSet, 16, false);
            Layer inputLayer = new Layer("input", 16, LayerType.Input, new ActivationLinear(), null);
            Layer hiddenLayer = new Layer("hidden", 3, LayerType.Hidden, new ActivationSigmoid(), inputLayer);
            Layer outputLayer = new Layer("output", 2, LayerType.Output, new ActivationSigmoid(), hiddenLayer);
            NeuralNetwork tekCiftNetwork = new NeuralNetwork(new List<Layer> { inputLayer,hiddenLayer,outputLayer });
            tekCiftNetwork.NewTrain(trainSetBinary,expectedSet,0.1,0.5,1000,0.001);
            tekCiftNetwork.SaveNetwork("tekCiftBelirleyici.net");
            #region sonuçalrı listele
            listBox1.Items.Clear();
            listBox1.Items.Add("tek sayı=10   çift sayı=01 ile sembolize edilmektedir.");
            string satir = "";
            int i = 0;
            foreach (double[] inputPattern in testSetBinary)
            {
                satir = "";
                satir += testSet[i++][0] + ":";
                foreach (double output in tekCiftNetwork.ComputeOutputs(inputPattern.ToList()))
                    satir += roundFilter.Filter(output,0.05);
                listBox1.Items.Add(satir);
            }
            #endregion
        }

        private void btnTekCiftDatasetOlustur_Click(object sender, EventArgs e)
        {
            DataSetBuilder.TekCiftcDatasetBuild(1, 100000, "tekCiftAllData.txt",EncodeType.DummyEncoding);
            DataSetBuilder.TekCiftcDatasetBuild(1, 100000, @"C:\data files\TekCift\tekCiftAllData.txt",EncodeType.DummyEncoding);
            DataSetBuilder.TekCiftcDatasetBuild(0, 65535, @"C:\data files\TekCift\tekCift_16Bit_AllData.txt",EncodeType.DummyEncoding);
        }
    }
}
