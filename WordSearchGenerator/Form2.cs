using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Printing;

namespace WordSearchGenerator
{
    public partial class Form2 : Form
    {

        private int puzzleWidth;
        private int puzzleHeight;
        private bool showAnswers;
        private List<string> WordList;
        private WordPuzzle FormWordPuzzle;
        private Panel parentPanel;
        private Panel lettersPanel;
        private Panel wordsPanel;
        private string Title;
        private Form1 firstForm;
        Bitmap memoryImage;

        public Form2(List<string> wordList, string puzzleTitle, int difficultyIndex, int height, int width, Form1 form)
        {
            InitializeComponent();
            firstForm = form;
            Title = puzzleTitle;
            WordList = wordList;
            puzzleHeight = height;
            puzzleWidth = width;
            FormWordPuzzle = new WordPuzzle(wordList, puzzleHeight, puzzleWidth, difficultyIndex);
            DisplayPuzzle(FormWordPuzzle);
            showAnswers = false;
            BuildView();
        }

        //Place the panels in the appropriate places on the form
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

        //Create a word box whose size and number of words per each of the four columns is based on the number of words and the puzzle width
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
                currentWordX = (currentColumn - 1) * (puzzleWidth / 4) + 5;
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

        //Add a word instead of a letter
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

        //Highlight the words in red
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

        //Place the controls on the form
        private void BuildView()
        {
            parentPanel = new Panel();
            TransparentWord puzzleTitleLabel = new TransparentWord();
            puzzleTitleLabel.Text = Title;
            puzzleTitleLabel.TextAlign = ContentAlignment.MiddleCenter;
            puzzleTitleLabel.AutoSize = true;
            puzzleTitleLabel.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            int puzzleTitleX = (lettersPanel.Width) / 2;
            puzzleTitleLabel.Left = puzzleTitleX;
            puzzleTitleLabel.Top = 30;
            AddWordBox(puzzleWidth, puzzleHeight, this.WordList);
            parentPanel.Width = lettersPanel.Width + 60;
            parentPanel.Height = lettersPanel.Height +wordsPanel.Height + 100;
            parentPanel.Controls.Add(puzzleTitleLabel);
            parentPanel.Controls.Add(lettersPanel);
            parentPanel.Controls.Add(wordsPanel);
            parentPanel.BackColor = System.Drawing.Color.Transparent;
            parentPanel.BorderStyle = BorderStyle.None;
            this.Width = lettersPanel.Width + 60;
            this.Height = lettersPanel.Height + wordsPanel.Height + 100;
            this.Controls.Add(parentPanel);
        }

        private void showButton_Click(object sender, EventArgs e)
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

        //Toolbar buttons

        //printing logic
        private void printToolStripButton_Click(object sender, EventArgs e)
        {
            PrintDocument document = new PrintDocument();
            document.PrintPage += new PrintPageEventHandler(document_PrintPage);
            CapturePanel();
            document.Print();
        }

        private void CapturePanel()
        {
            Graphics myGraphics = this.CreateGraphics();
            Size s = new Size(850, 1100);
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            this.parentPanel.DrawToBitmap(memoryImage, new Rectangle(this.parentPanel.Location, this.parentPanel.Size));            
        }

        void document_PrintPage(object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(memoryImage, 0, 0);
        }

        //The options button shows the first form again, with the same options.
        private void optionsButton_Click(object sender, EventArgs e)
        {
            firstForm.Show();
            WordList.Clear();
            this.Hide();
        }

        //Form behavior
        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            firstForm.Close();
        }

        private void Form2_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible == false)
                this.Controls.Clear();

        }

        private void aboutButton_Click(object sender, EventArgs e)
        {
            About aboutForm = new About();
            aboutForm.Show();
        }
    }
}
