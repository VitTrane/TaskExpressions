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
                Expression left = node.Left;
                Expression right = node.Right;

                if (left.NodeType == ExpressionType.Parameter && right.NodeType == ExpressionType.Constant) 
                {
                    var constant = ((ConstantExpression)right).Value;
                    int value = 0;
                    if (int.TryParse(constant.ToString(), out value) && value == 1)
                        return Expression.MakeUnary(ExpressionType.PreIncrementAssign,left,null);
                    
                }

                if (right.NodeType == ExpressionType.Parameter && left.NodeType == ExpressionType.Constant) 
                {
                    var constant = ((ConstantExpression)left).Value;
                    int value = 0;
                    if (int.TryParse(constant.ToString(), out value) && value == 1)
                        return Expression.MakeUnary(ExpressionType.PreIncrementAssign, right, null);
                }
            }

            return base.VisitBinary(node);
        }
    }
}
