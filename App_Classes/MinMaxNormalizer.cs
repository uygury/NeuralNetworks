using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    /// <summary>
    /// girdi ve çıktı setindeki değerleri MinMax yöntemine göre normalize-denormalize etmek için kullanılır.
    /// </summary>
    public class MinMaxNormalizer : INormalizer
    {
        /// <summary>
        /// normalize edilmiş değeri orjinal değere çevirir
        /// </summary>
        /// <param name="val">denormalize edilecek değer</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>denormalize edilmiş değer</returns>
        public double DeNormalize(double val, double[] array)
        {
            double max = array[0];
            double min = array[0];
            foreach (double d in array)
            {
                if (d < min) min = d;
                if (d > max) max = d;
            }
            return val * (max - min) + min;
        }
        /// <summary>
        /// değerleri normalize eder
        /// </summary>
        /// <param name="val">normalize edilecek değer</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>normalize edilmiş değer</returns>
        public double Normalize(double val, double[] array)
        {
            double max = array[0];
            double min = array[0];
            foreach (double d in array)
            {
                if (d < min) min = d;
                if (d > max) max = d;
            }
            if (max - min == 0.0)//bad array to normalize
                return 0.5;
            return (val - min) / (max - min);
        }
        /// <summary>
        /// değerleri istenilen aralık içinde normalize eder
        /// </summary>
        /// <param name="val">normalize edilecek değer</param>
        /// <param name="minLimit">normalizasyon için alt limit</param>
        /// <param name="maxLimit">normalizasyon için üst limit</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>normalize edilmiş değer</returns>
        public double NormalizeInRange(double val, double minLimit, double maxLimit, double[] array)
        {
            double max = array[0];
            double min = array[0];
            foreach (double d in array)
            {
                if (d < min) min = d;
                if (d > max) max = d;
            }
            if (max - min == 0.0)//bad array to normalize
                return 0.5;
            return ((maxLimit - minLimit) * ((val - min) / (max - min))) + minLimit;
        }
        /// <summary>
        /// değerleri istenilen aralık içinde denormalize eder
        /// </summary>
        /// <param name="val">denormalize edilecek değer</param>
        /// <param name="minLimit"de>normalizasyon için alt limit</param>
        /// <param name="maxLimit">denormalizasyon için üst limit</param>
        /// <param name="array">değeri içeren veri seti</param>
        /// <returns>normalize edilmiş değer</returns>
        public double DeNormalizeInRange(double val, double minLimit, double maxLimit, double[] array)
        {
            double max = array[0];
            double min = array[0];
            foreach (double d in array)
            {
                if (d < min) min = d;
                if (d > max) max = d;
            }
            return ((val - minLimit) * (max - min) / (maxLimit - minLimit)) + min;
        }

        public void Normalize(double[][] data,int column)//veriyi bir kolona göre normalize etmek için
        {
            double min = data[0][column];
            double max = data[0][column];
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i][column] < min) min = data[i][column];
                if (data[i][column] > max) max = data[i][column];
            }
            if (max - min == 0)//bad array
            {
                for (int i = 0; i < data.Length; i++)
                    data[i][column] = 0.5;
                return;
            }
            for (int i = 0; i < data.Length; i++)
                data[i][column] = (data[i][column] - min) / (max - min);
        }
    }
}
