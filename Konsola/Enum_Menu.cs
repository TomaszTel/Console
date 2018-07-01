
namespace Konsola
{
    class Enum_Menu
    {
        public Menu PropertyEnum { get; set; }

        public enum Menu
        {
            Lista = 1,
            Dodawanie,
            Edycja,
            Usuwanie,
            Podgląd,
            Zakoncz,
           
        }
    }
}
