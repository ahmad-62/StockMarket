namespace StockMarket.Models
{
    public class Stock
    {
        public int Id { get; set; }

        public string Symbol {  get; set; }
        public string CompanyName { get; set; }
        public decimal Purchase {  get; set; }
        public decimal LastDiv {  get; set; }
        public String Industry {  get; set; }=string.Empty;
        public long marketcamp {  get; set; }
        public List<Comment> comments { get; set; }
        public List<Protfolio> protfolios { get; set; } = new List<Protfolio>();

    }
}
