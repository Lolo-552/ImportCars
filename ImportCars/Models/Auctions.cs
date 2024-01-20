using System.ComponentModel;

namespace ImportCars.Models
{
    public class Auctions
    {
        public int Id { get; set; }
        [DisplayName("Nazwa")]
        public int Name { get; set; }
        [DisplayName("Data końcowa")]
        public DateTime EndDate { get; set; }
        public List<Images>? Images { get; set; }
    }
}
