using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Areas.Manager.Models
{
    public class AddLogViewModel
    {
        public string UserId { get; set; }

        public int LogBookId { get; set; }

        public int CategoryId { get; set; }

        [Required]
        [MaxLength(250)]
        public string Description { get; set; }
    }
}
