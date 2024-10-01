using ParkingSystem.Repository;
using ParkingSystem.Entity;

namespace ParkingSystem.Service
{
    class VehicleService
    {
        private readonly VehicleRepository repository = new();

        public string ParkVehicle(string request)
        {
            String[] command = request.Split();
            if (command.Length < 4)
            {
                return "bad command; need plate number, color, and vehicle type.";
            }

            if (!PlateValidateUtil.Validate(command[1]))
            {
                return "false vehicle plate number format; example format A-1234-B";
            }

            if (!command[3].Equals("mobil", StringComparison.CurrentCultureIgnoreCase) || !command[3].Equals("motor", StringComparison.CurrentCultureIgnoreCase))
            {
                return "only can park Mobil and Motor";
            }

            int slotUsed = repository.InsertVehicle(new Vehicle(command[3], command[1], command[2]));

            if (slotUsed < 0)
            {
                return "no available slot left";
            }

            return "Allocated slot number: " + slotUsed;
        }
    }
}