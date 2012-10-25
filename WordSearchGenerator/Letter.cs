using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace WordSearchGenerator
{
    struct Letter
    {
        public char PuzzleChar;
        public bool IsPartOfWord;

        public Letter(char puzzleChar, bool isPartOfWord)
        {
            this.PuzzleChar = puzzleChar;
            this.IsPartOfWord = isPartOfWord;
        }
    }
}
