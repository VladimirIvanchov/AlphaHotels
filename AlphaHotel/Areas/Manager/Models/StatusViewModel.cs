using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Areas.Manager.Models
{
    public class StatusViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Type { get; set; }
    }
}
