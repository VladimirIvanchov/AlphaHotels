using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.DTOs
{
    public class CategoryDTO
    {
        [Required]
        [MaxLength(15)]
        public string Name { get; set; }
    }
}
