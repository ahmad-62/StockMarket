using StockMarket.Models;

namespace StockMarket.DTOs
{
    public class StockDtoDisplay
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Purchase { get; set; }
        public decimal LastDiv { get; set; }
        public String Industry { get; set; } = string.Empty;
        public long marketcamp { get; set; }
        public List<CommentDtoDisplay> comments { get; set; }
    }
}
