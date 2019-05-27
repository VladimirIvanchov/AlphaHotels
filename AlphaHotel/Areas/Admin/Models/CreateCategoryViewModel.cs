using AlphaHotel.DTOs;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.Areas.Admin.Models
{
    public class CreateCategoryViewModel
    {
        public ICollection<CategoryDTO> Categories { get; set; }

        [Required(ErrorMessage = "LogBook name is required!")]
        [MaxLength(15)]
        public string CategoryName { get; set; }
    }
}
