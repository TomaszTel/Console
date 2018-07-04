
using System;
using System.Linq;

namespace Konsola
{
     class Dane : MainMenus
    {
        public int ID { get; private set; }
        public DateTime Data { get; private set; }
        public string Opis { get; private set; }

        public string Display { get { return $"Telwak {Opis}" ; } }
        public Dane(int Id,DateTime data, string opis)
        {
            ID = Id;
            Data = data;
            Opis = opis;
        }
        public void SetOpis(string opis)
        {
            Opis = opis;
        }
    }

    
}
