using ParkingSystem.Repository;
using ParkingSystem.Entity;

namespace ParkingSystem.Service
{
    class VehicleService
    {
        private readonly VehicleRepository repository = new();

        public Vehicle?[] Status()
        {
            return repository.GetAllVehicles();
        }

        public string CreateSlot(string[] commands)
        {
            if (commands.Length < 2)
            {
                return "bad command; need number of slot";
            }

            int n = Convert.ToInt32(commands[1]);
            if (n < 0)
            {
                return "slot must be equal or greated than 0";
            }
            repository.Slot = n;
            return "Created a parking lot with " + n + " slots";
        }

        public string ParkVehicle(String[] commands)
        {
            if (commands.Length < 4)
            {
                return "bad command; need plate number, color, and vehicle type";
            }

            if (!PlateValidateUtil.Validate(commands[1]))
            {
                return "false vehicle plate number format; example format A-1234-B";
            }

            if (!commands[3].Equals("mobil", StringComparison.CurrentCultureIgnoreCase) && !commands[3].Equals("motor", StringComparison.CurrentCultureIgnoreCase))
            {
                return "only can park Mobil and Motor";
            }

            int slotUsed = repository.InsertVehicle(new Vehicle(commands[3], commands[1], commands[2]));

            if (slotUsed < 0)
            {
                return "no available slot left";
            }

            return "Allocated slot number: " + slotUsed;
        }
    }
}