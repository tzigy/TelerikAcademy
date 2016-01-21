namespace Game
{
    using System;
    using System.Collections.Generic;

    public class Minesweeper
    {
        private const int PlayingFieldRows = 5;
        private const int PlayingFieldColumns = 10;

        public static void Main()
        {
            string command = string.Empty;
            char[,] playingField = CreatePlayingField();
            char[,] bombsPossitions = PutBombsOnPlayingField();
            int points = 0;
            bool isOnBomb = false;
            List<Score> topScores = new List<Score>(6);
            int row = 0;
            int column = 0;
            bool isNewGame = true;
            const int MaxScore = 35;
            bool isMaxScore = false;

            do
            {
                if (isNewGame)
                {
                    Console.WriteLine("Lets play  “Minesweeper”. Try to find the fields without minesweepers." + Environment.NewLine +
                        "   Command 'top' show top scores," + Environment.NewLine +
                        "   command 'restart' start new game," + Environment.NewLine +
                        "   command 'exit' exit from the game!");
                    DrawBoard(playingField);
                    isNewGame = false;
                }

                Console.Write("Pls, input row and column: ");
                command = Console.ReadLine().Trim();

                if (command.Length >= 3)
                {
                    if (int.TryParse(command[0].ToString(), out row) &&
                        int.TryParse(command[2].ToString(), out column) &&
                        row <= playingField.GetLength(0) &&
                        column <= playingField.GetLength(1))
                    {
                        command = "move";
                    }
                }

                switch (command)
                {
                    case "top":
                        ShowTopScores(topScores);
                        break;
                    case "restart":
                        playingField = CreatePlayingField();
                        bombsPossitions = PutBombsOnPlayingField();
                        DrawBoard(playingField);
                        isOnBomb = false;
                        isNewGame = false;
                        break;
                    case "exit":
                        Console.WriteLine("Bye, Bye, Bye!");
                        break;
                    case "move":
                        if (bombsPossitions[row, column] != '*')
                        {
                            if (bombsPossitions[row, column] == '-')
                            {
                                MakeMove(playingField, bombsPossitions, row, column);
                                points++;
                            }

                            if (MaxScore == points)
                            {
                                isMaxScore = true;
                            }
                            else
                            {
                                DrawBoard(playingField);
                            }
                        }
                        else
                        {
                            isOnBomb = true;
                        }

                        break;
                    default:
                        Console.WriteLine(Environment.NewLine + "Invalid command" + Environment.NewLine);
                        break;
                }

                if (isOnBomb)
                {
                    DrawBoard(bombsPossitions);

                    Console.Write("{1}Sorry you are dead. Your score is {0} points. Pls, enter your nickname: ", points, Environment.NewLine);

                    string nickname = Console.ReadLine();
                    Score currentScore = new Score(nickname, points);

                    if (topScores.Count < 5)
                    {
                        topScores.Add(currentScore);
                    }
                    else
                    {
                        for (int i = 0; i < topScores.Count; i++)
                        {
                            if (topScores[i].Points < currentScore.Points)
                            {
                                topScores.Insert(i, currentScore);
                                topScores.RemoveAt(topScores.Count - 1);
                                break;
                            }
                        }
                    }

                    topScores.Sort((Score r1, Score r2) => r2.Name.CompareTo(r1.Name));
                    topScores.Sort((Score r1, Score r2) => r2.Points.CompareTo(r1.Points));
                    ShowTopScores(topScores);

                    playingField = CreatePlayingField();
                    bombsPossitions = PutBombsOnPlayingField();
                    points = 0;
                    isOnBomb = false;
                    isNewGame = true;
                }

                if (isMaxScore)
                {
                    Console.WriteLine(Environment.NewLine + "Bravooo! You open all 35 boxes without to step on bomb!");
                    DrawBoard(bombsPossitions);
                    Console.WriteLine("Pls, write your nickname: ");
                    string nickname = Console.ReadLine();
                    Score currentScore = new Score(nickname, points);
                    topScores.Add(currentScore);
                    ShowTopScores(topScores);
                    playingField = CreatePlayingField();
                    bombsPossitions = PutBombsOnPlayingField();
                    points = 0;
                    isMaxScore = false;
                    isNewGame = true;
                }
            }
            while (command != "exit");

            Console.WriteLine("Made in Bulgaria!");
            Console.WriteLine("See you next time!");
            Console.Read();
        }

        private static void ShowTopScores(List<Score> scores)
        {
            Console.WriteLine(Environment.NewLine + "Scores chart:");

            if (scores.Count > 0)
            {
                for (int i = 0; i < scores.Count; i++)
                {
                    Console.WriteLine("{0}. {1} --> {2} points", i + 1, scores[i].Name, scores[i].Points);
                }

                Console.WriteLine();
            }
            else
            {
                Console.WriteLine("The chart is empty!" + Environment.NewLine);
            }
        }

        private static void MakeMove(char[,] plyingField, char[,] bombsPossitions, int row, int col)
        {
            char numberOfSurroundingBombs = CountSurroundingBombs(bombsPossitions, row, col);
            bombsPossitions[row, col] = numberOfSurroundingBombs;
            plyingField[row, col] = numberOfSurroundingBombs;
        }

        private static void DrawBoard(char[,] playingField)
        {
            int playingFieldRows = PlayingFieldRows;
            int playingFieldColumns = PlayingFieldColumns;

            Console.WriteLine(Environment.NewLine + "    0 1 2 3 4 5 6 7 8 9");
            Console.WriteLine("   ---------------------");

            for (int i = 0; i < playingFieldRows; i++)
            {
                Console.Write("{0} | ", i);

                for (int j = 0; j < playingFieldColumns; j++)
                {
                    Console.Write(string.Format("{0} ", playingField[i, j]));
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

        private static char[,] PutBombsOnPlayingField()
        {
            int playingFieldRows = PlayingFieldRows;
            int playingFieldColumns = PlayingFieldColumns;
            char[,] playingField = new char[playingFieldRows, playingFieldColumns];

            for (int i = 0; i < playingFieldRows; i++)
            {
                for (int j = 0; j < playingFieldColumns; j++)
                {
                    playingField[i, j] = '-';
                }
            }

            List<int> bombs = new List<int>();

            while (bombs.Count < 15)
            {
                Random random = new Random();
                int nextBomb = random.Next(50);
                if (!bombs.Contains(nextBomb))
                {
                    bombs.Add(nextBomb);
                }
            }

            foreach (int bomb in bombs)
            {
                int row = bomb / playingFieldColumns;
                int column = bomb % playingFieldColumns;

                if (column == 0 && bomb != 0)
                {
                    row--;
                    column = playingFieldColumns;
                }
                else
                {
                    column++;
                }

                playingField[row, column - 1] = '*';
            }

            return playingField;
        }

        private static void PutSurroundingBombsOnPlayingField(char[,] playingField)
        {
            int playingFieldRows = PlayingFieldRows;
            int playingFieldColumns = PlayingFieldColumns;

            for (int i = 0; i < playingFieldRows; i++)
            {
                for (int j = 0; j < playingFieldColumns; j++)
                {
                    if (playingField[i, j] != '*')
                    {
                        char numberOfSurroundingBombs = CountSurroundingBombs(playingField, i, j);
                        playingField[i, j] = numberOfSurroundingBombs;
                    }
                }
            }
        }

        private static char CountSurroundingBombs(char[,] playingField, int row, int column)
        {
            int numberOfBombsArround = 0;
            int playingFieldRows = PlayingFieldRows;
            int playingFieldColumns = PlayingFieldColumns;

            if (row - 1 >= 0)
            {
                if (playingField[row - 1, column] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if (row + 1 < playingFieldRows)
            {
                if (playingField[row + 1, column] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if (column - 1 >= 0)
            {
                if (playingField[row, column - 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if (column + 1 < playingFieldColumns)
            {
                if (playingField[row, column + 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if ((row - 1 >= 0) && (column - 1 >= 0))
            {
                if (playingField[row - 1, column - 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if ((row - 1 >= 0) && (column + 1 < playingFieldColumns))
            {
                if (playingField[row - 1, column + 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if ((row + 1 < playingFieldRows) && (column - 1 >= 0))
            {
                if (playingField[row + 1, column - 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            if ((row + 1 < playingFieldRows) && (column + 1 < playingFieldColumns))
            {
                if (playingField[row + 1, column + 1] == '*')
                {
                    numberOfBombsArround++;
                }
            }

            return char.Parse(numberOfBombsArround.ToString());
        }
    }
}