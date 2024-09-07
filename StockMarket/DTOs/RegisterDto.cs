using System.ComponentModel.DataAnnotations;

namespace StockMarket.DTOs
{
    public class RegisterDto
    {
        [Required]
        [MinLength(4,ErrorMessage ="FirstName must be 5 characters")]
        [MaxLength(15,ErrorMessage ="FirstName cannot be over 15 characters ")]
        public String FirstName {  get; set; }
        [Required]
        [MinLength(4, ErrorMessage = "LastName must be 5 characters")]
        [MaxLength(15, ErrorMessage = "LastName cannot be over 15 characters ")]
        public String LastName { get; set; }
        [Required]
        public string UserName {  get; set; }
        [Required]
        [EmailAddress]
        public string Email {  get; set; }
        [Required]

        public string Password { get; set; }


    }
}
