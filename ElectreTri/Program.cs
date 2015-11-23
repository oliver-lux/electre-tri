using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreTri
{
    class Program
    {
        static void Main(string[] args)
        {
            var matReader = new ArrayReader("matdata.mat");
            var alg = new Algorithm();

            var result = alg.Solve(
                matReader.A,
                matReader.PP,
                matReader.q,
                matReader.p,
                matReader.v,
                matReader.w,
                matReader.t);

            Console.WriteLine("Rank");
            PrintMatrix(result.Rank);

            Console.WriteLine("Table");
            PrintMatrix(result.Table);

            Console.ReadKey();
        }

        private static void PrintMatrix(double[][] matrix)
        {
            for (var i = 0; i < matrix.Length; i++)
            {
                var row = matrix[i];
                for (var j = 0; j < row.Length; j++)
                    Console.Write("{0}\t", row[j]);

                Console.WriteLine();
            }
        }
    }
}
