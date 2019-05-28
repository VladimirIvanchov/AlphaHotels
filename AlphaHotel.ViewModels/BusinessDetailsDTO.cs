using System.Collections.Generic;

namespace AlphaHotel.DTOs
{
    public class BusinessDetailsDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public string CoverPicture { get; set; }
        public ICollection<string> Pictures { get; set; }
        public ICollection<FeedbackForBusinessDTO> Feedbacks { get; set; }
    }
}
