namespace RefactorIfStatement
{
    using System;

    public class Program
    {
        public const int MinCoordX = Int32.MinValue;
        public const int MaxCoordX = Int32.MaxValue;
        public const int MinCoordY = Int32.MinValue;
        public const int MaxCoordY = Int32.MaxValue;

        public static bool ShouldVisitCell { get; set; }

        public static void Main()
        {
            ///first subtask
            Potato potato = new Potato();
            bool isPeeled = potato.IsPeeled;
            bool isRotten = potato.IsRotten;
            if (potato != null)
            {
                if (isPeeled && !isRotten)
                {
                   ///TODO: Cook(potato); Not important for our task
                }
            }

            ///second subtask
            int x = 1;
            int y = 1;

            if (IsCoordXInRange(x) && 
                IsCoordYInRange(y) && 
                ShouldVisitCell)
            {
                VisitCell();
            }
        }

        private static bool IsCoordXInRange(int coordX)
        {
            if (MinCoordX <= coordX && coordX <= MaxCoordX)
            {
                return true;
            }

            return false;
        }

        private static bool IsCoordYInRange(int coordY)
        {
            if (MinCoordY <= coordY && coordY <= MaxCoordY)
            {
                return true;
            }

            return false;
        }

        private static void VisitCell()
        {
            throw new System.NotImplementedException();
        }       
    }
}
