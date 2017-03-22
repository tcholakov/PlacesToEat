namespace PlacesToEat.Services.Geo
{
    using PlacesToEat.Services.Geo.Contracts;

    public class GoogleMapsService : IGoogleMapsService
    {
        public int GetBestGoogleMapsZoom(double distance)
        {
            int zoom = 15;

            if (distance > 2 && distance <= 5)
            {
                zoom = 14;
            }
            else if (distance >= 5 && distance <= 8)
            {
                zoom = 13;
            }
            else if (distance >= 8)
            {
                zoom = 12;
            }

            return zoom;
        }
    }
}
