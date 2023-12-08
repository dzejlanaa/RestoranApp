using System.ComponentModel.DataAnnotations;

namespace RestaurantApp.Models
{
    public class Restoran
    {

        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public string Adresa { get; set; }
        public string Telefon { get; set; }
        public string Tip { get; set; }
    }
}
