using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlphaHotel.ViewModels
{
    public class LogBookViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
