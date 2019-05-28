namespace AlphaHotel.DTOs
{
    public class FeedbackForBusinessDTO
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public bool IsDeleted { get; set; }
        public string Author { get; set; }
    }
}
