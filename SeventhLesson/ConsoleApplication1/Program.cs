using System;
using Library;

namespace ConsoleApplication1
{
    /* 1
     * -3
     * 2
     */
    class Program
    {

        static void Main()
        {
            double a = double.Parse(Console.ReadLine());
            double b = double.Parse(Console.ReadLine());
            double c = double.Parse(Console.ReadLine());

            var result = Solver.QuadraticEquationsSolver(a, b, c);

            Console.WriteLine("x1 = {0}, x2 = {1}", result[0],result[1]);
        }
    }
}
