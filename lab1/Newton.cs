using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab1
{
    internal class Newton : Solver
    {
        public override double? Solve(double x = 5, double y = 0, double eps = Constants.Eps)
        {
            double x_prev = 10;
            //double x = 5;
            int i = 0;
            while (Math.Abs(x - x_prev) > eps) 
            {
                x_prev = x;
                x = x_prev - F(x) / dF(x);
                Console.WriteLine("Iteration " + i.ToString() + ", value " + x.ToString());
                i++;
            }
            return x;
        }

        
    }
}
