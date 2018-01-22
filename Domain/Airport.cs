namespace Domain
{
    public class Airport
    {
        public string AitaCode { get; }
        public double Latitude { get; }
        public double Longitude { get; }

        public Airport(string aitaCode, double latitude, double longitude)
        {
            AitaCode = aitaCode;
            Latitude = latitude;
            Longitude = longitude;
        }
    }
}
