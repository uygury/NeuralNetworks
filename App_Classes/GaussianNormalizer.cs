using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    /// <summary>
    /// girdi ve çıktı setindeki değerleri Gauss yöntemine göre normalize-denormalize etmek için kullanılır.
    /// </summary>
    public class GaussianNormalizer : INormalizer
    {
        /// <summary>
        /// normalize edilmiş değeri orjinal değere çevirir
        /// </summary>
        /// <param name="val">denormalize edilecek değer</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>denormalize edilmiş değer</returns>
        public double DeNormalize(double val, double[] array)
        {
            double toplam = 0.0;
            foreach (double d in array)
                toplam += d;
            double ortalama = toplam / array.Length;
            double karelerToplami = 0.0;
            foreach (double d in array)
                karelerToplami += (d - ortalama) * (d - ortalama);
            double standartSapma = Math.Sqrt(karelerToplami / array.Length);
            return (val * standartSapma) + ortalama;
        }
        /// <summary>
        /// değerleri normalize eder
        /// </summary>
        /// <param name="val">normalize edilecek değer</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>normalize edilmiş değer</returns>
        public double Normalize(double val, double[] array)
        {
            double toplam = 0.0;
            foreach (double d in array)
                toplam += d;
            double ortalama = toplam / array.Length;
            double karelerToplami = 0.0;
            foreach (double d in array)
                karelerToplami += (d - ortalama) * (d - ortalama);
            double standartSapma = Math.Sqrt(karelerToplami/array.Length);
            return (val - ortalama) / standartSapma;
        }
        /// <summary>
        /// veriyi KENDİ İÇİNDE normalize eder
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns></returns>
        public double[][] Normalize(double[][] matrix)//veriyi kendi içinde normalize etmek için(orjinal veri değişmez)
        {
            double[][] copy = new double[matrix.Length][];//kopya oluştur
            for (int i = 0; i < matrix.Length; i++)
                copy[i] = new double[matrix[i].Length];
            double toplam = 0.0;
            foreach (double[] arr in matrix)
                foreach (double d in arr)
                    toplam += d;
            double ortalama = toplam / (matrix.Length * matrix[0].Length);//i*j
            double karelerToplami = 0.0;
            foreach (double[] arr in matrix)
                foreach (double d in arr)
                    karelerToplami += (d - ortalama) * (d - ortalama);
            double standartSapma = Math.Sqrt(karelerToplami / (matrix.Length * matrix[0].Length));
            for (int i = 0; i < copy.Length; i++)
            {
                for (int j = 0; j < copy[i].Length; j++)
                {
                    copy[i][j] = (matrix[i][j] - ortalama) / standartSapma;
                }
            }
            return copy;
        }
        public double[][] DeNormalize(double[][] matrix)
        {
            double[][] copy = new double[matrix.Length][];//kopya oluştur
            for (int i = 0; i < matrix.Length; i++)
                copy[i] = new double[matrix[i].Length];
            double toplam = 0.0;
            foreach (double[] arr in matrix)
                foreach (double d in arr)
                    toplam += d;
            double ortalama = toplam / (matrix.Length * matrix[0].Length);//i*j
            double karelerToplami = 0.0;
            foreach (double[] arr in matrix)
                foreach (double d in arr)
                    karelerToplami += (d - ortalama) * (d - ortalama);
            double standartSapma = Math.Sqrt(karelerToplami / (matrix.Length * matrix[0].Length));
            for (int i = 0; i < copy.Length; i++)
            {
                for (int j = 0; j < copy[i].Length; j++)
                {
                    copy[i][j] = (matrix[i][j] * standartSapma) + ortalama;
                }
            }
            return copy;
        }

        public void Normalize(double[][] data,int column)//bir kolondaki veriyi normalize etmekiçin
        {
            double sum = 0;
            for (int i = 0; i < data.Length; i++)
                sum += data[i][column];
            double ort = sum / data.Length;
            double karelerTopl = 0;
            for (int i = 0; i < data.Length; i++)
                karelerTopl += (data[i][column] - ort) * (data[i][column] - ort);
            double standartSapma = Math.Sqrt(karelerTopl / data.Length);
            for (int i = 0; i < data.Length; i++)
                data[i][column] = (data[i][column] - ort) / standartSapma;
        }
    }
}
