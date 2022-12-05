// See https://aka.ms/new-console-template for more information
using lab5;
Console.WriteLine("Hello, World!");
//lab5.Task.MySolve();

int n = 4;
int a = 0;
int b = 5;

int mult = 10;
var Xi = new double[n + 1];
double[] arr = new double[mult * n];
double step = (double)(a + b) / (mult*n);
double current = a;
for (int i = 0; i < mult * n; i++)
{
    arr[i] = current;
    current += step;
}


Interpolatable interpolator;
interpolator = new LagrangeInterpolation(n, a, b, Xi);
var result1 = interpolator.Interpolate(mult*n, arr);
interpolator = new NewtonInterpolation(n, a, b, Xi);
var result2 = interpolator.Interpolate(mult*n, arr);
interpolator = new CubicSplineInterpolation(n, a, b, Xi);
var result3 = interpolator.Interpolate(mult*n, arr);
var plt1 = new ScottPlot.Plot(800, 600);
plt1.AddScatter(arr, result1, System.Drawing.Color.Red);
plt1.AddScatter(arr, result2, System.Drawing.Color.Blue);
plt1.AddScatter(arr, result3, System.Drawing.Color.Green);
plt1.SaveFig("fig1.png");
