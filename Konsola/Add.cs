using System;
using System.Linq;

namespace Konsola
{
    class Add : MainMenus
    {
        private Validate validate;
        private MenuClass menuClass;

        public Add()
        {

        }

        public void ADD()
        {

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

            char potwierdzenie = char.ToUpper(Console.ReadKey().KeyChar);

            Val(potwierdzenie,Opis,Data);

        }
        protected void Val(char potwierdzenie, string opis, string data)
        {
            if (validate.Confirmation(potwierdzenie))
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
                if (!validate.SearchOpisData(opis, DateParse))
                {
                    validate.OpisDatVal(opis, DateParse);
                }
                else
                {
                    AddToClass(IDNew, DateParse, opis);

                }


            }

            Console.Clear();
            menuClass.Select_Menu();
        }
        public  void AddToClass(int ID, DateTime Date, string Opis)
        {
           
                Dane DaneN = new Dane(ID, Date, Opis);
                DaneNowe.Add(DaneN);
                WriteJSON writeJSON = new WriteJSON();
                writeJSON.JSON_Create();
            

           
        }
        

    }
}
