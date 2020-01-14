using System;
using System.Collections.Generic;
using System.Text;

namespace Zjazd_nr_8
{
    class Printer
    {
        public event EventHandler<OutofpaperEventArgs> Out_of_paper;
        public event EventHandler<OutOfInkEventArgs> Out_of_Toner;
        int paper_count;
        List<Ink> inks_levels;
       
        public Printer()
        {
            Out_of_paper += Out_of_Paper2;
            Out_of_Toner += Drukarka_Out_of_Toner;
            inks_levels = new List<Ink>{
                new Ink("Czarny",1),
                new Ink("Kolor",1)
            };
        }
        public Printer(int paper_count) : this()
        {
            this.paper_count = paper_count;
        }

        public void Print(int pageNumber)
        {
            if (paper_count == 0)
            {
                Out_of_paper?.Invoke(this, new OutofpaperEventArgs(pageNumber));
                return;
            }
            else
            {
                foreach (var ink in inks_levels)
                {
                    if (ink.Level <= 0)
                    {
                        Out_of_Toner.Invoke(this, new OutOfInkEventArgs(ink.Color));
                        return;
                    }
                }

                Console.WriteLine("Print...");
                --paper_count;

                foreach (var ink in inks_levels)
                {
                    ink.Level -= 0.2;
                }
            }
        }
        private void Drukarka_Out_of_Toner(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine("Brak Tuszu " + args.Color);
            
        }
        private void Out_of_Paper2(object sender, EventArgs args)
        {
            Console.WriteLine("Brak papieru !!!");
            
        }
    }
}
