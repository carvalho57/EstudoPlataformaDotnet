using System;
using System.Linq.Expressions;

namespace code.ExpressionTree
{
    // Base Visitor class:
    public abstract class Visitor
    {
        private readonly Expression node;

        protected Visitor(Expression node)
        {
            this.node = node;
        }

        public abstract void Visit(string prefix);

        public ExpressionType NodeType => this.node.NodeType;
        public static Visitor CreateFromExpression(Expression node)
        {
            switch (node.NodeType)
            {
                case ExpressionType.Constant:
                    return new ConstantVisitor((ConstantExpression)node);
                case ExpressionType.Lambda:
                    return new LambdaVisitor((LambdaExpression)node);
                case ExpressionType.Parameter:
                    return new ParameterVisitor((ParameterExpression)node);
                case ExpressionType.Add:
                case ExpressionType.Equal:
                case ExpressionType.Multiply:
                    return new BinaryVisitor((BinaryExpression)node);
                case ExpressionType.Conditional:
                    return new ConditionalVisitor((ConditionalExpression)node);
                case ExpressionType.Call:
                    return new MethodCallVisitor((MethodCallExpression)node);
                default:
                    Console.Error.WriteLine($"Node not processed yet: {node.NodeType}");
                    return default(Visitor);
            }
        }
    }

    // Lambda Visitor
    public class LambdaVisitor : Visitor
    {
        private readonly LambdaExpression node;
        public LambdaVisitor(LambdaExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression type");
            Console.WriteLine($"{prefix}The name of the lambda is {((node.Name == null) ? "<null>" : node.Name)}");
            Console.WriteLine($"{prefix}The return type is {node.ReturnType.ToString()}");
            Console.WriteLine($"{prefix}The expression has {node.Parameters.Count} argument(s). They are:");
            // Visit each parameter:
            foreach (var argumentExpression in node.Parameters)
            {
                var argumentVisitor = Visitor.CreateFromExpression(argumentExpression);
                argumentVisitor.Visit(prefix + "\t");
            }
            Console.WriteLine($"{prefix}The expression body is:");
            // Visit the body:
            var bodyVisitor = Visitor.CreateFromExpression(node.Body);
            bodyVisitor.Visit(prefix + "\t");
        }
    }

    // Binary Expression Visitor:
    public class BinaryVisitor : Visitor
    {
        private readonly BinaryExpression node;
        public BinaryVisitor(BinaryExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This binary expression is a {NodeType} expression");
            var left = Visitor.CreateFromExpression(node.Left);
            Console.WriteLine($"{prefix}The Left argument is:");
            left.Visit(prefix + "\t");
            var right = Visitor.CreateFromExpression(node.Right);
            Console.WriteLine($"{prefix}The Right argument is:");
            right.Visit(prefix + "\t");
        }
    }

    // Parameter visitor:
    public class ParameterVisitor : Visitor
    {
        private readonly ParameterExpression node;
        public ParameterVisitor(ParameterExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}Type: {node.Type.ToString()}, Name: {node.Name}, ByRef: {node.IsByRef}");
        }
    }

    // Constant visitor:
    public class ConstantVisitor : Visitor
    {
        private readonly ConstantExpression node;
        public ConstantVisitor(ConstantExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This is an {NodeType} expression type");
            Console.WriteLine($"{prefix}The type of the constant value is {node.Type}");
            Console.WriteLine($"{prefix}The value of the constant value is {node.Value}");
        }
    }

    public class ConditionalVisitor : Visitor
    {
        private readonly ConditionalExpression node;
        public ConditionalVisitor(ConditionalExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            var testVisitor = Visitor.CreateFromExpression(node.Test);
            Console.WriteLine($"{prefix}The Test for this expression is:");
            testVisitor.Visit(prefix + "\t");
            var trueVisitor = Visitor.CreateFromExpression(node.IfTrue);
            Console.WriteLine($"{prefix}The True clause for this expression is:");
            trueVisitor.Visit(prefix + "\t");
            var falseVisitor = Visitor.CreateFromExpression(node.IfFalse);
            Console.WriteLine($"{prefix}The False clause for this expression is:");
            falseVisitor.Visit(prefix + "\t");
        }
    }

    public class MethodCallVisitor : Visitor
    {
        private readonly MethodCallExpression node;
        public MethodCallVisitor(MethodCallExpression node) : base(node)
        {
            this.node = node;
        }

        public override void Visit(string prefix)
        {
            Console.WriteLine($"{prefix}This expression is a {NodeType} expression");
            if (node.Object == null)
                Console.WriteLine($"{prefix}This is a static method call");
            else
            {
                Console.WriteLine($"{prefix}The receiver (this) is:");
                var receiverVisitor = Visitor.CreateFromExpression(node.Object);
                receiverVisitor.Visit(prefix + "\t");
            }

            var methodInfo = node.Method;
            Console.WriteLine($"{prefix}The method name is {methodInfo.DeclaringType}.{methodInfo.Name}");
            // There is more here, like generic arguments, and so on.
            Console.WriteLine($"{prefix}The Arguments are:");
            foreach (var arg in node.Arguments)
            {
                var argVisitor = Visitor.CreateFromExpression(arg);
                argVisitor.Visit(prefix + "\t");
            }
        }
    }
}