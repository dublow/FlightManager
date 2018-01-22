namespace Domain
{
    public class Flight
    {
        public string AitaCodeDeparture { get; }
        public string AitaCodeDestination { get; }
        public string AircraftModel { get; }
        public double Distance { get; }
        public double FuelNeeded { get; }

        public Flight(
            string aitaCodeDeparture, string aitaCodeDestination, 
            string aircraftModel, double distance, double fuelNeeded)
        {
            AitaCodeDeparture = aitaCodeDeparture;
            AitaCodeDestination = aitaCodeDestination;
            AircraftModel = aircraftModel;
            Distance = distance;
            FuelNeeded = fuelNeeded;
        }
    }
}
