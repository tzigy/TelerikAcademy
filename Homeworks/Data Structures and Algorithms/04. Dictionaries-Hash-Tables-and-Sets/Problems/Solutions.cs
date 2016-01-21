namespace Problems
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading;

    using Problems.CustomHashSet;
    using Problems.HashTable;

    class Solutions
    {
        static void Main()
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;

            // Problem 1: Write a program that counts in a given array of double values the number of occurrences of each value. Use Dictionary<TKey,TValue>.
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Problem 1:");
            Console.WriteLine(new string('-', 20));
            dynamic[] data = { 3, 4, 4, -2.5, 3, 3, 4, 3, -2.5 };
            Dictionary<dynamic, int> groupedData = GroupByOccurence(data);
            PrintDictionary(groupedData);

            // Problem 2: Write a program that extracts from a given sequence of strings all elements that present in it odd number of times.
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Problem 2:");
            Console.WriteLine(new string('-', 20));
            string[] strings = { "C#", "SQL", "PHP", "PHP", "SQL", "SQL" };
            Dictionary<dynamic, int> groupedStrings = GroupByOccurence(strings);
            foreach (var key in groupedStrings)
            {
                if (key.Value % 2 != 0)
                {
                    Console.WriteLine(key.Key + " --> " + key.Value);
                }
            }

            // Problem 3: Write a program that counts how many times each word from given text file words.txt appears in it.
            // The character casing differences should be ignored. The result words should be ordered by their number of occurrences in the text. 
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Problem 3: ");
            Console.WriteLine(new string('-', 20));
            string[] text = ReadText();
            Dictionary<dynamic, int> wordsOccurences = GroupByOccurence(text);
            var sortedDict = from word in wordsOccurences
                             orderby word.Value ascending
                             select word;

            foreach (var word in sortedDict)
            {
                Console.WriteLine("{0} --> {1}", word.Key, word.Value);
            }

            // Problems 4 & 5:
            Console.WriteLine();
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Problems 4 and 5: ");
            Console.WriteLine(new string('-', 20));
            var firstSet = new CustomHashSet<string> { "Perl", "Java", "C#", "SQL", "PHP" };
            var secondSet = new CustomHashSet<string> { "Oracle", "SQL", "MySQL" };
            DisplayUnionIntersect(firstSet, secondSet);

            // Problem 6: (*) A text file phones.txt holds information about people, their town and phone number.
            // Duplicates can occur in people names, towns and phone numbers. Write a program to read the phones 
            // file and execute a sequence of commands given in the file commands.txt
            Console.WriteLine(new string('-', 20));
            Console.WriteLine("Problems 6: ");
            Console.WriteLine(new string('-', 20));
            var phoneBook = new Dictionary<string, List<Details>>();
            using (var fileReader = new StreamReader(@"..\..\phones.txt"))
            {
                while (!fileReader.EndOfStream)
                {
                    var line = fileReader.ReadLine();
                    var components = line.Split('|');
                    if (!phoneBook.ContainsKey(components[0].Trim()))
                    {
                        phoneBook.Add(components[0].Trim(), new List<Details> {new Details
                                                                                   {
                                                                                       Town = components[1].Trim(),
                                                                                       PhoneNumber = components[2].Trim()
                                                                                   } });
                    }
                    else
                    {
                        phoneBook[components[0].Trim()].Add(new Details
                        {
                            Town = components[1].Trim(),
                            PhoneNumber = components[2].Trim()
                        });
                    }
                }
            }

            using (var fileReader = new StreamReader(@"..\..\commands.txt"))
            {
                while (!fileReader.EndOfStream)
                {
                    var command = fileReader.ReadLine();
                    Console.WriteLine("Command: {0} ", command);
                    int leftBracketIndex = command.IndexOf('(');
                    int rightBracketIndex = command.IndexOf(')');
                    var commandParams =
                        command.Substring(leftBracketIndex + 1, rightBracketIndex - leftBracketIndex - 1).Split(',');

                    IEnumerable<KeyValuePair<string, List<Details>>> result;

                    if (commandParams.Length > 1)
                    {
                        result =
                            phoneBook.Where(x => x.Key.Contains(commandParams[0]) && x.Value[0].Town == commandParams[1].Trim());
                    }
                    else
                    {
                        result =
                            phoneBook.Where(x => x.Key.Contains(commandParams[0]));
                    }

                    Console.WriteLine("Result: ");

                    foreach (var line in result)
                    {
                        Console.Write(line.Key + ": ");
                        foreach (var entry in line.Value)
                        {
                            Console.WriteLine("Town: " + entry.Town + "; Phone number: " + entry.PhoneNumber);
                        }
                    }
                }
            }
        }

        public static string[] ReadText()
        {
            string[] text;

            using (StreamReader reader = new StreamReader(@"..\..\LoremIpsum.txt"))
            {
                text = Regex.Split(reader.ReadToEnd(), @"\W").Where(x => !string.IsNullOrWhiteSpace(x)).ToArray();
            }

            return text;
        }

        private static void PrintDictionary(Dictionary<dynamic, int> groupedData)
        {
            foreach (var key in groupedData)
            {
                Console.WriteLine(key.Key + " --> " + key.Value);
            }
        }

        private static Dictionary<dynamic, int> GroupByOccurence(dynamic[] data)
        {
            var groupedData = new Dictionary<dynamic, int>();

            foreach (var item in data)
            {
                if (!groupedData.ContainsKey(item))
                {
                    groupedData.Add(item, 1);
                }
                else
                {
                    groupedData[item]++;
                }
            }

            return groupedData;
        }

        private static void DisplayUnionIntersect(CustomHashSet<string> firstSet, CustomHashSet<string> secondSet)
        {
            Console.Write("First set: ");
            PrintSet(firstSet);

            Console.Write("Second set: ");
            PrintSet(secondSet);

            var union = firstSet.UnionWith(secondSet);
            Console.Write("Union: ");
            PrintSet(union);

            var intersect = firstSet.IntersectWith(secondSet);
            Console.Write("Intersect: ");
            PrintSet(intersect);
        }

        private static void PrintSet<T>(IHashSet<T> set)
        {
            foreach (var element in set)
            {
                Console.Write("{0} ", element);
            }
            Console.WriteLine();
        }
    }
}
