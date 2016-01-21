namespace Trie
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class StartUp
    {
        // Filter/Search words by prefix

        static readonly Random RandomGenerator = new Random();

        static readonly string[] TextWords = new string[]
        {
        "to", "travel", "alone", "please", "work", "problem", "leave", "speak", "broken", "sun", "shop", "workshop",
        "ready", "project", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window",
        "onehelp", "view", "edit", "file", "just", "error", "onewarning", "window", "write", "read", "loadtext", "word", "as",
        "find", "each", "many", "much", "large", "set", "table", "dog", "cat", "main", "sound", "music", "stop", "start",
        "live", "tothis", "these", "togo", "away", "dozen", "forum", "academy", "immortal", "loadmy", "loadyour", "loadnever", "loadlate",
        "too", "one", "two", "onenumber", "onerandom", "canclick", "cancomment", "forever", "always", "bring", "me", "song", "remind",
        "wing", "can", "cansay", "cantalk", "argument", "compliment", "agree", "become", "be", "now", "hate", "what", "fallen"
        };

        static IList<string> wordsToFind = new List<string>()
        {
        "to", "one", "alone", "please", "work", "away", "leave", "speak", "load", "sun", "shop", "quick",
        "ready", "save", "team", "pulse", "ice", "tool", "test", "architecture", "solution", "explore", "window"
        };

        public static void Main()
        {
            string[] words = new string[100000];
            for (int i = 0; i < 100000; i++)
            {
                words[i] = TextWords[RandomGenerator.Next(0, TextWords.Length)];
            }

            var trie = new TrieFilter();
            foreach (string word in words)
            {
                trie.Add(word);
            }

            foreach (var word in wordsToFind)
            {
                Console.WriteLine("{0} -> {1}", word, string.Join(", ", trie.Match(word, wordsToFind.Count)));
            }
        }
    }
}
