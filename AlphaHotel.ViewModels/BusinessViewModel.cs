using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.ViewModels
{
    public class BusinessViewModel
    {
        public int BusinessId { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }
    }
}
