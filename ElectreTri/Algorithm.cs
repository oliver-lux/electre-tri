using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ElectreTri
{
    class Algorithm
    {
        public Result Solve(double[][] A, double[][] PP, double[] q, double[] p, double[] v, double[] w, double t)
        {
            var result = PrepareResult(A, PP);
            var aColNumber = GetColNumber(A);
            var ppColNumber = GetColNumber(PP);
            var aRowNumber = GetRowNumber(A);

            var c = GetCube(aColNumber, ppColNumber, aRowNumber);
            var d = GetCube(aColNumber, ppColNumber, aRowNumber);

            for (int ind = 0; ind < aRowNumber; ind++)
            {
                var perf = GetMatrix(aRowNumber, ppColNumber);

                for (int i = 0; i < aColNumber; i++)
                {
                    for (int j = 0; j < ppColNumber; j++)
                    {
                        perf[i][j] = PP[ind][j] - A[ind][i];

                        //if (perf[i][j] < q[ind])
                    }
                }   
            }

            return result;
        }

        private double[][][] GetCube(int x, int y, int z)
        {
            var result = new double[x][][];
            for (var i = 0; i < x; i++)
                result[i] = GetMatrix(y, z);

            return result;
        }

        private int GetRowNumber(double[][] doubles)
        {
            return doubles.Length;
        }

        private Result PrepareResult(double[][] A, double[][] pp)
        {
            var result = new Result
            {
                Rank = GetMatrix(GetColNumber(A), GetColNumber(pp)),
                Cs = GetMatrix(GetColNumber(A), GetColNumber(pp))
            };
            return result;
        }

        private double[][] GetMatrix(int rows, int columns)
        {
            var result = new double[rows][];

            for (var i = 0; i < columns; i++)
                result[i] = new double[columns];

            return result;
        }

        private int GetColNumber(double[][] matrix)
        {
            return matrix.First().Length;
        }
    }

    internal class Result
    {
        public double[][] Rank { get; set; }
        public double[][] Cs { get; set; }
    }
}
