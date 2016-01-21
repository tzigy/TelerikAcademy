namespace WordsCount
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        // Write a program that finds a set of words (e.g. 1000 words) in a large text (e.g. 100 MB text file).
        // Print how many times each word occurs in the text.
        // Hint: you may find a C# trie in Internet.

        static readonly Random RandomGenerator = new Random();

        static readonly string[] TextWords = new string[]
        {
        "to", "travel", "alone", "please", "work", "problem", "leave", "speak", "broken", "sun", "shop", "workshop",
        "ready", "project", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window",
        "help", "view", "edit", "file", "just", "error", "warning", "window", "write", "read", "text", "word", "as",
        "find", "each", "many", "much", "large", "set", "table", "dog", "cat", "main", "sound", "music", "stop", "start",
        "live", "this", "these", "go", "away", "dozen", "forum", "academy", "immortal", "my", "your", "never", "late",
        "too", "one", "two", "number", "random", "click", "comment", "forever", "always", "bring", "me", "song", "remind",
        "wing", "can", "say", "talk", "argument", "compliment", "agree", "become", "be", "now", "hate", "what", "fallen"
        };

        static IList<string> wordsToFind = new List<string>()
        {
        "to", "item", "alone", "please", "work", "away", "leave", "speak", "load", "sun", "shop", "quick",
        "ready", "save", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window",
        "open", "view", "edit", "file", "just", "character", "warning", "window", "write", "read", "text", "word", "as",
        "find", "each", "close", "much", "slow", "set", "table", "dog", "cat", "book", "sound", "mark", "stop", "start",
        };

        public static void Main()
        {
            Console.WriteLine("Counting words...");

            string[] words = new string[1000000];
            for (int i = 0; i < 1000000; i++)
            {
                words[i] = TextWords[RandomGenerator.Next(0, TextWords.Length)];
            }

            TrieNode root = new TrieNode(null, '?');

            foreach (string word in words)
            {
                root.AddWord(word);
            }

            List<TrieNode> topNodes = new List<TrieNode>();

            for (int i = 0; i < wordsToFind.Count; i++)
            {
                topNodes.Add(root);
            }

            int distinctWordCount = 0;
            int totalWordCount = 0;
            root.GetTopCounts(ref topNodes, ref distinctWordCount, ref totalWordCount);
            topNodes.Reverse();

            for (int i = 0; i < wordsToFind.Count; i++)
            {
                var currentWord = wordsToFind[i];
                foreach (var node in topNodes)
                {
                    if (currentWord == node.ToString())
                    {
                        Console.WriteLine("{0} -> {1} times", node.ToString(), node.wordCount);
                        break;
                    }
                }
            }
        }
    }
}
