using System;
using System.Collections.Generic;
using System.Text;

namespace AlphaHotel.Models
{
    public class UsersLogbooks
    {
        public string UserId { get; set; }
        public User User { get; set; }
        public int LogBookId { get; set; }
        public LogBook LogBook { get; set; }
    }
}
