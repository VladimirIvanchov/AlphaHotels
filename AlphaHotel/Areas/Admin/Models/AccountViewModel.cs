using AlphaHotel.DTOs;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace AlphaHotel.Areas.Admin.Models
{
    public class AccountViewModel
    {
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

        public ICollection<LogBookDTO> LogBooks { get; set; }
    }
}
