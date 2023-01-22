using System;
using System.ComponentModel;
using System.Globalization;


public enum Location {
    NewYork,
    London,
    Paris
}

public enum AlertLevel {
    Early,
    Standard,
    Late
}

public static class Appointment {

    private readonly static bool IsWindows = OperatingSystem.IsWindows();
    
    public static DateTime ShowLocalTime(DateTime dateTimeUtc) => dateTimeUtc.ToLocalTime();

    public static DateTime Schedule(string appointmentDateDescription, Location location) {
        var dateTime = DateTime.Parse(appointmentDateDescription);
        var timeZoneInfo = GetTimeZoneInfo(location);

        return TimeZoneInfo.ConvertTimeToUtc(dateTime, timeZoneInfo);
    }

    public static DateTime GetAlertTime(DateTime appointment, AlertLevel alertLevel) => alertLevel switch {
        AlertLevel.Early => appointment.AddDays(-1),
        AlertLevel.Standard => appointment.AddHours(-1).AddMinutes(-45),
        AlertLevel.Late => appointment.AddMinutes(-30),
        _ => throw new InvalidEnumArgumentException("The alert level provided is not supported.")
    };

    public static bool HasDaylightSavingChanged(DateTime dateTime, Location location) {
        var timeZoneInfo = GetTimeZoneInfo(location);
        var weekEarlier = dateTime.AddDays(-7);

        return timeZoneInfo.IsDaylightSavingTime(dateTime) != timeZoneInfo.IsDaylightSavingTime(weekEarlier);
    }

    public static DateTime NormalizeDateTime(string dateTimeString, Location location) {
        var cultureInfo = GetLocationCultureInfo(location);
        var successfulParse = DateTime.TryParse(dateTimeString, cultureInfo, DateTimeStyles.None, out var dateTime);

        return successfulParse ? dateTime : new DateTime(1, 1, 1);
    }

    private static TimeZoneInfo GetTimeZoneInfo(Location location) {
        var timeZoneId = GetTimeZoneId(location);
        return TimeZoneInfo.FindSystemTimeZoneById(timeZoneId);
    }

    private static string GetTimeZoneId(Location location) => location switch {
        Location.NewYork => IsWindows ? "Eastern Standard Time" : "America/New_York",
        Location.London => IsWindows ? "GMT Standard Time" : "Europe/London",
        Location.Paris => IsWindows ? "W. Europe Standard Time" : "Europe/Paris",
        _ => throw new InvalidEnumArgumentException("The location provided is not supported.")
    };

    private static CultureInfo GetLocationCultureInfo(Location location) {
        var culture = location switch {
            Location.NewYork => new CultureInfo("en-US"),
            Location.London => new CultureInfo("en-GB"),
            Location.Paris => new CultureInfo("fr-FR"),
            _ => throw new InvalidEnumArgumentException("The location provided is not supported.")
        };

        return CultureInfo.GetCultureInfo(culture.Name);
    }
}
