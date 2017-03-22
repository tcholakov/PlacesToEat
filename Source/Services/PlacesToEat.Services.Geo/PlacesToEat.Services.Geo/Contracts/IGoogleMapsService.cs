namespace PlacesToEat.Services.Geo.Contracts
{
    public interface IGoogleMapsService
    {
        int GetBestGoogleMapsZoom(double distance);
    }
}
