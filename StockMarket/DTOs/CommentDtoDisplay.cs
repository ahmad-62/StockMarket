namespace StockMarket.DTOs
{
    public class CommentDtoDisplay
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedDate { get; set; }

        public int StockID { get; set; }
        public string createdBy {  get; set; }=String.Empty;

    }
}
