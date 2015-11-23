using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using csmatio.types;
using csmatio.io;

namespace ElectreTri
{
    class ArrayReader
    {
        public double[][] A { get; set;}
        double[][] PP { get; set; }
        double[] q { get; set; }
        double[] p { get; set; }
        double[] v { get; set; }
        double[] w { get; set; }
        double t { get; set; }

        ArrayReader(string fileName)
        {
            try
            {
                MatFileReader mfr = new MatFileReader("C:\\Studia\\Optymalizacja Wielokryterialna\\el3ow\\el3ow\\matdata.mat");
                A = ((MLDouble)(mfr.GetMLArray("A"))).GetArray();
                PP = ((MLDouble)(mfr.GetMLArray("PP"))).GetArray();

            }
            catch (System.IO.IOException)
            {
                throw new MatlabIOException("Cannot read file");
            }

            

        }

        


    }
}
