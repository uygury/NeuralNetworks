using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public class DataRepresentor
    {
        /// <summary>
        /// ağa verilecek veri setini binary gösterimi şeklinde çevirir.
        /// </summary>
        /// <param name="data">veri seti</param>
        /// <param name="bitSize">maximum bit size</param>
        /// <param name="shuffle">verinin sıralaması karıştırılacak mı</param>
        /// <returns></returns>
        public double[][] BinaryLikeRepresentor(double[][] data,int bitSize,bool shuffle)
        {
            double[][] sonuc = new double[data.Length][];
            for (int i = 0; i < data.Length; i++)
                sonuc[i] = new double[bitSize];
            for (int i = 0; i < data.Length; i++)
            {
                for (int j = 0; j < data[i].Length; j++)
                {
                    sonuc[i] = BinaryConverter(data[i][j], bitSize);
                }
            }
            if (shuffle)
            {
                sonuc = Utils.ShuffleData(sonuc, new Random().Next());
            }
            return sonuc;
        }
        /// <summary>
        /// double değeri double dizi olarak binary gösterimine çevirir
        /// </summary>
        /// <param name="d">çevrilecek değer</param>
        /// <param name="bitSize">değerin oluşturulması için gereken minimum bit sayısı</param>
        /// <returns></returns>
        public double[] BinaryConverter(double d,int bitSize)
        {
            int[] sonucInt = new int[bitSize];
            int quot = (int)d; int i = 0;
            while (quot!=0 && i<bitSize)
            {
                sonucInt[i++] = quot % 2;
                quot /= 2;
            }
            double[] sonucDouble = new double[bitSize];
            i = 0;
            for (int j = (bitSize - 1); j >= 0; j--)
                sonucDouble[i++] = (double)sonucInt[j];
            return sonucDouble;
        }
        /// <summary>
        /// veriyi binary temsiline çevirir
        /// </summary>
        /// <param name="d">çevirilecek veri</param>
        /// <param name="bitSize">değerin oluşturulması için gereken minimum bit sayısı</param>
        /// <returns></returns>
        public double[] BinaryConverterAND(double d, int bitSize)
        {           
            int[] sonucInt = new int[bitSize];
            int deger = (int)(d);
            for (int i = 0; i < bitSize; i++)
            {
                if ((deger & 1) == 1) sonucInt[i] = 1;
                else if ((deger & 1) == 0) sonucInt[i] = 0;
                deger = deger >> 1;
            }
            double[] sonucDouble = new double[bitSize];
            int j = bitSize;
            foreach (int x in sonucInt)
                sonucDouble[--j] = x;
            return sonucDouble;
        }
    }
}
