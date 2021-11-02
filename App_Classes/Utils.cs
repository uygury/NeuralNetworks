using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    class Utils
    {
        static internal double Randomize(double min, double max)
        {
            System.Threading.Thread.Sleep(20);
            Random rnd = new Random();
            return (rnd.NextDouble() * (max - min)) + min;
        }
        static internal double WeightedSumFunction(List<double> inputs, List<double> weights, double bias)
        {
            double top = 0;
            for (int i = 0; i < inputs.Count; i++)
            {
                top += inputs[i] * weights[i];
            }
            return top + bias;
        }
        /// <summary>
        /// 2D matrisi 1D diziye çevirir
        /// </summary>
        /// <param name="array">dönüştürülecek matris</param>
        /// <returns></returns>
        internal static double[] Transform2DArrayTo1D(double[][] array)
        {
            double[] sonuc = new double[array.Length*array[0].Length];//TODO jagged array to 1D dizi indexleme
            int k = 0;
            for (int i = 0; i < array.GetLength(0); i++)//satır say
            {
                for (int j = 0; j < array[i].Length; j++)//sütun say
                {
                    sonuc[k++] = array[i][j];
                }
            }
            return sonuc;
        }
        /// <summary>
        /// veri setini Fisher-Yates algoritmasını kullanarak karıştırır
        /// </summary>
        /// <param name="sourceData">karıştırılacak veri seti</param>
        /// <param name="randomSeed">seed for random</param>
        /// <returns>karıştırılan veri seti</returns>
        internal static double[][] ShuffleData(double[][] sourceData,int randomSeed)
        {
            Random rnd = new Random(randomSeed);
            double[][] copy = new double[sourceData.Length][];
            for (int i = 0; i < copy.Length; i++)
                copy[i] = sourceData[i];
            int r;double[] temp;
            for (int i = 0; i < copy.Length; i++)
            {
                r = rnd.Next(i, copy.Length);
                temp = copy[r];
                copy[r] = copy[i];
                copy[i] = temp;
            }
            return copy;
        }
        /// <summary>
        /// birden fazla matris içeren veri setlerini senkronize olarak(indexler karşılıklı olarak aynı şekilde) karıştırır(Length ler aynı olmalı)
        /// </summary>
        /// <param name="randomSeed">seed</param>
        /// <param name="multipleSourceData">double[][] listesi</param>
        /// <returns></returns>
        internal static List<double[][]> ShuffleData(List<double[][]> multipleSourceData,int randomSeed)
        {
            Random rnd = new Random(randomSeed);
            int listLength = multipleSourceData.Count;
            List<double[][]> copyList = new List<double[][]>(listLength);
            //herbirini farklı karıştırır.DÜŞÜN!!!
            List<int> shuffleSequence = new List<int>();
            int satirSay = multipleSourceData[0].Length;
            for (int i = 0; i < satirSay; i++)//rasgele ssatır numaraları oluştur
                shuffleSequence.Add(rnd.Next(i, satirSay));

            foreach (double[][] matrix in multipleSourceData)
            {
                double[][] copy = new double[matrix.Length][];//listedeki matrislerin kopyasını oluştur
                for (int i = 0; i < copy.Length; i++)
                    copy[i] = matrix[i];
                int r;double[] temp;
                for (int i = 0; i < copy.Length; i++)
                {
                    r = shuffleSequence[i];//sekanstaki satir numaralarana göre matrisleri karıştır
                    temp = copy[r];
                    copy[r] = copy[i];
                    copy[i] = temp;
                }
                copyList.Add(copy);
            }
            return copyList;  
        }
    }
}
