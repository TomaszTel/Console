using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Konsola
{


    class MainMenus
    {
        public static int ID_Parse { get; set; }
        static public IList<Dane> DaneNowe;
        public static DateTime DateParse;
        public const string confirmationY = "Y";
        public const string confirmationN = "N";




        static void Main()
        {

            Enum_Menu Menu = new Enum_Menu();

            Console.Title = "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            DaneNowe = new List<Dane>();
            Select_Menu();
            
        }


        public static void Select_Menu()
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
        public static void CheckNumber(string Number)
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
                    Preview preview = new Preview() ;
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
        public static bool Confitmation(string Key)
        {
            if(Key == confirmationY)
            {
                return true;
            }
            else if(Key == confirmationN)
            {
                return false;
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n!!Nie potwierdzono zapisu.. Zmiany nie zostały zapisane!! {0}", Environment.NewLine);
                Select_Menu();
                return false;
            }
        }

        public static Dane Search(int ID)
        {
            var Search = DaneNowe.Where(r => r.ID == ID).FirstOrDefault();
            return Search;
        }

        public static void MissingID()
        {
            Console.Title = "Błąd - Brak ID";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nNie znaleziono ID, naciśnij dowolny klawisz aby powrócić do Menu..");
            Console.ReadKey();
            Console.Clear();
            Select_Menu();
        }
       


    }
}