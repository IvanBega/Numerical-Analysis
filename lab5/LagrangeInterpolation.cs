using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class LagrangeInterpolation : Interpolation
    {
        public LagrangeInterpolation(int n, int a, int b, double[] Xi) : base(n, a, b, Xi)
        {
        }

        public override double[] Interpolate()
        {
            var result = new double[N + 1];
            for (int i = 0; i <= N; i++)
            {
                result[i] = lagrangeInterpolationStep(Xi[i]);
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
