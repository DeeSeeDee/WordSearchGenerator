using System;
using System.Windows.Forms;

namespace WordSearchGenerator
{
    public class TransparentLetter : Label
    {
        public bool isPartOfAWord;

        public TransparentLetter(bool isPartOfWord)
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
            this.Width = 15;
            isPartOfAWord = isPartOfWord;
        }
        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams parameters = base.CreateParams;
                parameters.ExStyle |= 0x20;
                return parameters;
            }
        }
    }
}
