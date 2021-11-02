using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    /// <summary>
    /// istenilen datasetleri oluşturur
    /// </summary>
    public static class DataSetBuilder
    {       
        /// <summary>
        /// min ile max arasındaki sayılardan oluşan dataset oluşturur
        /// </summary>
        /// <param name="min">alt sınır</param>
        /// <param name="max">üst sınır</param>
        /// <param name="fileName">verinin yazılacağı dosya</param>
        public static void TekCiftcDatasetBuild(double min, double max, string fileName,EncodeType type)
        {
            if (min >= max) throw new NeuralNetworkError("alt sınır üst sınırdan küçük olmalıdır!");
            FileStream outputFile = new FileStream(fileName, FileMode.Create);
            StreamWriter sWriter = new StreamWriter(outputFile);
            string satir;
            for (int i = (int)min; i <= max; i++)
            {
                satir = "";
                satir += (double)i+" ";
                if (i % 2 == 1)
                {
                    if(type==EncodeType.DummyEncoding)
                        satir += DataSetEncoders.DummyEncoding(0, 2);//tek için 1,0
                    else if(type==EncodeType.EffectsEncoding)
                        satir += DataSetEncoders.EffectsEncoding(0, 2);//tek için -1,1
                }
                else
                {
                    if (type == EncodeType.DummyEncoding)
                        satir += DataSetEncoders.DummyEncoding(1, 2);//çift için 0,1
                    else if (type == EncodeType.EffectsEncoding)
                        satir += DataSetEncoders.EffectsEncoding(1, 2);//tek için -1,1
                }
                sWriter.WriteLine(satir);
            }

            sWriter.Close(); outputFile.Close();
        }
    }
}
