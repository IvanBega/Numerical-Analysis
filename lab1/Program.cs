using System;

namespace lab1 // Note: actual namespace depends on the project name.
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Dychotomy dychotomy = new();
            Relaxation relaxation = new();
            Newton newton = new();
            Console.WriteLine("Dychotomy: ");
            double? result1 = dychotomy.Solve(Constants.A, Constants.B, Constants.Eps);
            Console.WriteLine(result1 + "\n\n");

            Console.WriteLine("Relaxation: ");
            double? result2 = relaxation.Solve(Constants.A, Constants.B, Constants.Eps);
            Console.WriteLine(result2 + "\n\n");

            Console.WriteLine("Newton: ");
            double? result3 = newton.Solve(Constants.A, Constants.B, Constants.Eps);
            Console.WriteLine(result3);
        }
    }
}