using System;

namespace AlphaHotel.Services.Utilities
{
    public class DateTimeWrapper : IDateTimeWrapper
    {
        public DateTime Now()
        {
            return DateTime.Now;
        }
    }
}
