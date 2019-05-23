using AlphaHotel.Models.Contracts;
using System;

namespace AlphaHotel.Models
{
    public class UsersLogbooks : IAuditable, IDeletable
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int LogBookId { get; set; }
        public LogBook LogBook { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
