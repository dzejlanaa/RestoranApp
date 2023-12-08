using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RestaurantApp.Models
{
    public class Jelo
    {
        [Key]
        public int Id { get; set; }
        public string Naziv { get; set; }
        public Decimal Cijena { get; set; }

        [ForeignKey(nameof(restoran))]
        public int restoran_id { get; set; }
        public Restoran restoran { get; set; }

        public DateTime created_time { get; set; }

    }
}
