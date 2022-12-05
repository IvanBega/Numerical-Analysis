using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class CubicSplineInterpolation : Interpolation
    {
        public CubicSplineInterpolation(int n, int a, int b, double[] Xi) : base(n, a, b, Xi)
        {
        }
        private struct CubeSpline
        {
            public double a, b, c, d, x;
        }
        public override double[] Interpolate(int n, double[] arr)
        {
            var result = new double[n];
            for (int i = 0; i < n; i++)
            {
                result[i] = cubicSplineInterpolationStep(arr[i]);
            }
            return result;
        }

        private double cubicSplineInterpolationStep(double xi)
        {
            CubeSpline[] spline = new CubeSpline[N + 1];

            double ai, bi, ci, F, hi_minus, hi_plus, hy1, hy2;

            for (int i = 0; i < N + 1; i++)
            {
                spline[i].x = Xi[i];
                spline[i].a = Yi[i];
            }
            spline[0].c = spline[N].c = 0;
            double[] Si1 = new double[N + 1];
            double[] Si2 = new double[N + 1];
            Si1[0] = Si2[0] = 0;

            for (int i = 1; i < N; ++i)
            {
                ai = hi_minus = Xi[i] - Xi[i - 1];
                bi = hi_plus = Xi[i + 1] - Xi[i];
                hy1 = Yi[i] - Yi[i - 1];
                hy2 = Yi[i + 1] - Yi[i];
                ci = 2 * (hi_minus + hi_plus);
                F = hy2 / (hi_plus - hy1) / hi_minus * 6;
                Si1[i] = -bi / (ai * Si1[i - 1] + ci);
                Si2[i] = (F - ai * Si2[i - 1]) / (ai * Si1[i - 1] + ci);
            }
            for (int i = N - 1; i > 0; --i)
            {
                spline[i].c = Si1[i] * spline[i + 1].c + Si2[i];
            }
            for (int i = N; i > 0; --i)
            {
                hi_minus = Xi[i] - Xi[i - 1];
                spline[i].d = (spline[i].c - spline[i - 1].c) / hi_minus;
                spline[i].b = (hi_minus * (2.0 * spline[i].c + spline[i - 1].c) / 6.0 + (Yi[i] - Yi[i - 1])) / hi_minus;
            }

            CubeSpline Spl;

            if (xi <= spline[0].x)
            {
                Spl = spline[0];
            }
            else if (xi >= spline[N].x)
            {
                Spl = spline[N];
            }

            else
            {
                int i = 0;
                int j = N;
                while (i + 1 < j)
                {
                    int k = i + (j - i) / 2;
                    if (xi <= spline[k].x) { j = k; }
                    else { i = k; }
                }
                Spl = spline[j];
            }

            return Spl.a + (Spl.b + (Spl.c / 2.0 + Spl.d * (xi - Spl.x) / 6.0) * (xi - Spl.x)) * (xi - Spl.x);
        }
    }
}
