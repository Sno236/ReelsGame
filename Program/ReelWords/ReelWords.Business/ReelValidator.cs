using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;

namespace ReelWords
{
    public class ReelValidator
    {
        Trie t = new Trie();
        string dictPath = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\Resources\american-english-large.txt";
        string reelsPath = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\Resources\reels.txt";
        string scoresPath = $@"{Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName}\Resources\scores.txt";
        public void Initialize()
        {
            InitDictionary();
            Helper.Scores = InitScores();
            Helper.InitialReel = InitReels();
        }
        private void InitDictionary()
        {
            try
            {
                string[] lines = System.IO.File.ReadAllLines(dictPath);
             
                foreach (string line in lines)
                {
                    t.Insert(line.ToLower().Trim());
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private char[,] InitReels()
        {
            try
            {
                int i = 0, j = 0;
                char[,] reels = new char[6, 7];
                string lines = File.ReadAllText(reelsPath);
                foreach (var row in lines.Split('\n'))
                {
                    j = 0;
                    foreach (var col in row.Trim().Split(' '))
                    {
                        reels[i, j] = char.Parse(col.Trim());
                        j++;
                    }
                    i++;
                }
                return reels;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        private Dictionary<char,int> InitScores()
        {
            Dictionary<char, int> scores = new Dictionary<char, int>();
            string lines = File.ReadAllText(scoresPath);
            foreach (var line in lines.Split('\n'))
            {
                var score = line.Trim().Split(' ');
                scores.Add(char.Parse(score[0].Trim()), int.Parse(score[1].Trim()));               
            }
            return scores;
        }
       
        public bool SearchTrie(string inputWord)
        {
           return t.Search(inputWord);

        }

    }
}
