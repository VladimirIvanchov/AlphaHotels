using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlphaHotel.ViewModels
{
    public class AccountViewModel
    {
        [Required]
        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        public int? BusinessId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<int> LogBookId { get; set; }

        [Required]
        [MaxLength(15)]
        public ICollection<string> LogBookName { get; set; }

        [Required]
        [MaxLength(25)]
        public string BusinessName { get; set; }

        public bool IsDeleted { get; set; }
    }
}
