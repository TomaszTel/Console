﻿
using System;
using System.Collections.Generic;
using System.Linq;

namespace Konsola
{
    class Lists : MainMenus
    {
        public void List()
        {
            MenuClass menuClass = new MenuClass();

            Console.Title = "Lista rekordów";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Lista);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ID\t||Data\t        ||Opis\t");
            Console.ForegroundColor = ConsoleColor.Green;
            IList<Dane> OrderList = DaneNowe.OrderBy(i => i.ID).ToList();

            foreach (var i in OrderList)
            {
                Console.WriteLine($"{i.ID}\t||{i.Data.ToShortDateString()}\t||{i.Opis}\t");
                //Console.WriteLine(string.Format("{0}\t||{1}\t||{2}\t", i.ID, i.Data, i.Opis));
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("\nNacisnij dowolny klawisz aby powrócić..");

            Console.ReadKey();
            Console.Clear();

            menuClass.Select_Menu();
        }


    }
}
