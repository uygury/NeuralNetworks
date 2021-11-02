using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public enum AllNormalizers { GaussianNormalizer, MinMaxNormalizer };
    /// <summary>
    /// Normalize ediecek yöntemlerin seçilmesini sağlar
    /// </summary>
    public class SelectNormalizer
    {
        INormalizer normalizer;
        /// <summary>
        /// Seçilen yöntemle normalize eder
        /// </summary>
        /// <param name="setToNormalize">normalize edilecek veri</param>
        /// <param name="allDataSet">tüm dataset</param>
        /// <param name="whichNormalizer">hangi normalizer</param>
        /// <returns></returns>
        public double[][] Normalize(double[][] setToNormalize,double[] allDataSet,AllNormalizers whichNormalizer)
        {
            double[][] sonuc = new double[setToNormalize.Length][];
            for (int i = 0; i < setToNormalize.Length; i++)
                sonuc[i] = new double[setToNormalize[i].Length];
            switch (whichNormalizer)
            {
                case AllNormalizers.GaussianNormalizer:
                    normalizer = new GaussianNormalizer();
                    for (int i = 0; i < setToNormalize.Length; i++)
                    {
                        for (int j = 0; j < setToNormalize[i].Length; j++)
                        {
                            sonuc[i][j] = normalizer.Normalize(setToNormalize[i][j],allDataSet);
                        }
                    }
                    break;
                case AllNormalizers.MinMaxNormalizer:
                    normalizer = new MinMaxNormalizer();
                    for (int i = 0; i < setToNormalize.Length; i++)
                    {
                        for (int j = 0; j < setToNormalize[i].Length; j++)
                        {
                            sonuc[i][j] = normalizer.Normalize(setToNormalize[i][j], allDataSet);
                        }
                    }
                    break;
                default:
                    throw new NeuralNetworkError("Unknown normalizer choosen!");
                    break;
            }
            return sonuc;
        }
        /// <summary>
        /// Seçilen yöntemle normalize eder
        /// </summary>
        /// <param name="setToDenormalize">Denormalize edilecek veri</param>
        /// <param name="allDataSet">tüm dataset</param>
        /// <param name="whichNormalizer">hangi normalizer</param>
        /// <returns></returns>
        public double[][] DeNormalize(double[][] setToDenormalize, double[] allDataSet, AllNormalizers whichNormalizer)
        {
            double[][] sonuc = new double[setToDenormalize.Length][];
            for (int i = 0; i < setToDenormalize.Length; i++)
                sonuc[i] = new double[setToDenormalize[i].Length];
            switch (whichNormalizer)
            {
                case AllNormalizers.GaussianNormalizer:
                    normalizer = new GaussianNormalizer();
                    for (int i = 0; i < setToDenormalize.Length; i++)
                    {
                        for (int j = 0; j < setToDenormalize[i].Length; j++)
                        {
                            sonuc[i][j] = normalizer.DeNormalize(setToDenormalize[i][j], allDataSet);
                        }
                    }
                    break;
                case AllNormalizers.MinMaxNormalizer:
                    normalizer = new MinMaxNormalizer();
                    for (int i = 0; i < setToDenormalize.Length; i++)
                    {
                        for (int j = 0; j < setToDenormalize[i].Length; j++)
                        {
                            sonuc[i][j] = normalizer.DeNormalize(setToDenormalize[i][j], allDataSet);
                        }
                    }
                    break;
                default:
                    throw new NeuralNetworkError("Unknown normalizer choosen!");
                    break;
            }
            return sonuc;
        }
    }
}
