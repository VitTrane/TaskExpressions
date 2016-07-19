using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Vitalii_Korunov_Expressions
{
    public class QueryVisitor : ExpressionVisitor
    {
        public Expression Modify(Expression expression)
        {
            return VisitAndConvert(expression,"");
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {

            if (node.NodeType == ExpressionType.Add) 
            {
                Expression left = this.Visit(node.Left);
                Expression right = this.Visit(node.Right);

                if (left.NodeType == ExpressionType.Parameter && right.NodeType == ExpressionType.Constant) 
                {
                    return Expression.MakeUnary(ExpressionType.PreIncrementAssign,left,null);
                }
            }

            return base.VisitBinary(node);
        }
    }
}
