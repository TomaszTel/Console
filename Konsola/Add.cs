using System;
using System.Linq;

namespace Konsola
{
    class Add : MainMenus
    {
        public  void ADD()
        {

            Console.Title = "Dodawanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Dodawanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nData: ");
            string Data = Console.ReadLine();
            if (!ParseDate(Data))
            {
                Select_Menu();
            }

            Console.Write("\nOpis: ");
            string Opis = Console.ReadLine();

            Console.Write("\nCzy na pewno chcesz dodać rekord (Y/N)? ");

            string Potwierdzenie = Console.ReadLine();

            if (Confitmation(Potwierdzenie))
            {
                int IDNew;
                if (DaneNowe.Count == 0)
                {
                    IDNew = 1;
                }
                else
                {
                    IDNew = DaneNowe.Last().ID;
                    IDNew++;
                }

                AddToClass(IDNew, DateParse, Opis);

            }
            else
            {
                Console.Clear();
                Select_Menu();
            }
            Console.Clear();
            Select_Menu();
        }
        public  void AddToClass(int ID, DateTime Data, string Opis)
        {
            Dane DaneN = new Dane(ID, Data, Opis);
            DaneNowe.Add(DaneN);
        }

    }
}
