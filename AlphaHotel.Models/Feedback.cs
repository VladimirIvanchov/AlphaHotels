using AlphaHotel.Models.Contracts;
using System;

namespace AlphaHotel.Models
{
    public class Feedback : IAuditable, IDeletable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rate { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
