﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace WordSearchGenerator
{
    class WordPuzzle
    {
        public WordGrid puzzleGrid;
        public Dictionary<string, Point> wordLocs;
        private enum orientation
        {
            HorFor,
            VertFor,
            SlashFor,
            BackslashFor,
            HorRev,
            VertRev,
            SlashRev,
            BackslashRev
        };

        public WordPuzzle(List<string> wordList, int height, int width, int difficultyIndex)
        {
            //totalListChars = calculateTotalListChars(wordList);
            //Console.WriteLine("There is a total of " + totalListChars + " letters in the word list.");
            int difficulty;
            switch(difficultyIndex)
            {
                case 0:
                    difficulty = 2;
                    break;
                case 1:
                    difficulty = 4;
                    break;
                case 2:
                    difficulty = 8;
                    break;
                default:
                    difficulty = 8;
                    break;
            }                    
            puzzleGrid = CreateGrid(height, width);
            FillWords(wordList, puzzleGrid, difficulty);
            FillLetters(puzzleGrid); //Comment this line out for easy troubleshooting of the FillWords function
        }

        private int calculateTotalListChars(List<string> wordList)
        {
            int totalChars = 0;
            foreach (string item in wordList)
            {
                totalChars += item.Length;
                Console.WriteLine(item + " has " + item.Length + " characters.");
            }
            return totalChars;
        }

        private int suggestPuzzleSize(int puzzleSize)
        {
            int suggestedSize = (int)Math.Sqrt((double)puzzleSize) * 10;
            return suggestedSize;
        }

        private WordGrid CreateGrid(int width, int height)
        {
            WordGrid gridToCreate = new WordGrid(width, height);
            return gridToCreate;
        }

        /*FillWords takes the list of words created in Form1, randomly chooses an orientation for each word,
         * and then inserts each word into the puzzle. 
         */
        private void FillWords(List<string> listOfWords, WordGrid grid, int difficulty)
        {
            wordLocs = new Dictionary<string, Point>();
            Random random = new Random();
            int puzzleHeight = grid.Height;
            int puzzleWidth = grid.Width;
            Array orientations = Enum.GetValues(typeof(orientation));

            foreach (string word in listOfWords)
            {
                int startingRow;
                int startingCol;
                orientation randomOrientation = (orientation)orientations.GetValue(random.Next(difficulty));
                char[] wordChars = word.ToCharArray();

                /* In the following switch loop, we establish an orientation for the word. It can be one of eight possible
                 * orientations. At the beginning of the while loop, a copy of the existing puzzle grid is created. If there
                 * is a conflicting letter at a place where the algorithm is trying to write a letter, the loop will restart.
                 * This allows for overlapping words without conflict.
                 */
                switch (randomOrientation)
                {
                    case orientation.HorFor:
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int maxStartCol = puzzleWidth - word.Length;
                                startingRow = random.Next(puzzleHeight);
                                startingCol = random.Next(maxStartCol);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[startingRow, currentCol].PuzzleChar != '\0' && testGrid[startingRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[startingRow, currentCol] = new Letter(wordChars[i], true);
                                        currentCol++;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.VertFor:
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int maxStartRow = puzzleHeight - word.Length;
                                startingRow = random.Next(maxStartRow);
                                startingCol = random.Next(puzzleWidth);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, startingCol].PuzzleChar != '\0' && testGrid[currentRow, startingCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, startingCol] = new Letter(wordChars[i], true);
                                        currentRow++;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.HorRev:
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int minStartCol = wordChars.Length; //We're going backwards, so we don't want to start too close the left edge
                                startingRow = random.Next(puzzleHeight);
                                startingCol = random.Next(minStartCol, puzzleWidth);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[startingRow, currentCol].PuzzleChar != '\0' && testGrid[startingRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[startingRow, currentCol] = new Letter(wordChars[i], true);
                                        currentCol--;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.VertRev:
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int minStartRow = wordChars.Length;
                                startingRow = random.Next(minStartRow, puzzleHeight);
                                startingCol = random.Next(puzzleWidth);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, startingCol].PuzzleChar != '\0' && testGrid[currentRow, startingCol].PuzzleChar != wordChars[i])
                                    {
                                        //There's a conflict here. Defer to the existing state and start this word over with a new random location
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, startingCol] = new Letter(wordChars[i], true);
                                        currentRow--;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.SlashFor: //Diagonal word populated up and to the right from the start location
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int minStartRow = wordChars.Length;
                                int maxStartCol = puzzleWidth - wordChars.Length;
                                startingRow = random.Next(minStartRow, puzzleHeight);
                                startingCol = random.Next(0, maxStartCol);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, currentCol].PuzzleChar != '\0' && testGrid[currentRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, currentCol] = new Letter(wordChars[i], true);
                                        currentRow--;
                                        currentCol++;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.SlashRev: //Diagonal word populated down and to the left from the start location
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int maxStartRow = puzzleHeight - wordChars.Length;
                                int minStartCol = wordChars.Length;
                                startingRow = random.Next(0, maxStartRow);
                                startingCol = random.Next(minStartCol, puzzleWidth);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, currentCol].PuzzleChar != '\0' && testGrid[currentRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, currentCol] = new Letter(wordChars[i], true);
                                        currentRow++;
                                        currentCol--;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.BackslashFor: //Diagonal word populated down and to the right from the start location
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int maxStartRow = puzzleHeight - wordChars.Length;
                                int maxStartCol = puzzleWidth - wordChars.Length;
                                startingRow = random.Next(0, maxStartRow);
                                startingCol = random.Next(0, maxStartCol);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, currentCol].PuzzleChar != '\0' && testGrid[currentRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, currentCol] = new Letter(wordChars[i], true);
                                        currentRow++;
                                        currentCol++;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    case orientation.BackslashRev: //Diagonal word populated up and to the left from the starting position
                        {
                            bool okay = false;
                            while (!okay)
                            {
                                Letter[,] testGrid = CopyArray(grid.puzzle);
                                okay = true;
                                int minStartRow = wordChars.Length;
                                int minStartCol = wordChars.Length;
                                startingRow = random.Next(minStartRow, puzzleWidth);
                                startingCol = random.Next(minStartCol, puzzleHeight);
                                Point startPoint = new Point(startingRow, startingCol);
                                int currentRow = startingRow;
                                int currentCol = startingCol;
                                for (int i = 0; i < wordChars.Length; i++)
                                {
                                    if (testGrid[currentRow, currentCol].PuzzleChar != '\0' && testGrid[currentRow, currentCol].PuzzleChar != wordChars[i])
                                    {
                                        okay = false;
                                        break;
                                    }
                                    else
                                    {
                                        testGrid[currentRow, currentCol] = new Letter(wordChars[i], true);
                                        currentRow--;
                                        currentCol--;
                                    }
                                }
                                if (okay)
                                {
                                    grid.puzzle = CopyArray(testGrid);
                                    wordLocs.Add(word, startPoint);
                                }
                            }
                        }
                        break;

                    default: //should never reach here, but the default will be a horizontal, forward word
                        MessageBox.Show("A word orientation is not being properly selected", "Oh Dear");
                        break;
                }
            }
        }

        //FillLetters takes an existing puzzle grid and fills in the empty spots with random letters
        private void FillLetters(WordGrid grid)
        {
            Random random = new Random();
            int gridHeight = grid.Height;
            int gridWidth = grid.Width;
            for (int i = 0; i < gridHeight; i++)
            {
                for (int j = 0; j < gridWidth; j++)
                {
                    if (grid.puzzle[i, j].PuzzleChar == '\0')
                    {
                        int letterToAdd = random.Next(65, 91);
                        grid.puzzle[i, j].PuzzleChar = (char)letterToAdd;
                    }
                }
            }
        }

        private Letter[,] CopyArray(Letter[,] sourceArray)
        {
            int height = sourceArray.GetLength(0);
            int width = sourceArray.GetLength(1);
            Letter[,] copyOfArray = new Letter[height, width];
            Array.Copy(sourceArray, copyOfArray, height * width);
            return copyOfArray;
        }
    }
}
