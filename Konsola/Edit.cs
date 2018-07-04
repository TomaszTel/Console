using System;

namespace Konsola
{
    class Edit: MainMenus
    {
        Validate validate = new Validate();
        MenuClass menuClass = new MenuClass();

        public void EdiRe()
        {


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
            char Potwierdzenie = Console.ReadKey().KeyChar;
            ValEdi(Potwierdzenie,OpisM); 
   
        }
        protected void ValEdi(char potwierdzenie,string OpisM)
        {
            if (validate.Confirmation(potwierdzenie))
            {
                if (!validate.SearchOpisData(OpisM, DateParse))
                {
                    validate.OpisDatVal(OpisM, DateParse);

                    menuClass.Select_Menu();

                }
                else
                {
                    DeleteC delete = new DeleteC();
                    delete.ToRemove(ID_Parse);
                    Add add = new Add();
                    add.AddToClass(ID_Parse, DateParse, OpisM);
                    Console.Clear();
                    menuClass.Select_Menu();
                }

            }
        }
    }
}
