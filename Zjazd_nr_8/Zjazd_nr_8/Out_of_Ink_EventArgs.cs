using System;
using System.Collections.Generic;
using System.Text;

namespace Zjazd_nr_8
{
    public class OutOfInkEventArgs : EventArgs
    {
        public OutOfInkEventArgs(string c)
        {
            Kolor = c;
        }
        public string Kolor;
    }
}



