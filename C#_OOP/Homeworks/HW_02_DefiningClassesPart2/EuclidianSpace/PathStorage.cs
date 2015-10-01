namespace EuclidianSpace
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    static class PathStorage
    {
        public static void SavePathToFile(Path path, string fileName)
        {
            try
            {
                StreamWriter writer = new StreamWriter(fileName);

                using (writer)
                {
                    for (int i = 0; i < path.Count; i++)
                    {
                        writer.WriteLine(path.PointPath[i]);
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can not find file {0}.", fileName);
            }
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can not open file {0}.", fileName);
            }
        }
        public static Path LoadPathFromFile(string fileName)
        {
            Path output = new Path();

            try
            {
                StreamReader reader = new StreamReader(fileName);
                Console.WriteLine("File {0} successfully opened.", fileName);
                using (reader)
                {
                    int lineNumber = 0;
                    string line = reader.ReadLine();

                    while (line != null)
                    {
                        output.AddPointToPath(ConvertStringToPoint3D(line));
                        lineNumber++;
                        line = reader.ReadLine();
                    }
                }
            }
            catch (FileNotFoundException)
            {
                Console.Error.WriteLine("Can not find file {0}.", fileName);
            } 
            catch (DirectoryNotFoundException)
            {
                Console.Error.WriteLine("Invalid directory in file path.");
            }
            catch (IOException)
            {
                Console.Error.WriteLine("Can not open file {0}.", fileName);
            }

            return output;
        }

        private static Point3D ConvertStringToPoint3D(string pointAsString)
        {
            char[] charsToRemove = { '(', ',', ' ', ')' };
            string[] pointCoord = pointAsString.Trim().Split(charsToRemove, StringSplitOptions.RemoveEmptyEntries);
            double coordX = Convert.ToDouble(pointCoord[0]);
            double coordY = Convert.ToDouble(pointCoord[1]);
            double coordZ = Convert.ToDouble(pointCoord[2]);
            //Console.WriteLine("[{0}, {1}, {2}]", coordX, coordY, coordZ);
            Point3D point = new Point3D(coordX, coordY, coordZ);
            return point;
        }


        //static void Main()
        //{
        //    PathStorage.SavePathToFile(PathStorage.LoadPathFromFile("Points.txt"), "NewPoints.txt");        
        //}
    }    
}
