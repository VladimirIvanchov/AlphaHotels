using AlphaHotel.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Models
{
    public class Feedback : IAuditable, IDeletable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
