using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNetwork.App_Classes
{
    public interface INeuron
    {
        Guid Id { get; }
        double Output { get; }
        double Bias { get; set; }//bias nörun ın özelliği galiba
        double Gradient { get; set; }
        double BiasDelta { get; set; }
        List<double> InputWeights { get; set; }
        List<double> Deltas { get; set; }
        //List<double> OutputWeights { get; set; }
        IActivationFunction ActivationFunction { get; set; }
    }
}
