using System;

namespace Konsola
{
    class Preview : MainMenus
    {

        public  void PreviewV()
        {

            Parse parse = new Parse();

            Console.Title = "Szczegóły rekordu";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Podgląd);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWprowadz ID: ");
            string ID = Console.ReadLine();

            if (!parse.ParseID(ID))
            {
                Select_Menu();
            }
            Dane SearchResoult = Search(ID_Parse);
            if (SearchResoult == null)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nNie znaleziono Danych..{0}{0}", Environment.NewLine);
                Console.ForegroundColor = ConsoleColor.Green;

            }


            Console.Clear();
            Console.WriteLine("ID:" + SearchResoult.ID);
            Console.WriteLine("Data:" + SearchResoult.Data);
            Console.WriteLine("Opis:" + SearchResoult.Opis);
            Console.WriteLine(Environment.NewLine);


            Console.Write("\nNaciśnij dowolny klawisz aby powrócić..");
            Console.ReadKey();
            Console.Clear();
            Select_Menu();

        }
    }
}
