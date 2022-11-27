using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab2
{
    internal static class Matrix
    {
        public static double[,] HilbertMatrix(int n, bool modify = false)
        {
            double[,] matrix = new double[n,n+1];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = 1.0 / (i + j + 1);
                }
            }

            Random rnd = new Random();
            for (int i = 0; i < n; i++)
            {
                matrix[i, n] = rnd.NextDouble() * 10;
            }
            if (!modify) return matrix;

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    sum += Math.Abs(matrix[i, j]);
                }
                if (Math.Abs(matrix[i, i]) < sum)
                {
                    double diff = Math.Abs(matrix[i, i]) - sum;
                    matrix[i, i] = diff * rnd.NextDouble() * 3;
                }
            }
            return matrix;
        }

        public static double[,] RandomMatrix(int n, bool modify = false)
        {
            double[,] matrix = new double[n, n + 1];
            Random rnd = new Random();
            for (int i = 0;i < n; i++)
            {
                for (int j = 0; j <n; j++)
                {
                    matrix[i, j] = rnd.Next(-10, 10);
                }
            }
            for (int i = 0; i < n; i++)
            {
                matrix[i, n] = rnd.NextDouble() * 10;
            }
            if (!modify) return matrix;

            for (int i = 0; i < n; i++)
            {
                double sum = 0;
                for (int j = 0; j < n; j++)
                {
                    if (i == j) continue;
                    sum += Math.Abs(matrix[i, j]);
                }
                if (Math.Abs(matrix[i,i]) < sum)
                {
                    double diff = Math.Abs(matrix[i, i]) - sum;
                    matrix[i, i] = diff * rnd.NextDouble() * 20;
                }
            }
            return matrix;
        }
        public static void modifyMatrix(double[,] matrix, int n)
        {
            for (int i = 0; i < n; i++)
            {
                matrix[i, n] = 0;
                for (int j = 0; j < n; j++)
                {
                    matrix[i, n] += matrix[i, j];
                }
            }
        }
    }
}
