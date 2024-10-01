namespace ParkingSystem.Entity
{
    class Vehicle
    {
        private string? _vehicleType;
        private string? _plateNumber;
        private string? _color;

        public string? VehicleType
        {
            get => _vehicleType;
            set => _vehicleType = value != null ? ToCapital(value) : null;
        }

        public string? PlateNumber
        {
            get => _plateNumber;
            set => _plateNumber = value?.ToUpper();
        }

        public string? Color
        {
            get => _color;
            set => _color = value != null ? ToCapital(value) : null;
        }

        public Vehicle(string VehicleType, string PlateNumber, string Color)
        {
            this.VehicleType = VehicleType;
            this.PlateNumber = PlateNumber;
            this.Color = Color;
        }

        private static string ToCapital(string word)
        {
            return char.ToUpper(word[0]) + word[1..].ToLower();
        }
    }
}