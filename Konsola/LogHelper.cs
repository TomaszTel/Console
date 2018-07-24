using System;

namespace Konsola
{
    public static class LogHelper
    {
        public static void LogException(Exception ex)
        {
            Console.Clear();
            Console.Title = "Error" + ex.Message;
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(ex);
            Console.ReadKey();
        }
    }
}
