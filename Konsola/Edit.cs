using System;

namespace Konsola
{
    class Edit: MainMenus
    {
        public void EdiRe()
        {
            MenuClass menuClass = new MenuClass();
            Validate validate = new Validate();


            Console.Title = "Edycja Rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Edycja);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nID: ");
            string ID = Console.ReadLine();
            Parse parse = new Parse();
            if (!parse.ParseID(ID))
            {
                menuClass.Select_Menu();
            }
            Dane WyszukajID = validate.Search(ID_Parse);
            if (WyszukajID == null)
            {
                validate.MissingID();
            }

            Console.Write("\nData: ");
            System.Windows.Forms.SendKeys.SendWait(WyszukajID.Data.ToShortDateString());
            string DataM = Console.ReadLine();
            Console.Write("\nOpis: ");
            System.Windows.Forms.SendKeys.SendWait(WyszukajID.Opis);
            string OpisM = Console.ReadLine();

            if (!parse.ParseDate(DataM))
            {
                EdiRe();
            }

            Console.Write("\nCzy na pewno chcesz zmodyfikować wpis (Y/N)?");
            string Potwierdzenie = Console.ReadLine();
            
         


            if (validate.Confitmation(Potwierdzenie))
            {
                Add add = new Add();
                add.AddToClass(ID_Parse, DateParse, OpisM);
                DeleteC delete = new DeleteC();                
                delete.ToRemove(ID_Parse); 
                Console.Clear();
                menuClass.Select_Menu();
            }


        }
    }
}
