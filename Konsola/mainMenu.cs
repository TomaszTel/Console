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
            MenuClass menuClass = new MenuClass();

            Console.Title = "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            DaneNowe = new List<Dane>();
            menuClass.Select_Menu();
            
        }





    }
}