using System;
namespace QuadraticEquationSolver
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Программа для решения квадратных уравнений ax^2+ bx + c = 0");
            Console.WriteLine("Введите a:");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите b:");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите c:");
            double c = double.Parse(Console.ReadLine());
            double discriminant = b * b - 4 * a * c;
            if (discriminant < 0)
            {
                Console.WriteLine("Уравнение не имеет действительных корней.");
            }
            else if (discriminant == 0)
            {
                double x = -b / (2 * a);
                Console.WriteLine("Уравнение имеет один корень: x = " + x);
            }
            else
            {
                double x1 = (-b + Math.Sqrt(discriminant)) / (2 * a);
                double x2 = (-b - Math.Sqrt(discriminant)) / (2 * a);
                Console.WriteLine("Уравнение имеет два корня: x1 = " + x1 + ", x2 = " + x2);
            }
            Console.ReadLine();
        }
    }
}