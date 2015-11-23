using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                double[][] Q = ((MLDouble)(mfr.GetMLArray("q"))).GetArray();
                q = new double[Q.Length];
                for (int i = 0; i < Q.Length; i++)
                {
                    q[i] = Q[i][0];
                }

                double[][] P = ((MLDouble)mfr.GetMLArray("p")).GetArray();
                double[] p = new double[P.Length];
                for (int i = 0; i < P.Length; i++)
                {
                    p[i] = P[i][0];
                }
                double[][] V = ((MLDouble)mfr.GetMLArray("v")).GetArray();
                double[] v = new double[V.Length];
                for (int i = 0; i < V.Length; i++)
                {
                    v[i] = V[i][0];
                }

                double[][] WW = ((MLDouble)mfr.GetMLArray("w")).GetArray();
                double[] w = new double[WW.Length];
                for (int i = 0; i < WW.Length; i++)
                {
                    w[i] = WW[i][0];
                }
            }
            catch (System.IO.IOException)
            {
                throw new MatlabIOException("Cannot read file");
            }

            

        }

        


    }
}
