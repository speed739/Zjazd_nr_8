using System;
using System.Collections.Generic;
using System.Linq;

namespace Zjazd_nr_8
{
    class Program
    {
        static bool printerOk = true;
        static void Main(string[] args)
        {
            var drukarka = new Printer(20);

            drukarka.Out_of_paper += Out_of_Paper2;
            drukarka.Out_of_Toner += Drukarka_Out_of_Toner;

            for (int i = 1; i <30; i++)
            {
                drukarka.Print(i);
                if (!printerOk)
                {
                    return;
                }
            }
        }
        static void Drukarka_Out_of_Toner(object sender, OutOfInkEventArgs args)
        {
            Console.WriteLine("Brak Tuszu " + args.Color);
            printerOk = false;
        }
        static void Out_of_Paper2(object sender, EventArgs args)
        {
            Console.WriteLine("Brak papieru !!!");
            printerOk = false;
        }

    }

}
