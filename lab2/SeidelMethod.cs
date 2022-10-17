using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class SeidelMethod : IMethod
    {
        private readonly double eps;
        public double[] Solve(double[,] matrice, int n)
        {
            double[] result = new double[n];
            double[] prev = new double[n];
            double norm = eps + 1;
            double[,] matrix = (double[,])matrice.Clone();

            while (norm > eps)
            {
                for (int i = 0; i < n; i++)
                {
                    prev[i] = result[i];
                }
                for (int i = 0; i < n; i++)
                {
                    double sum = 0;
                    for (int j = 0; j < i; j++)
                    {
                        sum += matrix[i, j] * result[j];
                    }
                    for (int j = i + 1; j < n; j++)
                    {
                        sum += matrix[i, j] * prev[j];
                    }
                    result[i] = (matrix[i, n] - sum) / matrix[i, i];
                }
                norm = 0;
                for (int i = 0; i < n; i++)
                {
                    norm += Math.Pow(result[i] - prev[i], 2);
                }
            }

            return result;
        }
        public SeidelMethod(double eps)
        {
            this.eps = eps;
        }
    }
}
