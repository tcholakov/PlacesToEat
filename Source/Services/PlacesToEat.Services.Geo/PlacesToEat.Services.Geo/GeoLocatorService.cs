namespace PlacesToEat.Services.Geo
{
    using System;

    using Contracts;

    public class GeoLocatorService : IGeoLocatorService
    {
        public double DistanceTo(double startLatitude, double startLongitude, double endLatitude, double endLongitude, DistanceUnit unit = DistanceUnit.Kilometers)
        {
            double rlat1 = Math.PI * startLatitude / 180;
            double rlat2 = Math.PI * endLatitude / 180;
            double theta = startLongitude - endLongitude;
            double rtheta = Math.PI * theta / 180;

            double distance =
                (Math.Sin(rlat1) * Math.Sin(rlat2)) + (Math.Cos(rlat1) *
                Math.Cos(rlat2) * Math.Cos(rtheta));

            distance = Math.Acos(distance);
            distance = distance * 180 / Math.PI;
            double distanceInMiles = distance * 60 * 1.1515;
            
            switch (unit)
            {
                case DistanceUnit.Kilometers:
                    return distanceInMiles * 1.609344;
                case DistanceUnit.NauticalMiles:
                    return distanceInMiles * 0.8684;
                case DistanceUnit.Miles:
                    return distanceInMiles;
            }

            return distanceInMiles;
        }
    }
}
