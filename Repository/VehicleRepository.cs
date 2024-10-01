using ParkingSystem.Entity;

namespace ParkingSystem.Repository
{
    class VehicleRepository(int slot = 0)
    {
        private Vehicle?[] vehicles = new Vehicle[slot];
        private int _slot = slot;

        public int Slot
        {
            get => _slot;
            set
            {
                Vehicle?[] newVehicles = new Vehicle[value];

                int smallestLot = Slot < value ? Slot : value;
                for (int i = 0; i < smallestLot; i++)
                {
                    newVehicles[i] = this.vehicles[i];
                }

                _slot = value;
                vehicles = newVehicles;
            }
        }

        public int InsertVehicle(Vehicle vehicle)
        {
            for (int i = 0; i < this.Slot; i++)
            {
                if (vehicles[i] == null)
                {
                    vehicles[i] = vehicle;
                    return i;
                }
            }
            return -1;
        }

        public bool RemoveVehicle(int index)
        {
            if (this.vehicles[index] != null)
            {
                this.vehicles[index] = null;
                return true;
            }
            return false;
        }

        public Vehicle?[] GetAllVehicles()
        {
            return this.vehicles;
        }

        public int CountVehicleByType(String vehicleType)
        {
            vehicleType = ToCapitalUtil.ToCapital(vehicleType);
            int result = 0;
            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle != null && vehicle.VehicleType != null && vehicle.VehicleType.Equals(vehicleType))
                {
                    result += 1;
                }
            }
            return result;
        }

        public string[] VehicleWithOddPlate()
        {
            List<string> result = [];
            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle != null && vehicle.PlateNumber != null && (GetNumber(vehicle.PlateNumber) % 2 == 1))
                {
                    result.Add(vehicle.PlateNumber);
                }
            }
            return [.. result];
        }

        public string[] VehicleWithEvenPlate()
        {
            List<string> result = [];
            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle != null && vehicle.PlateNumber != null && (GetNumber(vehicle.PlateNumber) % 2 == 0))
                {
                    result.Add(vehicle.PlateNumber);
                }
            }
            return [.. result];
        }

        public string[] VehicleWithColor(string color)
        {
            color = ToCapitalUtil.ToCapital(color);
            List<string> result = [];
            foreach (Vehicle? vehicle in vehicles)
            {
                if (vehicle != null && vehicle.Color != null && vehicle.Color.Equals(color) && vehicle.PlateNumber != null)
                {
                    result.Add(vehicle.PlateNumber);
                }
            }
            return [.. result];
        }

        public string[] VehicleSlotWithColor(string color)
        {
            color = ToCapitalUtil.ToCapital(color);
            List<string> result = [];
            for (int i = 0; i < Slot; i++)
            {
                Vehicle? vehicle = vehicles[i];
                if (vehicle != null && vehicle.Color != null && vehicle.Color.Equals(color))
                {
                    result.Add(Convert.ToString(i + 1));
                }
            }
            return [.. result];
        }

        private static int GetNumber(string plate)
        {
            String[] plateComponent = plate.Split("-");
            return Convert.ToInt32(plateComponent[1]);
        }
    }
}