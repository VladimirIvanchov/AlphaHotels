using AlphaHotel.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.Areas.Admin.Models
{
    public class CreateLogBookViewModel
    {
        public ICollection<BusinessDTO> Businesses { get; set; }

        [Required(ErrorMessage = "Location is required!")]
        public int BusinessId { get; set; }

        [Required(ErrorMessage = "LogBook name is required!")]
        [MaxLength(15)]
        public string LogBookName { get; set; }
    }
}
