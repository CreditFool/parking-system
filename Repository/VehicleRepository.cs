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
    }
}