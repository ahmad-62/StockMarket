using System.ComponentModel.DataAnnotations;

namespace StockMarket.DTOs
{
    public class StockDTO
    {
        [Required]
        [MaxLength(10,ErrorMessage ="Symbol cannot be over 10 characters")]
        public string Symbol { get; set; }
        [Required]
        [MaxLength(10, ErrorMessage = "CompanyName cannot be over 10 characters")]

        public string CompanyName { get; set; }
        [Required]
        [Range(1,10000000)]
        public decimal Purchase { get; set; }
        [Required]
        [Range(0.001,100)]
        public decimal LastDiv { get; set; }
        [Required]
        [MaxLength(10,ErrorMessage ="Idustry cannot be over 10 charachters")]
        public String Industry { get; set; } = string.Empty;
        [Range(1,5000000000)]
        public long marketcamp { get; set; }
    }
}
