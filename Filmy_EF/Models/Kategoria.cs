namespace Filmy_EF.Models
{
    public class Kategoria
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Film> Filmy { get; set; }
    }
}
