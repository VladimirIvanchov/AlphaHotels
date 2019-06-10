﻿using System;

namespace AlphaHotel.Areas.Manager.Models
{
    public class LogViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string AuthorUsername { get; set; }
        public int StatusId { get; set; }
        public string Status { get; set; }
        public int LogBookId { get; set; }
        public string Category { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool IsDeleted { get; set; }
    }
}
