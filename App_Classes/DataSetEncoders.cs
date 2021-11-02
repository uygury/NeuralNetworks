using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public enum EncodeType { DummyEncoding, EffectsEncoding };
    /// <summary>
    /// ağa verilecek veriler için gerekli kodlama işlemlerini yapar
    /// </summary>
    public static class DataSetEncoders
    {
        
        /// <summary>
        /// non-numeric X-Data nın kodlanmasında kullanılır.(-1 ve 1 değerleriyle)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static string EffectsEncoding(int index,int N)
        {
            //a,b,c için 1,0  0,1 -1,-1
            if (N == 2)
            {
                if (index == 0) return "-1";
                else if (index == 1) return "1"; 
            }
            int[] values = new int[N - 1];
            if (index == N - 1)//son değerin kodlanmasında tüm değerler -1
            {
                for (int i = 0; i < values.Length; i++)
                    values[i] = -1;
            }
            else
            {
                values[index] = 1;//int dizi deklarasyonunda diğer değerler zaten 0
            }
            string s = values[0].ToString();
            for (int i = 1; i < values.Length; i++)
                s += "," + values[i];
            return s;
        }
        /// <summary>
        /// non-numeric Y-Data nın kodlanmasında kullanılır.(0 ve 1 değerleriyle)
        /// </summary>
        /// <param name="index"></param>
        /// <param name="N"></param>
        /// <returns></returns>
        public static string DummyEncoding(int index, int N)
        {
            //a,b,c için 1,0,0  0,1,0  0,0,1
            int[] values = new int[N];
            values[index] = 1;
            string s = values[0].ToString();
            for (int i = 1; i < values.Length; i++)
                s += "," + values[i];
            return s;
        }
    }
}
