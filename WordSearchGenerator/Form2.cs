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
        public Form2(List<string> wordList)
        {
            InitializeComponent();
            WordPuzzle newPuzzle = new WordPuzzle(wordList);
            DisplayPuzzle(newPuzzle);
        }

        //Add a visible letter to the form at the specified position
        private TransparentLabel AddLetter(char labelChar, int x, int y)
        {
            TransparentLabel newLabel = new TransparentLabel();
            newLabel.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Bold, GraphicsUnit.Point, ((byte)(0)));
            newLabel.Text = new string(labelChar,1);
            newLabel.Location = new Point(x, y);
            newLabel.TextAlign = ContentAlignment.MiddleCenter;
            return newLabel;
        }

        private void DisplayPuzzle(WordPuzzle wordPuzzle)
        {
            WordGrid gridToParse = wordPuzzle.puzzleGrid;
            for(int i = 0; i < gridToParse.Height; i++){
                for (int j = 0; j < gridToParse.Width; j++){
                    char charAtGridLoc = gridToParse.puzzle[i][j];
                    int charXLoc = j * 20;
                    int charYloc = i * 20;
                    TransparentLabel letterToAdd = AddLetter(charAtGridLoc, charXLoc, charYloc);
                    this.Controls.Add(letterToAdd);
                }
            }
        }

        private void BuildView(int width, int height)
        {

        }
    }
}
