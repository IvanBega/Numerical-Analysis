using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class NewtonInterpolation : Interpolation
    {
        public NewtonInterpolation(int n, int a, int b, double[] Xi) : base(n, a, b, Xi)
        {
        }

        private double newtonInterpolationStep(double xi)
        {
            double result = 0;
            double dd;
            double coef;
            for (int i = 0; i < N; i++)
            {
                coef = 1;
                for (int j = 0; j < i; j++)
                {
                    coef *= xi - Xi[j];
                }

                dd = 0;
                double g;
                for (int j = 0; j <= i; j++)
                {
                    g = 1;
                    for (int k = 0; k <= i; k++)
                    {
                        if (k != j)
                        {
                            g *= 1 / (Xi[j] - Xi[k]);
                        }

                    }
                    dd += Yi[j] * g;
                }
                result += coef * dd;
            }
            return result;
        }

        public override double[] Interpolate(int n, double[] arr)
        {
            var result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = newtonInterpolationStep(arr[i]);
            }
            return result;
        }
    }
}
