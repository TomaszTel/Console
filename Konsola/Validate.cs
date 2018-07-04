using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Konsola
{

    class Validate : MainMenus
    {

        public const char confirmationY = 'Y';
        public const char confirmationN = 'N';



        MenuClass menuClass = new MenuClass();

        public void MissingID()
        {

            Console.Title = "Błąd - Brak ID";
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\nNie znaleziono ID, naciśnij dowolny klawisz aby powrócić do Menu..");
            Console.ReadKey();
            Console.Clear();
            menuClass.Select_Menu();
        }
        private void NoSaveConf()
        {
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n!!Nie potwierdzono zapisu.. Zmiany nie zostały zapisane!! {0}", Environment.NewLine);
            menuClass.Select_Menu();
        }

        public bool Confitmation(string Key)
        {
            if(Key.Length != 1 )
            {
                NoSaveConf();
                return false;
            }

            char Potw = Key[0];

            char Upper = char.ToUpper(Potw);

            if (Upper == confirmationY)
            {
                return true;
            }
            else if (Upper == confirmationN)
            {
                NoSaveConf();
                return false;
            }
            else
            {
                NoSaveConf();
                return false;
            }
        }
        public Dane Search(int ID)
        {
            var Search = DaneNowe.Where(r => r.ID == ID).FirstOrDefault();
            return Search;
        }
        public bool SearchOpisData(string opis, DateTime Data)
        {
          
         if(DaneNowe.Where(r => r.Opis == opis && r.Data == Data).Count() == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }
        public void Exception(Exception Ex)
        {
            Console.Clear();
            Console.Title = "Error" + Ex.Message;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Ex);
            Console.ReadKey();
            
        }
        public void OpisDatVal(string Op, DateTime Data)
        {
            Console.Clear();
            Console.Title = "Error";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Istnieje rekord o Opisie: {0} Na datę: {1} Zmiany nie zostaną zapisane",Op,Data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}Naciśnij klawisz aby powrócić...", Environment.NewLine);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
