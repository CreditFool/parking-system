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

            return "Allocated slot number: " + (slotUsed + 1);
        }

        public string LeaveVehicle(String[] commands)
        {
            if (commands.Length < 2)
            {
                return "bad command; need number of slot";
            }

            int n = Convert.ToInt32(commands[1]);
            if (n - 1 < 0)
            {
                return "selected lot must greater than 0";
            }

            if (n - 1 >= repository.Slot)
            {
                return "selected lot greater than available slot";
            }

            bool isFree = repository.RemoveVehicle(n - 1);
            if (isFree)
            {
                return "Slot number " + n + " is free";
            }
            return "Slot " + n + " didn't have vehicle";
        }
    }
}