﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WordSearchGenerator
{
    class WordGrid
    {
        //WordGrid holds the characters of the puzzle and their locations in a jagged array.
        private int width;
        private int height;
        public Char[][] puzzle;

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
            this.puzzle = new Char[height][];
            for (int i = 0; i < height; i++)
            {
                this.puzzle[i] = new Char[width];
            }
        }

    }
}
