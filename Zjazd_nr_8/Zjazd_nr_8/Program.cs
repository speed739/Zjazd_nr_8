using System;
using System.Collections.Generic;

namespace Zjazd_nr_8
{
    class Program
    {
        class Printer
        {
            public event EventHandler<OutofpaperEventArgs> Out_of_paper;
            public event EventHandler <OutofToner> Out_of_Toner;
            int paper_count;

            public Printer(int paper_count)
            {
                this.paper_count = paper_count;
            }
           
            public void Print(int n)
            {
                if (paper_count == 0)
                {
                    Out_of_paper?.Invoke(this,
                        new OutofpaperEventArgs(n));
                    return;
                }
                else
                {
                    paper_count--;
                    Console.WriteLine("{0} Pags_Printed...", n);
                }
            }

        }
        public class OutofpaperEventArgs : EventArgs
        {
            int page_number;
            public OutofpaperEventArgs(int page_number)
            {
                this.page_number = page_number;

            }

        }
        public class OutofToner:EventArgs
        {

            int[] tab = new int[2];
            public OutofToner(int []tab)
            {
                this.tab = tab;
            }

        }

        static bool printerOk = true;
        static void Main(string[] args)
        {

            var drukarka = new Printer(100);
            drukarka.Out_of_paper += Out_of_Paper2;

            for (int i = 1; i < 250; i++)
            {

                drukarka.Print(i);
                if (!printerOk)
                {
                    return;
                }

            }

        }
        static void Out_of_Paper2(object sender, EventArgs args)
        {
            Console.WriteLine("Brak papieru !!!");
            
        }

    }

}
