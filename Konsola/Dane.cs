
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
        public override bool Equals(Object obj)
        {
            if (!(obj is Dane CheckOBJ))
                return false;
            else
                return obj.Equals(CheckOBJ.ID);
        }
    }
    
}
