namespace Game
{
    using System;

    public class PlayingField
    {
        private const int PlayingFieldRows = 5;
        private const int PlayingFieldColumns = 10;
       
        private char[,] field;

        public PlayingField()
            : this(PlayingFieldRows, PlayingFieldColumns)
        {                
        }

        public PlayingField(int rows, int cols)
        {
            this.field = new char[rows, cols];            
        }

        private static void Draw()
        {
            int rows = PlayingFieldRows;
            int columns = PlayingFieldColumns;

            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < rows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < columns; j++)
                {
                    ///Console.Write(string.Format("{0} ", playingField[i, j]));
                }

                Console.Write("|");
                Console.WriteLine();
            }

            Console.WriteLine("   ---------------------" + Environment.NewLine);
        }

        private static char[,] CreatePlayingField()
        {
            int playingFieldRows = PlayingFieldRows;
            int playingFieldColumns = PlayingFieldColumns;

            char[,] playingFields = new char[playingFieldRows, playingFieldColumns];

            for (int i = 0; i < playingFieldRows; i++)
            {
                for (int j = 0; j < playingFieldColumns; j++)
                {
                    playingFields[i, j] = '?';
                }
            }

            return playingFields;
        }
    }
}
