using System;
using System.Linq;

namespace Konsola
{

    class Validate : MainMenus
    {

        public const string confirmationY = "Y";
        public const string confirmationN = "N";



        MenuClass menuClass = new MenuClass();

        public void MissingID()
        {

            Console.Title = "Błąd - Brak ID";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nNie znaleziono ID, naciśnij dowolny klawisz aby powrócić do Menu..");
            Console.ReadKey();
            Console.Clear();
            menuClass.Select_Menu();
        }
        public bool Confitmation(string Key)
        {
            if (Key == confirmationY)
            {
                return true;
            }
            else if (Key == confirmationN)
            {
                return false;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n!!Nie potwierdzono zapisu.. Zmiany nie zostały zapisane!! {0}", Environment.NewLine);
                menuClass.Select_Menu();
                return false;
            }
        }
        public Dane Search(int ID)
        {
            var Search = DaneNowe.Where(r => r.ID == ID).FirstOrDefault();
            return Search;
        }
    }
}
