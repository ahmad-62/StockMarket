using System.ComponentModel.DataAnnotations.Schema;

namespace StockMarket.Models
{
    public class Protfolio
    {
        public String ApplicationuserId {  get; set; }
        [ForeignKey(nameof(ApplicationuserId))]
        public ApplicationUser applicationUser { get; set; }
        public int StockId {  get; set; }
        [ForeignKey(nameof(StockId))]

        public Stock Stock {  get; set; }
    }
}
