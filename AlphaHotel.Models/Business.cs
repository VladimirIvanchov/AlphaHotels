using System.Collections.Generic;

namespace AlphaHotel.Models
{
    public class Business
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ICollection<LogBook> LogBooks { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
    }
}
