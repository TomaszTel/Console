using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsola
{
    class DeleteC : MainMenus
    {
        public void Delete()
        {

            Console.Title = "Usuwanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Usuwanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWprowadż ID do usunięcia: ");
            string ElementID = Console.ReadLine();
            Parse parse = new Parse();
            if (!parse.ParseID(ElementID))
            {
                Select_Menu();
            }

            Dane ElementDoUsuniecia = Search(ID_Parse);
            if (ElementDoUsuniecia != null)
            {
                Console.Clear();
                ToRemove(ID_Parse);
                Console.WriteLine("\nUsunięto Wpis o ID :" + ID_Parse);
                Console.ReadKey();
                Console.Clear();
                Select_Menu();
            }
            else
            {
                MissingID();
            }


        }
        public void ToRemove(int DoUsuniecia)
        {

            Dane SearchIn = Search(DoUsuniecia);
            var ObiektDousuniecia1 = DaneNowe.IndexOf(SearchIn);
            DaneNowe.RemoveAt(ObiektDousuniecia1);
        }


    }
}
