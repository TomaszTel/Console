
using System;
using System.Linq;

namespace Konsola
{
     class Dane : MainMenus
    {
        public int ID { get; set; }
        public DateTime Data { get; set; }
        public string Opis { get; set; }


        public Dane(int Id,DateTime data, string opis)
        {
            ID = Id;
            Data = data;
            Opis = opis;
        }


        
    }

    
}
