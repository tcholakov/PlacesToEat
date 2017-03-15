namespace PlacesToEat.Services.Geo
{
    public interface IGeoLocatorService
    {
        double DistanceTo(double startLatitude, double startLongitude, double endLatitude, double endLongitude, char unit = 'K');
    }
}
