using AlphaHotel.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.DTOs
{
    public class LogBooksCategoriesDTO
    {
        public ICollection<LogBookDTO> LogBooks { get; set; }

        public ICollection<CategoryNameIdDTO> Categories { get; set; }
    }
}
