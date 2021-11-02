using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    /// <summary>
    /// network çıktısını istenilen değerlere yuvarlamak için kullanılır.
    /// </summary>
    public interface IOutputFilter
    {
        /// <summary>
        /// çıktıyı istenilen hata oranına göre yuvarlar
        /// </summary>
        /// <param name="val">yuvarlanacak değer</param>
        /// <param name="treshold">hata değeri</param>
        /// <returns>yuvarlanan değer</returns>
        double Filter(double val,double treshold);
    }
}
