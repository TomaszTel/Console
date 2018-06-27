
using System;

namespace Konsola
{
    public class Dane
    {
        public int ID { get; set; }
        public string Data { get; set; }
        public string Opis { get; set; }


        public Dane(int Id,string data, string opis)
        {
            ID = Id;
            Data = data;
            Opis = opis;
        }
    }


    class CheckOBJ 
    {
        public override bool Equals(Object obj)
        {
            Dane CheckOBJ = obj as Dane;
            if (CheckOBJ == null)
                return false;
            else
                return obj.Equals(CheckOBJ.ID);
        }

    }
}
