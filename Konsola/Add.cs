using System;
using System.Linq;

namespace Konsola
{
    class Add : MainMenus
    {
        Validate validate = new Validate();

        public void ADD()
        {
            MenuClass menuClass = new MenuClass();

            Console.Title = "Dodawanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Dodawanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nData: ");
            string Data = Console.ReadLine();

            Parse parse = new Parse();

            if (!parse.ParseDate(Data))
            {

                menuClass.Select_Menu();
            }

            Console.Write("\nOpis: ");
            string Opis = Console.ReadLine();

            Console.Write("\nCzy na pewno chcesz dodać rekord (Y/N)? ");

            string Potwierdzenie = Console.ReadLine();
           

            if (validate.Confitmation(Potwierdzenie))
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
         
            Console.Clear();
            menuClass.Select_Menu();
        }
        public  void AddToClass(int ID, DateTime Date, string Opis)
        {
           if(!validate.SearchOpisData(Opis,Date))
            {
                validate.OpisVal(Opis,Date);
            }
            else
            {
                Dane DaneN = new Dane(ID, Date, Opis);
                DaneNowe.Add(DaneN);
                WriteJSON writeJSON = new WriteJSON();
                writeJSON.JSON_Create();
            }

           
        }

    }
}
