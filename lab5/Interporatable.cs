using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal interface Interpolatable
    {
        public double[] Interpolate(int n, double[] arr);
    }
}
