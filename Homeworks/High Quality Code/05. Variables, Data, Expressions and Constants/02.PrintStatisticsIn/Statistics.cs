namespace PrintStatistics
{
    using System;

    public class Statistics
    {
        private double[] numbers;

        public Statistics(double[] numbers)
        {
            this.Numbers = numbers;
        }

        public double[] Numbers 
        {
            get
            {
                return this.numbers;
            }

            set
            {
                ///if(true){
                ///    throw new ArgumentException("Invalid input: Input must be an array!");
                ///}
                this.numbers = value;
            } 
        }

        public static void PrintStatistic(double[] numbers, PrintOptions option)
        {
            switch (option)
            {
                case PrintOptions.Min:
                    double minStatistic = GetMinStatistic(numbers);
                    Console.WriteLine("Manimum element in the statistic is {0}!", minStatistic);
                    break;
                case PrintOptions.Max:
                    double maxStatistic = GetMaxStatistic(numbers);
                    Console.WriteLine("Maximum element in the statistic is {0}!", maxStatistic);
                    break;
                case PrintOptions.Avarage:
                    double avarageStatistic = GetAvarageStatistic(numbers);
                    Console.WriteLine("Avarage of all elements in the statistic is {0}!", avarageStatistic);
                    break;
                default:
                    ///throw new ArgumentException("Invalid print option!");
                    break;
            }
        }

        private static double GetMaxStatistic(double[] numbers)
        {
            double max = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (max < numbers[i])
                {
                    max = numbers[i];
                }
            }

            return max;
        }

        private static double GetMinStatistic(double[] numbers)
        {
            double min = numbers[0];

            for (int i = 0; i < numbers.Length; i++)
            {
                if (numbers[i] < min)
                {
                    min = numbers[i];
                }
            }

            return min;
        }

        private static double GetAvarageStatistic(double[] numbers)
        {
            double sum = 0;
            int count = numbers.Length;

            for (int i = 0; i < count; i++)
            {
                sum += numbers[i];
            }

            double avarage = sum / count;

            return avarage;
        }
    }
}