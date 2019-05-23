using System.Collections.Generic;

namespace AlphaHotel.Models
{
    public class LogBook
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BusinessId { get; set; }
        public Business Business { get; set; }
        public ICollection<UsersLogbooks> ManagersLogbooks { get; set; }
        public ICollection<Log> Logs { get; set; }
    }
}
