
using System;
namespace Konsola
{
    class Parse : MainMenus
    {
        public bool ParseID(string ID)
        {
            int a;

            if (!int.TryParse(ID, out  a))
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
        public  bool ParseDate(string DataM)
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
