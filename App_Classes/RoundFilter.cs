using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public class RoundFilter : IOutputFilter
    {
        public double Filter(double val,double treshold)
        {
            double rounded= Math.Round(val);
            if ((Math.Abs(val - rounded)) <= treshold) return rounded;
            else return val;
        }
    }
}
