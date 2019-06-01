using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlphaHotel.DTOs
{
    public class StatusDTO
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Type { get; set; }
    }
}
