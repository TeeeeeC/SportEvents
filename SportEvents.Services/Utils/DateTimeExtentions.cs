using System;

namespace SportEvents.Services.Utils
{
    public static class DateTimeExtentions
    {
        public static DateTime EndOfDateTime(this DateTime dt)
        {
            return new DateTime(DateTime.UtcNow.Year, DateTime.UtcNow.Month, DateTime.UtcNow.Day, 23, 59, 0, 0);
        }
    }
}
