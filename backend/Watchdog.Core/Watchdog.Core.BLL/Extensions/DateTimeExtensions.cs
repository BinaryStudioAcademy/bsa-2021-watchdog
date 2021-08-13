using System;
using Watchdog.Core.DAL.Entities.AlertSettings;

namespace Watchdog.Core.BLL.Extensions
{
    public static class DateTimeExtensions
    {
        public static AlertTimeInterval ToAlertTimeInterval(this TimeSpan time)
        {
            if (time < new TimeSpan(0, 0, 1, 0))
            {
                return AlertTimeInterval.OneMinute;
            }
            if (time < new TimeSpan(0, 0, 5, 0))
            {
                return AlertTimeInterval.FiveMinutes;
            }
            if (time < new TimeSpan(0, 0, 15, 0))
            {
                return AlertTimeInterval.FifteenMinutes;
            }
            if (time < new TimeSpan(0, 1, 0, 0))
            {
                return AlertTimeInterval.OneHour;
            }
            if (time < new TimeSpan(1, 0, 0, 0))
            {
                return AlertTimeInterval.OneDay;
            }
            if (time < new TimeSpan(7, 0, 0, 0))
            {
                return AlertTimeInterval.OneWeek;
            }
            if (time < new TimeSpan(30, 0, 0, 0))
            {
                return AlertTimeInterval.ThirtyDays;
            }
            return AlertTimeInterval.ThirtyDays;
        }

        public static AlertTimeInterval ToAlertTimeIntervalTimeAdo(DateTime dateTime)
        {
            return ToAlertTimeInterval(DateTime.Now - dateTime);
        }
    }
}
