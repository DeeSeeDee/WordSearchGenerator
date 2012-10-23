using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordSearchGenerator
{
    public partial class Form2 : Form
    {

        private int puzzleWidth;
        private int puzzleHeight;

        public Form2(List<string> wordList)
        {
            InitializeComponent();
            WordPuzzle newPuzzle = new WordPuzzle(wordList);
            DisplayPuzzle(newPuzzle);
            AddWordBox(puzzleWidth, puzzleHeight, wordList);
        }

        //Add a visible letter to the form at the specified position
        private TransparentLabel AddLetter(char labelChar, int x, int y)
        {
            TransparentLabel newLabel = new TransparentLabel();
            newLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            newLabel.Text = new string(labelChar, 1);
            newLabel.Location = new Point(x, y);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            return newLabel;
        }

        private TransparentLabel AddWord(string word, int x, int y)
        {
            TransparentLabel newLabel = new TransparentLabel();
            newLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            newLabel.Text = word;
            newLabel.Location = new Point(x, y);
            newLabel.TextAlign = ContentAlignment.MiddleLeft;
            newLabel.Size = new Size(150, 13);
            return newLabel;
        }

        private void DisplayPuzzle(WordPuzzle wordPuzzle)
        {
            WordGrid gridToParse = wordPuzzle.puzzleGrid;
            for (int i = 0; i < gridToParse.Height; i++)
            {
                for (int j = 0; j < gridToParse.Width; j++)
                {
                    char charAtGridLoc = gridToParse.puzzle[i][j];
                    int charXLoc = j * 20;
                    int charYloc = i * 20;
                    TransparentLabel letterToAdd = AddLetter(charAtGridLoc, charXLoc, charYloc);
                    this.Controls.Add(letterToAdd);
                }
            }
            puzzleHeight = gridToParse.Height * 20;
            puzzleWidth = gridToParse.Width * 20;
        }

        private void AddWordBox(int width, int height, List<string> wordList)
        {
            List<string> sortedList = wordList.ToList<string>();
            sortedList.Sort();
            int StartPointX = puzzleHeight + 50;
            int StartPointY = 0;
            int currentX = StartPointX;
            int currentY = StartPointY;
            int numWords = wordList.Count();
            double startRatio = numWords / 4;
            double startRatioCeiling = Math.Ceiling(startRatio);
            int wordsPerColumn = Convert.ToInt32(startRatioCeiling);
            int wordStartY = puzzleHeight + 13;
            int currentColumn = 1;
            int currentWordInColumn = 1;
            int currentWordX;
            int currentWordY = wordStartY;
            foreach (string word in sortedList)
            {
                currentWordX = (currentColumn * 125) - 75;
                currentWordY = wordStartY + (currentWordInColumn * 20);
                TransparentLabel wordToAdd = AddWord(word, currentWordX, currentWordY);
                this.Controls.Add(wordToAdd);
                if (currentWordInColumn > wordsPerColumn)
                {
                    currentColumn++;
                    currentWordInColumn = 1;
                }
                else
                    currentWordInColumn++;
            }
        }

        private void BuildView(int width, int height)
        {
        }
    }
}
