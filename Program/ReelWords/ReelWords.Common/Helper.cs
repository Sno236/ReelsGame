using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReelWords
{
   public class Helper
    {
        public static Dictionary<char, int> Scores { get; set; }
        public  static char[,] InitialReel { get; set; }
        public static char[] GetRandomRow(char[,] matrix, int rowNumber)
        {
            return Enumerable.Range(0, matrix.GetLength(1))
                    .Select(x => matrix[rowNumber, x])
                    .ToArray();
        }
    }
}
