using System;
using System.Collections.Generic;


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
            MenuClass menuClass = new MenuClass();
            Console.Title = "Main Menu";
            Console.ForegroundColor = ConsoleColor.Green;
            menuClass.Select_Menu();
            
        }





    }
}