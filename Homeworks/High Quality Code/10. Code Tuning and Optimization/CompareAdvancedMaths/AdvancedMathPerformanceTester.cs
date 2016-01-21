namespace CompareAdvancedMaths
{
    using System;
    using System.Diagnostics;

    public class AdvancedMathPerformanceTester
    {
        private const float FloatOperatingValue = 25.0F;
        private const double DoubleOperatingValue = 25.0;
        private const decimal DecimalOperatingValue = 25M;
        private const int NumberOfOperationExecution = 1000000;


        public static void Main()
        {
            FunctionPerformanceTest(Functions.Sqrt);
            FunctionPerformanceTest(Functions.Log);
            FunctionPerformanceTest(Functions.Sin);
        }

        static void DisplayExecutionTime(Action action)
        {
            Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            action();
            stopwatch.Stop();
            Console.Write(stopwatch.Elapsed + "\n");
        }

        static void FunctionPerformanceTest(Functions function)
        {
            Console.WriteLine(function + " performance test!");


            Console.Write("--> Float: ");
            DisplayExecutionTime(() =>
            {
                float result = FloatOperatingValue;
                for (int i = 0; i < NumberOfOperationExecution; i++)
                {
                    switch (function)
                    {
                        case Functions.Sqrt:
                            result = (float)Math.Sqrt(FloatOperatingValue);
                            break;
                        case Functions.Log:
                            result = (float)Math.Log(FloatOperatingValue);
                            break;
                        case Functions.Sin:
                            result = (float)Math.Sin(FloatOperatingValue);
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
                    switch (function)
                    {
                        case Functions.Sqrt:
                            result = Math.Sqrt(DoubleOperatingValue);
                            break;
                        case Functions.Log:
                            result = Math.Log(DoubleOperatingValue);
                            break;
                        case Functions.Sin:
                            result = Math.Sin(DoubleOperatingValue);
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
                    switch (function)
                    {
                        case Functions.Sqrt:
                            result = (decimal)Math.Sqrt((double)DecimalOperatingValue);
                            break;
                        case Functions.Log:
                            result = (decimal)Math.Log((double)DecimalOperatingValue);
                            break;
                        case Functions.Sin:
                            result = (decimal)Math.Sin((double)DecimalOperatingValue);
                            break;
                        default:
                            throw new InvalidOperationException();
                    }
                }
            });
        }
    }
}