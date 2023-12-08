using RestaurantApp.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.ViewModels
{
    public class JeloGetAllVM
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Decimal Cijena { get; set; }
        public int restoran_id { get; set; }

        public Restoran restoran { get; set; }

        public DateTime created_time { get; set; }

    }
}
