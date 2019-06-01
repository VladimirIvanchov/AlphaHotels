using System.Collections.Generic;

namespace AlphaHotel.Areas.Manager.Models
{
    public class StatusForLogViewModel
    {
        public ICollection<StatusViewModel> Statuses { get; set; }
        public int LogId { get; set; }
    }
}
