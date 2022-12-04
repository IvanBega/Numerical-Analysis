using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab5
{
    internal class Task
    {
        static double A = 0;
        static double B = 5;
        const int N = 20;
        
        struct CubeSpline
        {
            public double a, b, c, d, x;
        }
        static double CubeSplineInterpolation(double Xv, double[] MasX, double[] MasY)
        {

            CubeSpline[] spline = new CubeSpline[N + 1];

            double ai, bi, ci, F, hi_minus, hi_plus, hy1, hy2;

            for (int i = 0; i < N + 1; i++)
            {
                spline[i].x = MasX[i];
                spline[i].a = MasY[i];
            }
            spline[0].c = spline[N].c = 0;
            double[] Si1 = new double[N + 1];
            double[] Si2 = new double[N + 1];
            Si1[0] = Si2[0] = 0;

            for (int i = 1; i < N; ++i)
            {
                ai = hi_minus = MasX[i] - MasX[i - 1];
                bi = hi_plus = MasX[i + 1] - MasX[i];
                hy1 = MasY[i] - MasY[i - 1];
                hy2 = MasY[i + 1] - MasY[i];
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
                hi_minus = MasX[i] - MasX[i - 1];
                spline[i].d = (spline[i].c - spline[i - 1].c) / hi_minus;
                spline[i].b = (hi_minus * (2.0 * spline[i].c + spline[i - 1].c) / 6.0 + (MasY[i] - MasY[i - 1])) / hi_minus;
            }

            CubeSpline Spl;

            if (Xv <= spline[0].x)
            {
                Spl = spline[0];
            }
            else if (Xv >= spline[N].x)
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
                    if (Xv <= spline[k].x) { j = k; }
                    else { i = k; }
                }
                Spl = spline[j];
            }

            return Spl.a + (Spl.b + (Spl.c / 2.0 + Spl.d * (Xv - Spl.x) / 6.0) * (Xv - Spl.x)) * (Xv - Spl.x);
        }
        static double LagrangeInterpolation(double Xv, double[] x, double[] y)
        {
            double result = 0;

            for (int i = 0; i < N + 1; i++)
            {
                double temp = 1;
                for (int j = 0; j < N + 1; j++)
                {
                    if (j != i)
                    {
                        temp *= (Xv - x[j]) / (x[i] - x[j]);
                    }
                }
                result += temp * y[i];
            }
            return result;

        }

        static double NewtonInterpolation(double Xp, double[] MasX, double[] MasY)
        {
            double result = 0;
            double dd;
            double coef;
            for (int i = 0; i < N; i++)
            {
                coef = 1;
                for (int j = 0; j < i; j++)
                {
                    coef *= Xp - MasX[j];
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
                            g *= 1/(MasX[j] - MasX[k]);
                        }
                        
                    }
                    dd += MasY[j] * g;
                }
                result += coef * dd;
            }
            return result;
        }
        private static double Func(double x)
        {
            return (3 * Math.Pow(x, 3) + Math.Pow(x, 2) + 2 * x - 2);
            //return Math.Sin(x) + Math.Cos(x);
        }
        public static void MySolve()
        {
            Console.WriteLine();
            double[] Xi = new double[N+1];
            double[] Yi = new double[N+1];
            double step = (double)((A + B) / N);
            double current = A;
            for (int i = 0; i <= N; i++)
            {
                Xi[i] = current;
                Yi[i] = Func(current);
                current += step;
                Console.WriteLine("{0} {1}", Xi[i], Yi[i]);
            }

            double[] lagrange = new double[N + 1];
            Console.WriteLine("\nLAGRANGE");
            for (int i = 0; i <=N; i++)
            {
                lagrange[i] = LagrangeInterpolation(Xi[i], Xi, Yi);
                Console.WriteLine("{0} {1}", Xi[i], lagrange[i]);
            }
            

            double[] newton = new double[N + 1];
            Console.WriteLine("\nNEWTON");
            for (int i = 0; i <= N; i++)
            {
                newton[i] = NewtonInterpolation( Xi[i], Xi, Yi);
                Console.WriteLine("{0} {1}", Xi[i], newton[i]);
            }

            double[] spline = new double[N + 1];
            Console.WriteLine("\nSPLINE");
            for (int i = 0; i <= N; i++)
            {
                spline[i] = CubeSplineInterpolation(Xi[i], Xi, Yi);
                Console.WriteLine("{0} {1}", Xi[i], spline[i]);
            }
            var plt = new ScottPlot.Plot(800, 600);
            plt.AddScatter(Xi, Yi, System.Drawing.Color.Green);
            plt.AddScatter(Xi, lagrange, System.Drawing.Color.Red);
            plt.AddScatter(Xi, newton, System.Drawing.Color.DarkBlue);
            plt.AddScatter(Xi, spline, System.Drawing.Color.DarkKhaki);
            plt.SaveFig("t1.png");
        }
    }
}
