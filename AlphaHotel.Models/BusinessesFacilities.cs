using AlphaHotel.Models.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Models
{
    public class BusinessesFacilities : IAuditable
    {
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public int FacilityId { get; set; }
        public Facility Facility { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
