using System;
using System.Collections.Generic;
using AlphaHotel.Models.Contracts;
using Microsoft.AspNetCore.Identity;

namespace AlphaHotel.Models
{
    public class User : IdentityUser, IAuditable, IDeletable
    {
        public int? BusinessId { get; set; }
        public Business Business { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
        public ICollection<UsersLogbooks> UsersLogbooks { get; set; }
    }
}
