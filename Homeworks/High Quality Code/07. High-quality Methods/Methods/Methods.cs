namespace Methods
{
    using System;

    public class Methods
    {
        public static double CalculateTriangleArea(double sideA, double sideB, double sideC)
        {
            if (!IsPositiveNumber(sideA) ||
                !IsPositiveNumber(sideB) ||
                !IsPositiveNumber(sideC))
            {
                throw new ArgumentOutOfRangeException("Side must be positive number!");
            }

            double semiPerimeter = (sideA + sideB + sideC) / 2;
            double area = Math.Sqrt(semiPerimeter * (semiPerimeter - sideA) * (semiPerimeter - sideB) * (semiPerimeter - sideC));

            return area;
        }

        public static bool IsPositiveNumber(double number)
        {
            bool result = 0 < number;
            return result;
        }

        public static string ConvertNumberToString(int number)
        {
            string result;

            switch (number)
            {
                case 0: 
                    result = "zero"; 
                    break;
                case 1: 
                    result = "one";
                    break;
                case 2: 
                    result = "two";
                    break;
                case 3:
                    result = "three";
                    break;
                case 4:
                    result = "four";
                    break;
                case 5:
                    result = "five";
                    break;
                case 6:
                    result = "six";
                    break;
                case 7:
                    result = "seven";
                    break;
                case 8: 
                    result = "eight";
                    break;
                case 9:
                    result = "nine";
                    break;
                default:
                    throw new ArgumentOutOfRangeException("Invalid number!");
            }

            return result;
        }

        public static int FindMaxElementInArray(params int[] elements)
        {
            if (elements == null || elements.Length == 0)
            {
                throw new ArgumentOutOfRangeException("Invalid input. Array cannot be empty!");
            }

            int maxElement = elements[0];

            for (int i = 1; i < elements.Length; i++)
            {
                if (maxElement < elements[i])
                {
                    maxElement = elements[i];
                }
            }

            return maxElement;
        }
        
        public static void PrintAsFloatNumber(object number)
        {
            Console.WriteLine("{0:f2}", number);
        }

        public static void PrintAsPercentNumber(object number)
        {
            Console.WriteLine("{0:p0}", number);
        }

        public static void PrintAsRightAlignedNumber(object number)
        {
            Console.WriteLine("{0,8}", number);
        }

        public static double CalculateDistance(double x1, double y1, double x2, double y2)
        {
            double distance = Math.Sqrt(((x2 - x1) * (x2 - x1)) + ((y2 - y1) * (y2 - y1)));

            return distance;
        }

        public static bool IsHorizontal(double x1, double y1, double x2, double y2)
        {
            bool isHorizontal = y1 == y2;

            return isHorizontal;
        }

        public static bool IsVertical(double x1, double y1, double x2, double y2)
        {
            bool isVertical = x1 == x2;

            return isVertical;
        }

        public static void Main()
        {
            Console.WriteLine(CalculateTriangleArea(3, 4, 5));

            Console.WriteLine(ConvertNumberToString(5));

            Console.WriteLine(FindMaxElementInArray(5, -1, 3, 2, 14, 2, 3));

            PrintAsFloatNumber(1.3);
            PrintAsPercentNumber(0.75);
            PrintAsRightAlignedNumber(2.30);
            
            Console.WriteLine(CalculateDistance(3, -1, 3, 2.5));
            bool horizontal = IsHorizontal(3, -1, 3, 2.5);
            bool vertical = IsVertical(3, -1, 3, 2.5);
            Console.WriteLine("Horizontal? " + horizontal);
            Console.WriteLine("Vertical? " + vertical);

            Student peter = new Student("Peter", "Ivanov", "17.03.1992", "From Sofia");

            Student stella = new Student("Stella", "Markova", "03.11.1993", "From Vidin, gamer, high results");

            Console.WriteLine("{0} older than {1} -> {2}", peter.FirstName, stella.FirstName, peter.IsOlderThan(stella));
        }
    }
}