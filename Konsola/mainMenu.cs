﻿using System;
using System.Collections.Generic;


namespace Konsola
{


    class MainMenus
    {
        public static int ID_Parse { get; set; }
        static public IList<Dane> DaneNowe;
        public static DateTime DateParse;
        



        static void Main()
        {
            

            DaneNowe = new List<Dane>();
            WriteJSON writeJSON = new WriteJSON();
            writeJSON.CheckFolder();
            MenuClass menuClass = new MenuClass();
            Console.ForegroundColor = ConsoleColor.Green;
            menuClass.Select_Menu();
            
        }





    }
}