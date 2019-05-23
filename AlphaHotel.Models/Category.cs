using System.Collections.Generic;

namespace AlphaHotel.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
