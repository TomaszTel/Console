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
                Validate validate = new Validate();
                validate.Exception(a);
            }
        }
        private void CreateFolder()
        {
            try { 
            Directory.CreateDirectory(PatchFolder);
                CheckFile();
            }
            catch (Exception a)
            {
                LogHelper.LogException(a);
            }
        }
        private void CheckFile()
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
                Validate validate = new Validate();
                validate.Exception(a);
            }
}
        public void JSON_Create()
        {
            string json = JsonConvert.SerializeObject(DaneNowe);
            File.WriteAllText(PatchFolder + "/" + NameFile, json);   
        }
        private void JSON_Read()
        {
            if (new FileInfo(PatchFolder + @"\" + NameFile).Length > 0)
            {
                var text = File.ReadAllText(PatchFolder + "/" + NameFile);
                IList<Dane> result = JsonConvert.DeserializeObject<IList<Dane>>(text);
                // Odrazu masz kolekcje
                foreach (Dane JSON in result)
                {
                    DaneNowe.Add(new Dane(JSON.ID, JSON.Data, JSON.Opis));
                }
            }
          
        }
        private void CreateFile()
        {
            try
            {
                File.Create(PatchFolder + @"\"+NameFile);

            }catch(Exception a)
            {
                Validate validate = new Validate();
                validate.Exception(a);
            }
        }
    }
}
