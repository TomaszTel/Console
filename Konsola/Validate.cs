﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Konsola
{

    class Validate
    {
        public IList<Dane> Dane { get; set; }

        public Validate(IList<Dane> dane)
        {
            Dane = dane;
        }

        public const char confirmatoinY = 'Y';
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

        public bool Confirmation(char key)
        {


            char potwierdzenie = key;

            char upper = char.ToUpper(potwierdzenie);

            if (upper == confirmationY)
            {
                return true;
            }
            else if (upper == confirmationN)
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
            return Dane.Where(r => r.ID == ID).FirstOrDefault();
        }
        public bool SearchOpisData(string opis, DateTime Data)
        {
            return Dane.Any(r => r.Opis == opis && r.Data == Data);
        }
       
        public static void OpisDatVal(string Op, DateTime Data)
        {
            Console.Clear();
            Console.Title = "Error";
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Istnieje rekord o Opisie: {0} Na datę: {1} Zmiany nie zostaną zapisane", Op, Data);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("{0}Naciśnij klawisz aby powrócić...", Environment.NewLine);
            Console.ReadKey();
            Console.Clear();
        }
    }
}
