using System;

public static class DateTimeHelper
{
    public static DateTime ConvertToTimeZone(DateTime dateTime, string timeZoneId)
    {
        TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);

        return TimeZoneInfo.ConvertTimeFromUtc(dateTime.ToUniversalTime(), timeZone);
    }
}