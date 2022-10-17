using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    
    internal class JacobiMethod : IMethod
    {
        private readonly double eps;
        public double[] Solve(double[,] matrice, int n)
        {
            double[,] matrix = (double[,])matrice.Clone();
            double[] result = new double[n];
            double[] prev = new double[n];
            double norm = eps + 1;

            while (norm > eps)
            {
                for (int i = 0; i < n; i++)
                {
                    prev[i] = matrix[i, n];
                    for (int j = 0; j < n; j++)
                    {
                        if (i != j)
                        {
                            prev[i] -= matrix[i, j] * result[j];
                        }
                    }
                    prev[i] /= matrix[i, i];
                }
                norm = Math.Abs(result[0] - prev[0]);
                for (int i = 0; i < n; i++)
                {
                    if (Math.Abs(result[i] - prev[i]) > norm)
                    {
                        norm = Math.Abs(result[i] - prev[i]);
                    }
                    result[i] = prev[i];
                }
            }

            return result;
        }
        public JacobiMethod(double eps)
        {
            this.eps = eps;
        }
    }
}
