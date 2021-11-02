using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public class AllDataSet
    {
        public double[][] TrainSet { get; set; }
        public double[][] ExpectedSet { get; set; }
        public double[][] TestSet { get; set; }
    }
}
