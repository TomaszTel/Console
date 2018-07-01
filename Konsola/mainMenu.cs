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
            DaneNowe = new List<Dane>();
            WriteJSON writeJSON = new WriteJSON();
            writeJSON.CheckFolder();
            Enum_Menu Menu = new Enum_Menu();
            MenuClass menuClass = new MenuClass();
            Console.Title = "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            menuClass.Select_Menu();
            
        }





    }
}