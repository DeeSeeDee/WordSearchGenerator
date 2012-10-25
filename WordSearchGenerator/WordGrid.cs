using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordSearchGenerator
{
    class WordGrid
    {
        //WordGrid holds the characters of the puzzle and their locations in a two-dimensional array.
        private int width;
        private int height;
        public Letter[,] puzzle;

        public int Width
        {
            get { return width; }
        }
        public int Height
        {
            get { return height; }
        }

        public WordGrid(int width, int height)
        {
            this.width = width;
            this.height = height;
            this.puzzle = new Letter[height, width];
        }

    }
}
