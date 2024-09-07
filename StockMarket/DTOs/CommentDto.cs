using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace StockMarket.DTOs
{
    public class CommentDto
    {
        [Required]
        [MinLength(5,ErrorMessage ="Title must be 5 characters")]
        [MaxLength(280,ErrorMessage ="Title cannot be over 280 characters")]
        public string Title { get; set; }
        [Required]
        [MinLength(5, ErrorMessage = "Content must be 5 characters")]
        [MaxLength(280, ErrorMessage = "Content cannot be over 280 characters")]
         public string Content { get; set; }

        public int StockID { get; set; }

    }
}
