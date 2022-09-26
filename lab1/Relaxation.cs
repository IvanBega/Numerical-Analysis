using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Relaxation : Solver
    {
        public override double? Solve(double x, double y, double eps)
        {
            double m1 = minDerivative(x, y, eps);
            double M1 = maxDerivative(x, y, eps);
            double t = 2 / (m1 + M1);
            Console.WriteLine("m1 = " + m1 + ", M1 = " + M1 + ", t = " + t);
            double prev = 0, x_ = x; prev = double.MaxValue;
            int i = 1;
            while (Math.Abs(x_ - prev) > eps)
            {
                prev = x_;
                x_ = prev - t * F(prev);
                Console.WriteLine("Iteration " + i.ToString() + ", value " + x_.ToString() + ", value " + F(x_));
                i++;
            }
            return x_;
        }

        private double maxDerivative(double a, double b, double eps)
        {
            double max = double.MinValue;
            for (double i = a; i < b; i+=0.001)
            {
                if (dF(i) > max)
                {
                    max = dF(i);
                }
            }

            return max;
        }
        private double minDerivative(double a, double b, double eps)
        {
            double min = double.MaxValue;
            for (double i = a; i < b; i += 0.001)
            {
                if (dF(i) < min)
                {
                    min = dF(i);
                }
            }

            return min;
        }
    }
}
