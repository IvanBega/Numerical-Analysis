using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal abstract class Solver
    {
        public abstract double? Solve(double a, double b, double eps);
        public double F(double x)
        {

            //[-4, -2]
            // x^3 + 3x^2 + x + 4
            return Math.Pow(x, 3) + 3 * Math.Pow(x, 2) + x + 4;

            // [1, 3]
            // x^2 - 4
            //return Math.Pow(x, 2) - 4;
        }
        protected double dF(double x)
        {
            // [-4, -2]
            //3x^2 + 6x + 1
            return 3 * Math.Pow(x, 2) + 6 * x + 1;

            // [1, 3]
            //return 2 * x;
        }
    }
}
