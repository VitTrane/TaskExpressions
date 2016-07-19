using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите первое число:");
            double firstNumber = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите второе число:");
            double secondNumber = double.Parse(Console.ReadLine());
            

            ParameterExpression firstParametr = Expression.Parameter(typeof(double), "firstParametr");
            ParameterExpression secondParametr = Expression.Parameter(typeof(double), "secondParametr");

            Expression body = Expression.Divide(Expression.Add(firstParametr, secondParametr),
                Expression.Constant(2.0));

            Expression<Func<double, double, double>> averageExpression =
                Expression.Lambda<Func<double, double, double>>(body, firstParametr, secondParametr);

            Console.WriteLine(averageExpression);
            Console.WriteLine(averageExpression.Compile().Invoke(firstNumber, secondNumber));

            Console.ReadLine();
        }
    }
}
