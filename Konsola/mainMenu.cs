using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Konsola
{


    class MainMenu
    {
        public static bool Utworzenie { get; set; }
        public static int IDLast { get; set; }
        static IList<Dane> DaneNowe;
        
        public enum Menu
        {
            Lista = 1,
            Dodawanie,
            Edycja,
            Usuwanie,
            Podgląd,
            Zakoncz,
            
            
        }
       

        static void Main()
        {
            Console.Title= "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            if (Utworzenie == false)
            {
                DaneNowe = new List<Dane>();
                Utworzenie = true;
            }
          

            string wybor = Wybierz_Menu();
            CheckNumber(wybor);
        }

      
        public static string  Wybierz_Menu()
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Main Menu:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("{5}1) {0}{5}2) {1}{5}3) {2}{5}4) {3}{5}5) {4}{5}6) {6}{5}",  Menu.Lista,  Menu.Dodawanie, Menu.Edycja, 
            Menu.Usuwanie, Menu.Podgląd, Environment.NewLine,Menu.Zakoncz);
            Console.Write("\nWybierz Akcje: ");
            return Console.ReadLine();

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
                    Modifi();
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
                    Main();
                    break;
            }

        }
        public static void Modifi()
        {
            try
            {
                Console.Title = "Edycja Rekordu";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Menu.Edycja);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nID: ");
                string ID = Console.ReadLine();
                int KonwersjaID = Int32.Parse(ID);
                IEnumerable WyszukajID = Search(KonwersjaID);
                if (WyszukajID.Cast<Object>().Count() == 0)
                {
                    MissingID();
                }

                foreach (Dane wysz in WyszukajID)
                {
                    Console.Write("\nData: ");
                    System.Windows.Forms.SendKeys.SendWait(wysz.Data);
                    string DataM = Console.ReadLine();
                    Console.Write("\nOpis: ");
                    System.Windows.Forms.SendKeys.SendWait(wysz.Opis);
                    string OpisM = Console.ReadLine();
              
                    Console.Write("\nCzy na pewno chcesz zmodyfikować wpis (Y/N)?");
                    string Potwierdzenie = Console.ReadLine();

                    if (Potwierdzenie == "Y" || Potwierdzenie == "y")
                    {
                        ToRemove(KonwersjaID);
                        AddEdit(true,DataM,OpisM, KonwersjaID);

                    }
                    else if (Potwierdzenie == "N" || Potwierdzenie == "n")
                    {
                        Console.Clear();
                        Main();
                    }
                    else
                    {
                        Console.Clear();
                        Console.ForegroundColor = ConsoleColor.Red;

                        Console.WriteLine("\n!!Nie potwierdzono zapisu.. Zmiany nie zostały zapisane!! {0}", Environment.NewLine);

                        Main();
                    }
                }
            }
            catch(FormatException)
            {
                Error();
            }
         

            
        }

        public static void ADD()
        {

            Console.Title = "Dodawanie rekordu";
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Menu.Dodawanie);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\nData: ");
            
            string Data = Console.ReadLine();
            Console.Write("\nOpis: ");
            string Opis = Console.ReadLine();
            
                Console.Write("\nCzy na pewno chcesz dodać rekord (Y/N)? ");
            
            string Potwierdzenie = Console.ReadLine();

            if (Potwierdzenie == "Y" || Potwierdzenie =="y")
            {
            
                if (IDLast != 0)
                {
                    IDLast = DaneNowe.Last().ID;
                }


                AddEdit(false,Data,Opis,IDLast);
            }
            else if (Potwierdzenie == "N" || Potwierdzenie =="n")
            {
                Console.Clear();
                Main();
            }
            else
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                
                Console.WriteLine("\n!!Nie potwierdzono zapisu.. Zmiany nie zostały zapisane!! {0}", Environment.NewLine);
                
                Main();
            }
            

        }
        public static void AddEdit(bool Edit, string Data, string Opis, int ID)
        {
          

            Dane DaneN = new Dane();
            if (IDLast == 0 && Edit == false)
            {
                DaneN.ID = 1;
                IDLast++;
            }
            else if (IDLast != 0 && Edit == false)
            {
                DaneN.ID = IDLast + 1;
            }
            else if (Edit == true)
            {
                DaneN.ID = ID;
            }
            DaneN.Data = Data;
            DaneN.Opis = Opis;
            DaneNowe.Add(DaneN);
            Console.Clear();
            Main();
        }
        public static void List()
        {
            Console.Title = "Lista rekordów";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(Menu.Lista);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Environment.NewLine);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("ID\t||Data\t        ||Opis\t");
            Console.ForegroundColor = ConsoleColor.Green;
           // DaneNowe.ForEach(i => Console.Write("{0}\t||{1}\t||{2}\t{3}", i.ID,i.Data,i.Opis,Environment.NewLine));
           foreach(var i in DaneNowe)
            {
                Console.Write("{0}\t||{1}\t||{2}\t{3}", i.ID, i.Data, i.Opis, Environment.NewLine);
            }
            Console.WriteLine(Environment.NewLine);
            
            Console.WriteLine("\nNacisnij dowolny klawisz aby powrócić..");

            Console.ReadKey();
            Console.Clear();

            Main();
        }
        public static IEnumerable  Search(int ID)
        {
             
            
            var Rekordy= from Rekord in DaneNowe
                           where Rekord.ID == ID
                           select Rekord;

            return Rekordy;
            
            
        }
        public static void Preview()
        {
            try {
                Console.Title = "Szczegóły rekordu";
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Menu.Podgląd);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nWprowadz ID: ");
            string ID = Console.ReadLine();
            int Konwertacja = Int32.Parse(ID);
            IEnumerable SearchResoult = Search(Konwertacja);
                if (SearchResoult.Cast<Object>().Count() == 0)
                {
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\nNie znaleziono Danych..{0}{0}", Environment.NewLine);
                    Console.ForegroundColor = ConsoleColor.Green;

                }


                foreach (Dane value in SearchResoult)
            {
                Console.Clear();
                Console.WriteLine("ID:" + value.ID);
                Console.WriteLine("Data:" + value.Data);
                Console.WriteLine("Opis:" + value.Opis);
                Console.WriteLine(Environment.NewLine);
            }
                
            Console.Write("\nNaciśnij dowolny klawisz aby powrócić..");
            Console.ReadKey();
            Console.Clear();
            Main();
               }catch(FormatException)
            {
                Error();
            }
        }
        public static void Delete()
        {
            try {
                Console.Title = "Usuwanie rekordu";
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine(Menu.Usuwanie);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("\nWprowadż ID do usunięcia: ");
            string ElementID = Console.ReadLine();
            int Konwersja = Int32.Parse(ElementID);

            var ElementDoUsuniecia = Search(Konwersja);
            if (ElementDoUsuniecia.Cast<Object>().Count() > 0)
            {
                Console.Clear();
                    ToRemove(Konwersja);
                    Console.WriteLine("\nUsunięto Wpis o ID :" + Konwersja);
                    Console.ReadKey();
                    Console.Clear();
                    IDLast--;
                    Main();
            }
            else
            {
                    MissingID();
            }
            }catch(FormatException)
            {
                Error();
            }

        }
        public static void ToRemove(int DoUsuniecia)
        {
            var ObiektDousuniecia = DaneNowe.Single(r => r.ID == DoUsuniecia);
            DaneNowe.Remove(ObiektDousuniecia);
        }
        public static void Error()
        {
            Console.Title = "Błąd - Wprowadzono nie poprawną wartość";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nWprowadzoną nie poprawną wartość...Naćiśnij dowolny klawisz aby powrócić do Menu..");
            Console.ReadKey();
            Console.Clear();
            Main();
        }
        public static void MissingID()
        {
            Console.Title = "Błąd - Brak ID";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nNie znaleziono ID, naciśnij dowolny klawisz aby powrócić do Menu..");
            Console.ReadKey();
            Console.Clear();
            Main();
        }

    }
}
