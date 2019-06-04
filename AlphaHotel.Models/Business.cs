using AlphaHotel.Models.Contracts;
using System;
using System.Collections.Generic;

namespace AlphaHotel.Models
{   
    public class Business : IAuditable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string About { get; set; }
        public string ShortDescription { get; set; }
        public string CoverPicture { get; set; }
        public ICollection<Picture> Pictures { get; set; }
        public ICollection<LogBook> LogBooks { get; set; }
        public ICollection<Feedback> Feedbacks { get; set; }
        public ICollection<User> Accounts { get; set; }
        public ICollection<BusinessesFacilities> BusinessesFacilities { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
    }
}
