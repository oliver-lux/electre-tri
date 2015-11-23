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

                        if (perf[i][j] < q[ind])
                            c[i][j][ind] = 1;
                        else if (perf[i][j] > p[ind])
                            c[i][j][ind] = 0;
                        else
                            c[i][j][ind] = 1 - (q[ind] - perf[i][j]) / (q[ind] - p[ind]);

                        if (perf[i][j] < p[ind])
                            d[i][j][ind] = 0;
                        else if (perf[i][j] > v[ind])
                            d[i][j][ind] = 1;
                        else
                            d[i][j][ind] = (perf[i][j] - p[ind]) / (v[ind] - p[ind]);
                    }
                }
            }

            var W = GetCube(aColNumber, ppColNumber, aRowNumber);
            for (int ind = 0; ind < aRowNumber; ind++)
                for (int i = 0; i < aColNumber; i++)
                    for (int j = 0; j < ppColNumber; j++)
                        W[i][j][ind] = w[ind];


            double[][] CW = GetMatrix(aColNumber, ppColNumber);
            double[][] DW = GetMatrix(aColNumber, ppColNumber);

            for (int i = 0; i < aColNumber; i++)
                for (int j = 0; j < ppColNumber; j++)
                    for (int ind = 0; ind < aRowNumber; ind++)
                    {
                        CW[i][j] += c[i][j][ind] * W[i][j][ind] / 100;
                        DW[i][j] += d[i][j][ind] * W[i][j][ind] / 100;
                    }


            var CS = GetMatrix(aColNumber, ppColNumber);
            for (int i = 0; i < aColNumber; i++)
            {
                for (int j = 0; j < ppColNumber; j++)
                {
                    CS[i][j] = CW[i][j];
                    for (int ind = 0; ind < aRowNumber; ind++)
                    {
                        if (d[i][j][ind] > CW[i][j])
                        {
                            CS[i][j] = CS[i][j] * (1 - d[i][j][ind] / (1 - CW[i][j]));
                        }
                    }
                }
            }

            double[][] prof = GetMatrix(aColNumber, ppColNumber);
            for (int i = 0; i < aColNumber; i++)
            {
                for (int j = 0; j < ppColNumber; j++)
                {
                    if (CS[i][j] > t)
                        prof[i][j] = 1;
                    else 
                        prof[i][j] = 0;
                }
            }

            result.Rank = prof;
            result.Table = CS;

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
                Table = GetMatrix(GetColNumber(A), GetColNumber(pp))
            };
            return result;
        }

        private double[][] GetMatrix(int rows, int columns)
        {
            var result = new double[rows][];

            for (var i = 0; i < rows; i++)
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
        public double[][] Table { get; set; }
    }
}
