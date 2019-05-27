using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AlphaHotel.DTOs
{
    public class AccountDetailsDTO
    {
        [Required]
        public string Id { get; set; }

        [Required]
        [MinLength(5)]
        public string UserName { get; set; }

        public int? BusinessId { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        public ICollection<int> LogBookId { get; set; }

        public string BusinessName { get; set; }

        [Required]
        public bool IsDeleted { get; set; }

        [Required]
        public string Role { get; set; }

        public DateTime ModifiedOn { get; set; }
    }
}
