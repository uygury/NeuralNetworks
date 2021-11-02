using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    class NeuralNetworkError : Exception
    {
        public NeuralNetworkError(string msg) : base(msg)
        {

        }
    }
}
