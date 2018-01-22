using System;

namespace Domain
{
    public class Aircraft
    {
        public string Model { get; }
        public double ConsumptionPerHour { get; }
        public double CruisingSpeed { get; }

        public Aircraft(string model, double consumptionPerHour, double cruisingSpeed)
        {
            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException(nameof(model));

            if (consumptionPerHour <= 0)
                throw new ArgumentNullException(nameof(consumptionPerHour));

            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException(nameof(cruisingSpeed));


            Model = model;
            ConsumptionPerHour = consumptionPerHour;
            CruisingSpeed = cruisingSpeed;
        }
    }
}
