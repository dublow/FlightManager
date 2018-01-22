using System;

namespace Domain
{
    public class Aircraft
    {
        public string Model { get; }
        public double ConsumptionPerHour { get; }
        public double CruisingSpeed { get; }
        public double TakeOffEffort { get; }

        public Aircraft(string model, double consumptionPerHour, double cruisingSpeed, double takeOffEffort)
        {
            if (string.IsNullOrEmpty(model))
                throw new ArgumentNullException(nameof(model));

            if (consumptionPerHour <= 0)
                throw new ArgumentNullException(nameof(consumptionPerHour));

            if (cruisingSpeed <= 0)
                throw new ArgumentNullException(nameof(cruisingSpeed));

            if (takeOffEffort <= 0)
                throw new ArgumentNullException(nameof(takeOffEffort));


            Model = model;
            ConsumptionPerHour = consumptionPerHour;
            CruisingSpeed = cruisingSpeed;
            TakeOffEffort = takeOffEffort;
        }
    }
}
