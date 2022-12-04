// See https://aka.ms/new-console-template for more information
using lab5;
Console.WriteLine("Hello, World!");
//lab5.Task.MySolve();

int n = 30;
int a = 0;
int b = 20;
var Xi = new double[n + 1];
Interpolatable interpolator;
interpolator = new LagrangeInterpolation(n, a, b, Xi);
var result1 = interpolator.Interpolate();
interpolator = new NewtonInterpolation(n, a, b, Xi);
var result2 = interpolator.Interpolate();
interpolator = new CubicSplineInterpolation(n, a, b, Xi);
var result3 = interpolator.Interpolate();
var plt1 = new ScottPlot.Plot(800, 600);
var plt2 = new ScottPlot.Plot(800, 600);
plt1.AddScatter(Xi, result1, System.Drawing.Color.Green);
plt1.AddScatter(Xi, result2, System.Drawing.Color.Red);
plt1.AddScatter(Xi, result3, System.Drawing.Color.Blue);

double delta = (result1[n] - result1[0]) / 5;
var r2 = new double[n + 1];
var r3 = new double[n + 1];
for (int i = 0; i <= n; i++)
{
    r2[i] = result2[i] + delta;
    r3[i] = result3[i] + 2 * delta;
}
plt2.AddScatter(Xi, result1, System.Drawing.Color.Green);
plt2.AddScatter(Xi, r2, System.Drawing.Color.Red);
plt2.AddScatter(Xi, r3, System.Drawing.Color.Blue);
plt1.SaveFig("fig1.png");
plt2.SaveFig("fig2.png");