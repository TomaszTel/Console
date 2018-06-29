using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsola
{
    class MenuClass : MainMenus
    {

        public  void Select_Menu()
        {

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Main Menu:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{5}1) {0}{5}2) {1}{5}3) {2}{5}4) {3}{5}5) {4}{5}6) {6}{5}", Enum_Menu.Menu.Lista, Enum_Menu.Menu.Dodawanie, Enum_Menu.Menu.Edycja,
            Enum_Menu.Menu.Usuwanie, Enum_Menu.Menu.Podgląd, Environment.NewLine, Enum_Menu.Menu.Zakoncz);
            Console.Write("\nWybierz Akcje: ");
            string Wybor = Console.ReadLine();
            CheckNumber(Wybor);
        }
        public  void CheckNumber(string Number)
        {
            Console.Clear();

            switch (Number)
            {
                case "1":
                    Lists lists = new Lists();
                    lists.List();
                    break;
                case "2":
                    Add add = new Add();
                    add.ADD();
                    break;
                case "3":
                    Edit SEdit = new Edit();
                    SEdit.EdiRe();
                    break;
                case "4":
                    DeleteC delete = new DeleteC();
                    delete.Delete();
                    break;
                case "5":
                    Preview preview = new Preview();
                    preview.PreviewV();
                    break;
                case "6":
                    Environment.Exit(0);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("\nWybrano nie poprawny numer..");
                    Console.ReadKey();
                    Console.Clear();
                    Select_Menu();
                    break;
                   
            }

        }


    }
}
