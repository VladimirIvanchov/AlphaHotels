using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Models
{
    public class Facility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public ICollection<BusinessesFacilities> BusinessesFacilities { get; set; }
    }
}
