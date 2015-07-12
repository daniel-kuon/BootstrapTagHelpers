namespace BootstrapTagHelpers {
    using System.Collections.Generic;
    using System.Linq.Expressions;

    public static class ExpressionExtensionMethods {

        public static MemberExpression GetMemberName(this Expression body) {
            var candidates = new Queue<Expression>();
            candidates.Enqueue(body);
            while (candidates.Count > 0)
            {
                var expr = candidates.Dequeue();
                var memberExpression = expr as MemberExpression;
                if (memberExpression != null)
                {
                    return memberExpression;
                }
                else {
                    var unaryExpression = expr as UnaryExpression;
                    var binaryExpression = expr as BinaryExpression;
                    var methodCallExpression = expr as MethodCallExpression;
                    if (unaryExpression != null) {
                        candidates.Enqueue(unaryExpression.Operand);
                    } else if (binaryExpression!=null)
                    {
                        candidates.Enqueue(binaryExpression.Left);
                        candidates.Enqueue(binaryExpression.Right);
                    }
                    else if (methodCallExpression!= null)
                    {
                        foreach (var argument in methodCallExpression.Arguments)
                        {
                            candidates.Enqueue(argument);
                        }
                    }
                    else {
                        var lambdaExpression = expr as LambdaExpression;
                        if (lambdaExpression != null)
                        {
                            candidates.Enqueue(lambdaExpression.Body);
                        }
                    }
                }
            }

            return null;
        }
    }
}