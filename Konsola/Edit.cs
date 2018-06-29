﻿using System;

namespace Konsola
{
    class Edit: MainMenus
    {
        public void EdiRe()
        {

            Console.Title = "Edycja Rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Edycja);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nID: ");
            string ID = Console.ReadLine();
            if (!ParseID(ID))
            {
                Select_Menu();
            }
            Dane WyszukajID = Search(ID_Parse);
            if (WyszukajID == null)
            {
                MissingID();
            }

            Console.Write("\nData: ");
            System.Windows.Forms.SendKeys.SendWait(WyszukajID.Data.ToShortDateString());
            string DataM = Console.ReadLine();
            Console.Write("\nOpis: ");
            System.Windows.Forms.SendKeys.SendWait(WyszukajID.Opis);
            string OpisM = Console.ReadLine();

            if (!ParseDate(DataM))
            {
                Edit();
            }

            Console.Write("\nCzy na pewno chcesz zmodyfikować wpis (Y/N)?");
            string Potwierdzenie = Console.ReadLine();


            if (Confitmation(Potwierdzenie))
            {
                ToRemove(ID_Parse);

                AddToClass(ID_Parse, DateParse, OpisM);
                Console.Clear();
                Select_Menu();
            }
            else
            {

                Console.Clear();
                Select_Menu();
            }

        }
    }
}
