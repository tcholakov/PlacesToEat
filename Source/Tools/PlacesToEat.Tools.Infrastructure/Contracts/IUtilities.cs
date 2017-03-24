namespace PlacesToEat.Tools.Infrastructure.Contracts
{
    using System;

    public interface IUtilities
    {
        DateTime GetEndOfTheWeek(DateTime today);

        DateTime GetStartOfTheWeek(DateTime today);
    }
}
