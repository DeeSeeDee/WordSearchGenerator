using System;
using System.Windows.Forms;

namespace WordSearchGenerator
{
    public class TransparentWord : Label
    {
        public TransparentWord()
        {
            this.SetStyle(ControlStyles.Opaque, true);
            this.SetStyle(ControlStyles.OptimizedDoubleBuffer, false);
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
