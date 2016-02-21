namespace PlacesToEat.Web.Infrastructure.GeoLocation
{
    using System;

    public static class GeoLocator
    {
        public static double DistanceTo(double startLatitude, double startLongitude, double endLatitude, double endLongitude, char unit = 'K')
        {
            double rlat1 = Math.PI * startLatitude / 180;
            double rlat2 = Math.PI * endLatitude / 180;
            double theta = startLongitude - endLongitude;
            double rtheta = Math.PI * theta / 180;
            double dist =
                (Math.Sin(rlat1) * Math.Sin(rlat2)) + (Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta));
            dist = Math.Acos(dist);
            dist = dist * 180 / Math.PI;
            dist = dist * 60 * 1.1515;

            switch (unit)
            {
                case 'K': // Kilometers -> default
                    return dist * 1.609344;
                case 'N': // Nautical Miles
                    return dist * 0.8684;
                case 'M': // Miles
                    return dist;
            }

            return dist;
        }
    }
}
