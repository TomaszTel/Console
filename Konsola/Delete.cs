using System;

namespace Konsola
{
    class DeleteC
    {
        Validate GetValidate = new Validate(DaneNowe);
        MenuClass menuClass = new MenuClass();

        public void Delete()
        {
            Console.Title = "Usuwanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Usuwanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWprowadż ID do usunięcia: ");
            string ElementID = Console.ReadLine();
            Console.Write("\nCzy na pewno chcesz usunąć rekord (Y/N)? ");
            char Potwierdzenie = Console.ReadKey().KeyChar;
            valDel(Potwierdzenie,ElementID);
            
        }
        protected void valDel(char Potwierdzenie,string ID)
        {
            Validate validate = new Validate();

            if (validate.Confirmation(Potwierdzenie))
            {
                Parse parse = new Parse();
                if (!parse.ParseID(ID))
                {
                    menuClass.Select_Menu();
                }

                Dane ElementDoUsuniecia = GetValidate.Search(ID_Parse);
                if (ElementDoUsuniecia != null)
                {
                    Console.Clear();
                    ToRemove(ID_Parse);
                    Console.WriteLine("\nUsunięto Wpis o ID :" + ID_Parse);
                    Console.ReadKey();
                    Console.Clear();
                    menuClass.Select_Menu();
                }
                else
                {
                    validate.MissingID();
                }

            }
        }
        public void ToRemove(int DoUsuniecia)
        {

            Dane SearchIn = GetValidate.Search(DoUsuniecia);
            var ObiektDousuniecia1 = DaneNowe.IndexOf(SearchIn);
            DaneNowe.RemoveAt(ObiektDousuniecia1);

            WriteJSON writeJSON = new WriteJSON();
            writeJSON.JSON_Create();
        }

       


    }
}
