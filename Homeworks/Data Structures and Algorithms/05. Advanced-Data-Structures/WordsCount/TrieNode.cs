namespace WordsCount
{
    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;

    public class TrieNode : IComparable<TrieNode>
    {
        private char currentChar;
        public int wordCount;
        private TrieNode parent = null;
        private ConcurrentDictionary<char, TrieNode> children = null;

        public TrieNode(TrieNode parent, char c)
        {
            this.currentChar = c;
            this.wordCount = 0;
            this.parent = parent;
            this.children = new ConcurrentDictionary<char, TrieNode>();
        }

        public void AddWord(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (char.IsLetter(key))
                {
                    if (!children.ContainsKey(key))
                    {
                        children.TryAdd(key, new TrieNode(this, key));
                    }
                    children[key].AddWord(word, index + 1);
                }
                else
                {
                    AddWord(word, index + 1);
                }
            }
            else
            {
                if (parent != null)
                {
                    lock (this)
                    {
                        wordCount++;
                    }
                }
            }
        }

        public int GetCount(string word, int index = 0)
        {
            if (index < word.Length)
            {
                char key = word[index];
                if (!children.ContainsKey(key))
                {
                    return -1;
                }
                return children[key].GetCount(word, index + 1);
            }
            else
            {
                return wordCount;
            }
        }

        public void GetTopCounts(ref List<TrieNode> mostCounted, ref int distinctWordCount, ref int totalWordCount)
        {
            if (wordCount > 0)
            {
                distinctWordCount++;
                totalWordCount += wordCount;
            }
            if (wordCount > mostCounted[0].wordCount)
            {
                mostCounted[0] = this;
                mostCounted.Sort();
            }
            foreach (char key in children.Keys)
            {
                children[key].GetTopCounts(ref mostCounted, ref distinctWordCount, ref totalWordCount);
            }
        }

        public override string ToString()
        {
            if (parent == null)
            {
                return string.Empty;
            }
            else
            {
                return parent.ToString() + currentChar;
            }
        }

        public int CompareTo(TrieNode other)
        {
            return this.wordCount.CompareTo(other.wordCount);
        }
    }
}
