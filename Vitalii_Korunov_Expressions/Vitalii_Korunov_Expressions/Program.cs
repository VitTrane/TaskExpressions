using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vitalii_Korunov_Expressions
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выражение: ");
            Expression<Func<int,int,int>> expr = (a,b)=> (a+1)*(b+1)-(a+1)*a;
            Console.WriteLine(expr);
            Console.WriteLine("подставим в выражение a=2, b=2");
            Console.WriteLine(expr.Compile().Invoke(2,2));

            Console.WriteLine();
          
            Console.WriteLine("Выражение после преобразования: ");
            QueryVisitor queryVisitor = new QueryVisitor();
            Expression modifiedExpr = queryVisitor.Modify((Expression)expr);
            Console.WriteLine(modifiedExpr);
            Console.WriteLine("подставим в выражение a=2, b=2");
            Console.WriteLine(expr.Compile().Invoke(2, 2));

            Console.ReadLine();
        }
    }
}
