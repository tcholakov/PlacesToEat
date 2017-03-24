namespace PlacesToEat.Tools.Infrastructure
{
    using System;

    using Contracts;

    public class Utilities : IUtilities
    {
        public DateTime GetEndOfTheWeek(DateTime today)
        {
            DateTime baseDate = today.Date;
            DateTime thisWeekEnd = baseDate.AddDays(8 - (int)today.DayOfWeek).AddTicks(-1);

            return thisWeekEnd;
        }

        public DateTime GetStartOfTheWeek(DateTime today)
        {
            DateTime baseDate = today.Date;
            DateTime thisWeekStart = today.AddDays(-(int)today.DayOfWeek + 1);

            return thisWeekStart;
        }
    }
}
