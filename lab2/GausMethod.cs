using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal class GausMethod : IMethod
    {
        public double[] Solve(double[,] matrice, int n)
        {
            double[,] matrix = (double[,])matrice.Clone();
            double[] result = new double[n];
            for (int i = 0; i < n - 1; i++)
            {
                for (int k = i + 1; k < n; k++)
                {
                    double coeff = (matrix[k,i] / matrix[i,i]);
                    for (int j = 0; j <= n; j++)
                    {
                        matrix[k,j] -= coeff * matrix[i,j];
                    }
                }
            }
            
            for (int i = n - 1; i >= 0; i--)
            {
                result[i] = matrix[i,n];
                for (int j = i + 1; j < n; j++)
                {
                    if (i != j)
                        result[i] -= matrix[i,j] * result[j];
                }
                result[i] /= matrix[i,i];
            }

            return result;
        }
    }
}
