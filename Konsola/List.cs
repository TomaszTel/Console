
using System;

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
            foreach (var i in DaneNowe)
            {
                Console.Write("{0}\t||{1}\t||{2}\t{3}", i.ID, i.Data, i.Opis, Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);

            Console.WriteLine("\nNacisnij dowolny klawisz aby powrócić..");

            Console.ReadKey();
            Console.Clear();

            menuClass.Select_Menu();
        }
        

    }
}
