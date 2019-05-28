using AlphaHotel.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Models
{
    public class Picture : IDeletable
    {
        public int Id { get; set; }
        public string Location { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
