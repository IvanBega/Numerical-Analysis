using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Dychotomy : Solver
    {
        public override double? Solve(double x, double y, double eps)
        {
            

            double fx = F(x);
            double fy = F(y);

            if (fx * fy > 0)
            {
                Console.WriteLine("Can't apply method!");
                return null;
            }

            int i = 1;
            double c = 0;
            do
            {
                c = (x + y) / 2.0;
                double fc = F(c);
                if (fc == 0)
                    return c;
                if (fc * fx > 0)
                    x = c;
                else
                    y = c;
                Console.WriteLine("Iteration " + i.ToString() + ", value " + c.ToString());
                i++;
            } while (Math.Abs(x - y) > eps);

            return c;
        }
    }
}
