using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace Konsola
{


    class MainMenus
    {
        public static int ID_Parse { get; set; }
        static IList<Dane> DaneNowe;
        public static DateTime DateParse;
        public const string confirmationY = "Y";
        public const string confirmationN = "N";




        static void Main()
        {

            Enum_Menu Menu = new Enum_Menu();

            Console.Title = "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            if (DaneNowe == null)
            {
                DaneNowe = new List<Dane>();
             
            }
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
                    List();
                    break;
                case "2":
                    ADD();
                    break;
                case "3":
                    Edit SEdit = new Edit();
                    SEdit.EdiRe();
                    break;
                case "4":
                    Delete();
                    break;
                case "5":
                    Preview();
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

        public static void ADD()
        {

            Console.Title = "Dodawanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Dodawanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nData: ");
            string Data = Console.ReadLine();
            if (!ParseDate(Data))
            {
                Select_Menu();
            }

            Console.Write("\nOpis: ");
            string Opis = Console.ReadLine();

            Console.Write("\nCzy na pewno chcesz dodać rekord (Y/N)? ");

            string Potwierdzenie = Console.ReadLine();

            if(Confitmation(Potwierdzenie))
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
            else
            {
                Console.Clear();
                Select_Menu();
            }
            Console.Clear();
            Select_Menu();
        }
        public static void AddToClass(int ID, DateTime Data, string Opis)
        {
            Dane DaneN = new Dane(ID, Data, Opis);
            DaneNowe.Add(DaneN);
        }
        public static void List()
        {
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

            Select_Menu();
        }
        public static Dane Search(int ID)
        {
              var Search =  DaneNowe.Where(r => r.ID == ID).FirstOrDefault();
                 return Search;
        }
        public static void Preview()
        {

            Console.Title = "Szczegóły rekordu";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Podgląd);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWprowadz ID: ");
            string ID = Console.ReadLine();

            if (!ParseID(ID))
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
        public static void Delete()
        {

            Console.Title = "Usuwanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Enum_Menu.Menu.Usuwanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nWprowadż ID do usunięcia: ");
            string ElementID = Console.ReadLine();
            if (!ParseID(ElementID))
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
        public static void ToRemove(int DoUsuniecia)
        {
           
            var ObiektDousuniecia = DaneNowe.Where(r => r.ID == DoUsuniecia).FirstOrDefault();
            var ObiektDousuniecia1 = DaneNowe.IndexOf(ObiektDousuniecia);
            DaneNowe.RemoveAt(ObiektDousuniecia1);
        }
        public static bool ParseID(string ID)
        {

            if (!int.TryParse(ID, out int a))
            {
                Console.Title = "Błąd - Wprowadzono nie poprawną wartość";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\nWprowadzoną nie poprawną wartość...Naćiśnij dowolny klawisz aby powrócić do Menu..");
                Console.ReadKey();
                Console.Clear();
                return false;
            }
            ID_Parse = a;
            return true;


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
        public static bool ParseDate(string DataM)
        {
          
            if (!DateTime.TryParse(DataM, out DateParse))
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Wprowadzono nie poprawny format daty!");
                Console.WriteLine(Environment.NewLine);

                return false;
            }
            return true;
        }


    }
}