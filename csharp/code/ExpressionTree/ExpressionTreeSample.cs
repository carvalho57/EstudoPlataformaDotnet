using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
namespace code.ExpressionTree
{
    public class ExpressionTreeSample
    {
        public static void Run()
        {
            VisitorSample();
        }

        private static void Creating()
        {
            // Addition is an add expression for "1 + 2"
            var one = Expression.Constant(1, typeof(int));
            var two = Expression.Constant(2, typeof(int));
            var addition = Expression.Add(one, two);
        }

        private static void CreatingLambdaExmpression()
        {
            // A parameter for the lambda expression.
            ParameterExpression paramExpr = Expression.Parameter(typeof(int), "arg");

            // This expression represents a lambda expression
            // that adds 1 to the parameter value.
            LambdaExpression lambdaExpr = Expression.Lambda(
                Expression.Add(
                    paramExpr,
                    Expression.Constant(1)
                ),
                new List<ParameterExpression>() { paramExpr }
            );

            Console.WriteLine(lambdaExpr);

            // Compile and run the lamda expression.
            // The value of the parameter is 1.
            Console.WriteLine(lambdaExpr.Compile().DynamicInvoke(1));
        }

        private static void EvaluatingExpressionTree()
        {
            Expression<Func<int, int>> addFive = (num) => num + 5;

            if (addFive.NodeType == ExpressionType.Lambda)
            {
                var lambdaExp = (LambdaExpression)addFive;

                var parameter = lambdaExp.Parameters.First();

                Console.WriteLine($"Name: {parameter.Name}");
                Console.WriteLine($"IsByRef: {parameter.IsByRef}");
                Console.WriteLine($"Type: {parameter.Type}");

                Console.WriteLine($"Result: {lambdaExp.Compile().DynamicInvoke(40)}");

            }

        }

        private static void ExaminingExpression()
        {
            Expression<Func<int, int, int>> addition = (a, b) => a + b;

            Console.WriteLine($"This expression is a {addition.NodeType} expression type");
            Console.WriteLine($"The name of the lambda is {((addition.Name == null) ? "<null>" : addition.Name)}");
            Console.WriteLine($"The return type is {addition.ReturnType.ToString()}");
            Console.WriteLine($"The expression has {addition.Parameters.Count} arguments. They are:");
            foreach (var argumentExpression in addition.Parameters)
            {
                Console.WriteLine($"\tParameter Type: {argumentExpression.Type.ToString()}, Name: {argumentExpression.Name}");
            }

            var additionBody = (BinaryExpression)addition.Body;
            Console.WriteLine($"The body is a {additionBody.NodeType} expression");
            Console.WriteLine($"The left side is a {additionBody.Left.NodeType} expression");
            var left = (ParameterExpression)additionBody.Left;
            Console.WriteLine($"\tParameter Type: {left.Type.ToString()}, Name: {left.Name}");
            Console.WriteLine($"The right side is a {additionBody.Right.NodeType} expression");
            var right = (ParameterExpression)additionBody.Right;
            Console.WriteLine($"\tParameter Type: {right.Type.ToString()}, Name: {right.Name}");
        }
    
        private static void VisitorSample()
        {
            Expression<Func<int>> sum = () => 1 + 2 + 3 + 4;
            Console.WriteLine(sum);
            var visitor  = Visitor.CreateFromExpression(sum);
            visitor.Visit(string.Empty);
        }
    }

}