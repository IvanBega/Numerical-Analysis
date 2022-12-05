using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal abstract class Interpolation : Interpolatable
    {
        protected readonly int N;
        protected readonly double A;
        protected readonly double B;
        protected double[] Xi;
        protected double[] Yi;
        public Interpolation(int n, int a, int b, double[] Xi)
        {
            this.N = n;
            this.A = a;
            this.B = b;
            this.Xi = Xi;
          
            initArrays();
            
        }

        private void initArrays()
        {
            Yi = new double[N+1];
            double step = (double) (A + B) / N;
            double current = A;
            for (int i = 0; i <= N; i++)
            {
                Xi[i] = current;
                Yi[i] = Func(current);
                current += step;
            }
        }

        public abstract double[] Interpolate(int n, double[] arr);
        protected double Func(double x)
        {
            //return (3 * Math.Pow(x, 3) + Math.Pow(x, 2) + 2 * x - 2);
            return 3 * Math.Sin(x) + 4 * x * x - 0.6 + 3 * x;
        }
    }
}
