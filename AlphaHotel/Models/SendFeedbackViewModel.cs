using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Models
{
    public class SendFeedbackViewModel
    {
        public int BusinessId { get; set; }

        [Required]
        [Range(1, 5)]
        public int Rating { get; set; }

        [MaxLength(20)]
        public string Author { get; set; }

        [Required]
        [MaxLength(150)]
        public string FeedbackText { get; set; }
    }
}
