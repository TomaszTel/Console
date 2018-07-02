using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;


namespace Konsola
{

    class WriteJSON : MainMenus
    {

        public  string PatchFolder = Directory.GetCurrentDirectory().ToString()  + @"\Files";
        public  string NameFile = "JSON_DANE.JSON";
        
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
                Console.Title = "Error" + a.Message;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
        public void CreateFolder()
        {
            try { 
            Directory.CreateDirectory(PatchFolder);
                CheckFile();
            }
            catch (Exception a)
            {
                Console.Clear();
                Console.Title = "Error" + a.Message;
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
                else
                {
                    JSON_Read();
                }

            }   
            catch (Exception a)
            {
                Console.Clear();
                Console.Title = "Error" + a.Message;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
}
        public void JSON_Create()
        {
            string json = JsonConvert.SerializeObject(DaneNowe);
            File.WriteAllText(PatchFolder + "/" + NameFile, json);   
        }
        public void JSON_Read()
        {

            var text = File.ReadAllText(PatchFolder + "/" + NameFile);
            IList<Dane> result = JsonConvert.DeserializeObject<IList<Dane>>(text);
            foreach(Dane JSON in result)
            {
                DaneNowe.Add(new Dane(JSON.ID,JSON.Data,JSON.Opis)); 
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
                Console.Title = "Error" + a.Message;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(a);
                Console.ReadKey();
            }
        }
    }
}
