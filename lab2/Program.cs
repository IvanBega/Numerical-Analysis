// See https://aka.ms/new-console-template for more information
using lab2;
Console.WriteLine("GAUSS | SEIDEL | JACOBI");
const int MatrixSize = 100;
double[,] matrix = Matrix.HilbertMatrix(MatrixSize, true);

var method1 = new GausMethod();
var method2 = new SeidelMethod(0.001);
var method3 = new JacobiMethod(0.001);
Matrix.modifyMatrix(matrix, MatrixSize);
double[] res1 = method1.Solve(matrix, MatrixSize);
double[] res2 = method2.Solve(matrix, MatrixSize);
double[] res3 = method3.Solve(matrix, MatrixSize);

for (int i = 0; i < MatrixSize; i++)
{
    Console.WriteLine("x{0} = {1} | x{0} = {2} | x{0} = {3}", i + 1, res1[i], res2[i], res3[i]);
}
