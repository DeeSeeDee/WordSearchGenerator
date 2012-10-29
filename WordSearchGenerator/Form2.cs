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
        private bool showAnswers;
        private List<string> WordList;
        private WordPuzzle FormWordPuzzle;
        private Panel lettersPanel;
        private Panel wordsPanel;
        private string Title;

        public Form2(List<string> wordList, string puzzleTitle)
        {
            InitializeComponent();
            Title = puzzleTitle;
            WordList = wordList;
            FormWordPuzzle = new WordPuzzle(wordList);
            DisplayPuzzle(FormWordPuzzle);
            showAnswers = false;
            BuildView();
        }

        private void DisplayPuzzle(WordPuzzle wordPuzzle)
        {
            lettersPanel = new Panel();
            WordGrid gridToParse = wordPuzzle.puzzleGrid;
            for (int i = 0; i < gridToParse.Height; i++)
            {
                for (int j = 0; j < gridToParse.Width; j++)
                {
                    Letter letterAtGridLoc = gridToParse.puzzle[i, j];
                    char charAtGridLoc = letterAtGridLoc.PuzzleChar;
                    bool isLetterInWord;
                    isLetterInWord = letterAtGridLoc.IsPartOfWord;
                    int charXLoc = j * 20 + 10;
                    int charYloc = i * 20 + 5;
                    Letter addThisLetter = new Letter(charAtGridLoc, isLetterInWord);
                    TransparentLetter letterToAdd = AddLetter(letterAtGridLoc, charXLoc, charYloc);
                    lettersPanel.Controls.Add(letterToAdd);
                }
            }
            puzzleHeight = gridToParse.Height * 20 + 10;
            puzzleWidth = gridToParse.Width * 20 + 15;
            lettersPanel.Size = new Size(puzzleWidth, puzzleHeight);
            lettersPanel.Location = new Point(20, 50);
            lettersPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        private void AddWordBox(int width, int height, List<string> wordList)
        {
            wordsPanel = new Panel();
            List<string> sortedList = wordList.ToList<string>();
            sortedList.Sort();
            int numWords = wordList.Count();
            double startRatio = numWords / 4;
            double startRatioCeiling = Math.Ceiling(startRatio);
            int wordsPerColumn = Convert.ToInt32(startRatioCeiling);
            int wordStartY = -13;
            int currentColumn = 1;
            int currentWordInColumn = 1;
            int currentWordX;
            int currentWordY;
            foreach (string word in sortedList)
            {
                currentWordX = (currentColumn - 1) * 125 + 5;
                currentWordY = wordStartY + (currentWordInColumn * 18);
                TransparentWord wordToAdd = AddWord(word, currentWordX, currentWordY);
                wordsPanel.Controls.Add(wordToAdd);
                if (currentWordInColumn > wordsPerColumn)
                {
                    currentColumn++;
                    currentWordInColumn = 1;
                }
                else
                    currentWordInColumn++;
            }
            wordsPanel.Location = new Point(20, puzzleHeight + 60);
            wordsPanel.Size = new Size(puzzleWidth, wordsPerColumn * 23);
            wordsPanel.BorderStyle = BorderStyle.FixedSingle;
        }

        //Add a visible letter to the letters panel at the specified position
        private TransparentLetter AddLetter(Letter labelLetter, int x, int y)
        {
            char labelChar = labelLetter.PuzzleChar;
            bool isPartOfWord = labelLetter.IsPartOfWord;
            TransparentLetter newLabel = new TransparentLetter(isPartOfWord);
            newLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            newLabel.Text = new string(labelChar, 1);
            newLabel.Location = new Point(x, y);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            return newLabel;
        }

        private TransparentWord AddWord(string word, int x, int y)
        {
            TransparentWord newWord = new TransparentWord();
            newWord.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            newWord.Text = word;
            newWord.Location = new Point(x, y);
            newWord.TextAlign = ContentAlignment.MiddleLeft;
            newWord.Size = new Size(150, 13);
            return newWord;
        }

        public void ShowAnswers(bool showAnswers)
        {
            if (showAnswers)
            {
                foreach (TransparentLetter tl in lettersPanel.Controls.OfType<TransparentLetter>())
                {
                    if (tl.isPartOfAWord)
                        tl.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                foreach (TransparentLetter tl in lettersPanel.Controls.OfType<TransparentLetter>())
                {
                    if (tl.isPartOfAWord)
                        tl.ForeColor = System.Drawing.Color.Black;
                }
            }
        }

        private void BuildView()
        {
            TransparentWord puzzleTitleLabel = new TransparentWord();
            puzzleTitleLabel.Text = Title;
            puzzleTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            puzzleTitleLabel.AutoSize = true;
            puzzleTitleLabel.BorderStyle = BorderStyle.Fixed3D;
            int puzzleTitleX = (puzzleWidth/2) - puzzleTitleLabel.Width/2 + 20;
            puzzleTitleLabel.Location = new Point(puzzleTitleX, 20);
            AddWordBox(puzzleWidth, puzzleHeight, this.WordList);
            this.Width = lettersPanel.Width + 60;
            this.Height = lettersPanel.Height + wordsPanel.Height + 100;
            this.Controls.Add(lettersPanel);
            this.Controls.Add(wordsPanel);
            this.Controls.Add(puzzleTitleLabel);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (showAnswers)
            {
                showAnswers = false;
                ShowAnswers(showAnswers);
            }
            else
            {
                showAnswers = true;
                ShowAnswers(showAnswers);
            }
        }
    }
}
