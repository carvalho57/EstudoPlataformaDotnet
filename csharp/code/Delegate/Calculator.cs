using System;

namespace code.Delegates
{
    public delegate void Operation(double value1, double value2);

    public class OperationType
    {
        public static void Sum(double x, double y) => Console.WriteLine($"SUM: {x + y}");
        public static void Subtraction(double x, double y) => Console.WriteLine($"SUB:{x - y}");
        public static void Multiplication(double x, double y) => Console.WriteLine($"MULT: {x * y}");
        public static void Division(double x, double y)
        {
            if (y == 0) throw new DivideByZeroException();
             Console.WriteLine($"DIV:{ x / y}");
        }
    }
    public class Calculator
    {
        public void Calculate(Operation operation, double value1, double value2)
        {
            operation.Invoke(value1, value2);
        }
    }

    public class CalculatorExample
    {
        public static void Run()
        {
            var calculator = new Calculator();
            // Console.WriteLine(calculator.Calculate(OperationType.Sum, 10, 4));
            // Console.WriteLine(calculator.Calculate(OperationType.Sum, 20, 3));
            Operation operation = new Operation(OperationType.Sum);
            operation += OperationType.Subtraction;
            operation += OperationType.Division;
            operation += OperationType.Multiplication;

            calculator.Calculate(operation, 10, 3);
        }
    }
}