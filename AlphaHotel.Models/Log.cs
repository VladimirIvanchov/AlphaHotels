using AlphaHotel.Models.Contracts;
using System;

namespace AlphaHotel.Models
{
    public class Log : IAuditable, IDeletable
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorId { get; set; }
        public User Author { get; set; }
        public int StatusId { get; set; }
        public Status Status { get; set; }
        public int LogBookId { get; set; }
        public LogBook LogBook { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public DateTime? DeletedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
