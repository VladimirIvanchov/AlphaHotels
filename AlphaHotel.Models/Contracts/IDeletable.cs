using System;

namespace AlphaHotel.Models.Contracts
{
    public interface IDeletable
    {
        DateTime? DeletedOn { get; set; }

        bool IsDeleted { get; set; }
    }
}
