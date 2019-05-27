using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.DTOs
{
    public class BusinessDTO
    {
        public int BusinessId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
