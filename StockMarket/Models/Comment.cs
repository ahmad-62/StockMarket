using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace StockMarket.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }=DateTime.Now;
        public int StockID {  get; set; }
        public Stock stock { get; set; }
        public string? ApplicationuserId {  get; set; }
        [ForeignKey(nameof(ApplicationuserId))]
        public ApplicationUser applicationuser { get; set; }
    }
}
