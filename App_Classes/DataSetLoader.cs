using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    /// <summary>
    /// veri setlerini dizilere yükler
    /// </summary>
    public class DataSetLoader
    {
        public double[] allData { get; set; }
        double trainSetOrani;
        public DataSetLoader()
        {

        }
        /// <summary>
        /// trainSet ve TestSet in satır sayılarını oranlayarak ayırır
        /// </summary>
        /// <param name="trainOran">trainSet in satır sayısının oranı(test set oranı otomatik hesaplanır)</param>
        public DataSetLoader(double trainOran)
        {
            trainSetOrani = trainOran;
        }
        public DataSetLoader(double[] arr)
        {
            allData = arr;
        }
        /// <summary>
        /// veri setlerini dizilere yükler.veri birimleri * ile ayrılmış olmalı.
        /// </summary>
        /// <param name="path">yüklenecek verinin bulunduğu dosya</param>
        /// <param name="satirSay">verinin toplam satır adeti</param>
        /// <param name="sutunSay">verinin toplam sütun adeti</param>
        /// <param name="seperator">veriyi ayırmak için kullanılan karakter</param>
        /// <param name="normalizer">normalize yöntemi</param>
        /// <returns>double dizi</returns>
        public double[][] LoadData(string path, int satirSay, int sutunSay, char seperator, INormalizer normalizer = null)
        {
            double[][] sonuc = new double[satirSay][];
            FileStream inputFile = new FileStream(path, FileMode.Open);
            StreamReader sr = new StreamReader(inputFile);
            string line = "";//dosyadan okuduğu tüm satır
            string[] satir = null;//string olarak parçalanmış satır
            int i = 0;
            while ((line = sr.ReadLine()) != null)
            {
                satir = line.Split(seperator);//virgülle noktayı karıştırıyor birbirine saçmalıyor
                sonuc[i] = new double[sutunSay];
                for (int j = 0; j < sutunSay; j++)
                    sonuc[i][j] = double.Parse(satir[j]);
                i++;
            }
            sr.Close(); inputFile.Close();
            if (normalizer != null)//normalize et(allData dizisini kullanarak)
            {
                for (int row = 0; row < sonuc.GetLength(0); row++)
                {
                    for (int col = 0; col < sonuc[row].Length; col++)
                    {
                        sonuc[row][col] = normalizer.Normalize(sonuc[row][col], allData);
                    }
                }
            }
            return sonuc;
        }
        /// <summary>
        /// tüm verileri içeren txt dosyasından matrislere yükler(trainSet oranı ctor ile verilmelidir)
        /// </summary>
        /// <param name="fileName">tüm veriyi içeren txt</param>
        /// <param name="trainDataSet">train dataset</param>
        /// <param name="expectedDataSet">expected dataset</param>
        /// <param name="testDataSet">test dataset</param>
        /// <param name="seperator1">verileri birbirinden ayıran ayıraç karakteri</param>
        /// <param name="seperator2">bir veri dizisinin elemanlarını birbirinden ayıran ayıraç karakteri</param>
        /// <param name="normalizer">normalize yöntemi</param>
        public void PrepareAllDataMatrices(string fileName, out double[][] trainDataSet, out double[][] expectedDataSet, out double[][] testDataSet, char seperator1, char seperator2, INormalizer normalizer = null)
        {
            //ALGO
            //allData.txt
            //allData.txt den satırları oku,seperator1 e göre ayır(ilki sayılar(train+test set),ikincisi encoding(expected set))
            //shu8ffle yap(train+test ile expected in satırları aynı şekilde shuffle olmalı List<double[][]> ShuffleData(int randomSeed, List<double[][]> multipleSourceData) ile)
            //train+test seti double[][] a çevir ve parçala(%80 %20 vb.)
            int satirSay = File.ReadLines(fileName).Count();//satır sayıları aynı,sütun sayıları değişecek
            //trainDataSet = new double[satirSay][];//şimdilik(all dataset in satır sayısının bir oranı kadar olacak)
            //testDataSet = new double[satirSay][];//şimdilik(all dataset in satır sayısının bir oranı kadar olacak)
            expectedDataSet = new double[satirSay][];
            double[][] trainAndTestDataSet = new double[satirSay][];
            //allData.txt den satırları oku,seperator1 e göre ayır(ilki sayılar(train+test set),ikincisi encoding(expected set))
            FileStream inputFile = new FileStream(fileName, FileMode.Open);
            StreamReader sr = new StreamReader(inputFile);
            string line = "";//dosyadan okuduğu tüm satır
            string[] satir = null;//satring olarak parçalanmış satır
            int i = 0;
            int mainIndex = 0;
            while ((line = sr.ReadLine()) != null)
            {
                satir = line.Split(seperator1);
                for (int j = 0; j < satir.Length; j++)
                {
                    if (j == 0)
                    {
                        trainAndTestDataSet[mainIndex] = new double[1];//sayıyı tutacak
                        trainAndTestDataSet[mainIndex][0] = Convert.ToDouble(satir[j]);
                    }
                    else if (j == 1)
                    {
                        //i = 0;
                        string[] expectedDataString = satir[j].Split(seperator2);
                        double[] temp = new double[expectedDataString.Length];
                        for (int k = 0; k < expectedDataString.Length; k++)
                        {
                            temp[k] = Convert.ToDouble(expectedDataString[k]);
                        }
                        expectedDataSet[mainIndex++] = temp;
                        //i++;mainIndex++;
                    }
                }
            }
            sr.Close(); inputFile.Close();
            //matrisleri shuffle yap
            List<double[][]> shuffledMatricesList = Utils.ShuffleData(new List<double[][]> { trainAndTestDataSet, expectedDataSet }, new Random().Next());
            trainAndTestDataSet = shuffledMatricesList[0];
            expectedDataSet = shuffledMatricesList[1];
            //trainAndTestDataSet matrisini ctor'da verilen orana göre 2 ye ayır(trainSet,testSet) ve expected'i yeni trainSet e göre oluştur
            int trainRows = (int)(satirSay * trainSetOrani);
            int testRows = satirSay - trainRows;
            int trainTestSutunSay = trainAndTestDataSet[0].Length;
            trainDataSet = new double[trainRows][];
            double[][] expectedDataSetForTrainSet = new double[trainRows][];//trainSet uzunluğunda olmalı
            testDataSet = new double[testRows][];
            //train ve expected matrisini oluştur
            for (int ind = 0; ind < trainRows; ind++)
            {
                trainDataSet[ind] = new double[trainTestSutunSay];
                expectedDataSetForTrainSet[ind] = new double[expectedDataSet[0].Length];
                for (int j = 0; j < trainTestSutunSay; j++)
                {
                    trainDataSet[ind][j] = trainAndTestDataSet[ind][j];
                }
                for (int k = 0; k < expectedDataSet[ind].Length; k++)
                {
                    expectedDataSetForTrainSet[ind][k] = expectedDataSet[ind][k];
                }
            }
            //test matrisini oluştur
            for (int ind = 0; ind < testRows; ind++)
            {
                testDataSet[ind] = new double[trainTestSutunSay];
                for (int j = 0; j < trainTestSutunSay; j++)
                    testDataSet[ind][j] = trainAndTestDataSet[ind + testRows][j];//burada hata oluşabilir
            }
            expectedDataSet = expectedDataSetForTrainSet;
        }
    }
}
