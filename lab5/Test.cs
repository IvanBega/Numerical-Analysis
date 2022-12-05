using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Test
    {
        protected int N;
        protected readonly double A;
        protected readonly double B;
        protected double[] Xi;
        protected double[] Yi;
        public Test(int n, double a, double b, double[] Xi)
        {
            this.Xi = Xi;
            this.A = a;
            this.B = b;
            this.N = n;

            initArrays();
        }
        protected double Func(double x)
        {
            //return (3 * Math.Pow(x, 3) + Math.Pow(x, 2) + 2 * x - 2);
            return 3 * Math.Sin(x) + 4 * x * x - 0.6 + 3 * x;
        }
        private void initArrays()
        {
            Yi = new double[N + 1];
            double step = (double)(A + B) / N;
            double current = A;
            for (int i = 0; i <= N; i++)
            {
                Xi[i] = current;
                Yi[i] = Func(current);
                current += step;
            }
        }
        public double[] Interpolate(int n, double[] arr)
        {
            var result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = lagrangeInterpolationStep(arr[i]);
            }
            return result;
        }

        private double lagrangeInterpolationStep(double xi)
        {
            double result = 0;

            for (int i = 0; i < N + 1; i++)
            {
                double temp = 1;
                for (int j = 0; j < N + 1; j++)
                {
                    if (j != i)
                    {
                        temp *= (xi - Xi[j]) / (Xi[i] - Xi[j]);
                    }
                }
                result += temp * Yi[i];
            }
            return result;
        }
    }
}
