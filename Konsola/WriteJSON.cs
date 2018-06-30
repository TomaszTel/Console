using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konsola
{
    class WriteJSON : MainMenus
    {

        public  string PatchFolder = Directory.GetCurrentDirectory().ToString()  + @"\Files";
        public const string NameFile = "JSON_DANE.JSON";
       


        public void CheckFolder()
        {
            
            try
            {
                if (!Directory.Exists(PatchFolder))
                {
                    CreateFolder();
                }
                else
                {
                    CheckFile();
                }
            }
            catch (Exception a)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
        public void CreateFolder()
        {
            try { 
            Directory.CreateDirectory(PatchFolder);
            }
            catch (Exception a)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
        public void CheckFile()
        {
            try
            {
                if(!File.Exists(PatchFolder + @"\" + NameFile))
                {
                    CreateFile();
                }


            }
            catch (Exception a)
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
}
        public void CreateFile()
        {
            try
            {
                File.Create(PatchFolder + @"\"+NameFile);

            }catch(Exception a)
            {

                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
    }
}
