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

            return x * x + 4 * Math.Sin(x) - 1;
        }
        protected double dF(double x)
        {
            return 2 * x + 4 * Math.Cos(x);
        }
    }
}
