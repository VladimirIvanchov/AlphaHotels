using System;
using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.DTOs
{
    public class FeedbackDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(150)]
        public string Text { get; set; }
        public int Rate { get; set; }
        public int BusinessId { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
