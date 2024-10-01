using ParkingSystem.Entity;

namespace ParkingSystem.Repository
{
    class VehicleRepository(int slot = 0)
    {
        private Vehicle?[] vehicles = new Vehicle[slot];
        private int _slot;

        public int Slot
        {
            get => _slot;
            set
            {
                _slot = value;
                Vehicle?[] newVehicles = new Vehicle[value];

                for (int i = 0; i < value; i++)
                {
                    newVehicles[i] = this.vehicles[i];
                }
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