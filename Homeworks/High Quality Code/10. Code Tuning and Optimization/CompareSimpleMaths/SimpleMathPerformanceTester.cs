namespace CompareSimpleMaths
{
    using System;
    using System.Diagnostics;

    public class SimpleMathPerformanceTester
    {
        private const int IntegerOperatingValue = 1;
        private const long LongOperatingValue = 1L;
        private const float FloatOperatingValue = 1.0F;
        private const double DoubleOperatingValue = 1.0;
        private const decimal DecimalOperatingValue = 1M;
        private const int NumberOfOperationExecution = 1000000;


        public static void Main()
        {
            OperationPerformanceTest(Operations.Addition);
            OperationPerformanceTest(Operations.Substraction);
            OperationPerformanceTest(Operations.Multiplication);
            OperationPerformanceTest(Operations.Division);
        }

        static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.Write(stopwatch.Elapsed + "\n");
        }

        static void OperationPerformanceTest(Operations operation)
        {
            Console.WriteLine(operation + " performance test!");
            Console.Write("--> Integer: ");
            DisplayExecutionTime(() =>
            {
                int result = IntegerOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (operation)
                    {
                        case Operations.Addition:
                            result += IntegerOperatingValue;
                            break;
                        case Operations.Substraction:
                            result -= IntegerOperatingValue;
                            break;
                        case Operations.Multiplication:
                            result *= IntegerOperatingValue;
                            break;
                        case Operations.Division:
                            result /= IntegerOperatingValue;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });

            Console.Write("--> Long: ");
            DisplayExecutionTime(() =>
            {
                long result = LongOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (operation)
                    {
                        case Operations.Addition:
                            result += LongOperatingValue;
                            break;
                        case Operations.Substraction:
                            result -= LongOperatingValue;
                            break;
                        case Operations.Multiplication:
                            result *= LongOperatingValue;
                            break;
                        case Operations.Division:
                            result /= LongOperatingValue;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });

            Console.Write("--> Float: ");
            DisplayExecutionTime(() =>
            {
                float result = FloatOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (operation)
                    {
                        case Operations.Addition:
                            result += FloatOperatingValue;
                            break;
                        case Operations.Substraction:
                            result -= FloatOperatingValue;
                            break;
                        case Operations.Multiplication:
                            result *= FloatOperatingValue;
                            break;
                        case Operations.Division:
                            result /= FloatOperatingValue;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });

            Console.Write("--> Double: ");
            DisplayExecutionTime(() =>
            {
                double result = DoubleOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (operation)
                    {
                        case Operations.Addition:
                            result += DoubleOperatingValue;
                            break;
                        case Operations.Substraction:
                            result -= DoubleOperatingValue;
                            break;
                        case Operations.Multiplication:
                            result *= DoubleOperatingValue;
                            break;
                        case Operations.Division:
                            result /= DoubleOperatingValue;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });

            Console.Write("--> Decimal: ");
            DisplayExecutionTime(() =>
            {
                decimal result = DecimalOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (operation)
                    {
                        case Operations.Addition:
                            result += DecimalOperatingValue;
                            break;
                        case Operations.Substraction:
                            result -= DecimalOperatingValue;
                            break;
                        case Operations.Multiplication:
                            result *= DecimalOperatingValue;
                            break;
                        case Operations.Division:
                            result /= DecimalOperatingValue;
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });
        }
    }
}