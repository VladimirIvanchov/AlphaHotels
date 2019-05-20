using System.ComponentModel.DataAnnotations;

namespace AlphaHotel.Areas.Identity.Models.AccountViewModels
{
    public class LoginViewModel
    {
        [Required]
        [MinLength(5)]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Remember me?")]
        public bool RememberMe { get; set; }
    }
}
