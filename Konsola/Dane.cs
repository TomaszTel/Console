
using System;

namespace Konsola
{
    public class Dane
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
