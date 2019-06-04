using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.Areas.Admin.Models
{
    public class CreateBusinessViewModel
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(25)]
        public string Name { get; set; }

        [Required]
        [MaxLength(60)]
        public string Location { get; set; }

        [Required]
        [MaxLength(450)]
        public string About { get; set; }

        [Required]
        [MaxLength(130)]
        public string ShortDescription { get; set; }

        [Required]
        public IFormFile CoverPicture { get; set; }
        public ICollection<IFormFile> Pictures { get; set; }
        public ICollection<FacilityViewModel> AllFacilities { get; set; }

        [Required]
        public ICollection<int> FacilitiesForTheBusiness { get; set; }
    }
}
