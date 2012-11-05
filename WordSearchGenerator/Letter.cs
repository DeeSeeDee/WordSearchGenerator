using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

//The letter class contains the character and whether or not the character is part of one of the hidden words in the puzzle.
//The latter property is used when highlighting the words in the puzzle
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
