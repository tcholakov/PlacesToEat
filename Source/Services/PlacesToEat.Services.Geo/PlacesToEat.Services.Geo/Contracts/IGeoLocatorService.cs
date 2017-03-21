namespace PlacesToEat.Services.Geo.Contracts
{
    public interface IGeoLocatorService
    {
        double DistanceTo(double startLatitude, double startLongitude, double endLatitude, double endLongitude, DistanceUnit unit = DistanceUnit.Kilometers);
    }
}
