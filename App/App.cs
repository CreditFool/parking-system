using ParkingSystem.Service;
using ParkingSystem.Entity;

namespace ParkingSystem.App
{
    class App
    {
        private VehicleService service = new();

        public void Start()
        {
            string? command;
            do
            {
                Console.Write("$ ");
                command = Console.ReadLine();
                command ??= "";
                ExecuteCommand(command);
                Console.WriteLine();
            } while (command != "exit");
        }

        private void ExecuteCommand(string command)
        {
            string[] commands = command.Split();

            switch (commands[0])
            {
                case "create_parking_lot":
                    Console.WriteLine(service.CreateSlot(commands));
                    break;

                case "park":
                    Console.WriteLine(service.ParkVehicle(commands));
                    break;

                case "status":
                    PrintVehicles(service.Status());
                    break;

                case "exit":
                    Console.WriteLine("ok, good bye!");
                    break;

                default:
                    Console.WriteLine("command not available");
                    break;
            }
        }

        private static void PrintVehicles(Vehicle?[] vehicles)
        {
            for (int i = 0; i < vehicles.Length; i++)
            {
                Vehicle? vehicle = vehicles[i];
                if (vehicle != null)
                {
                    Console.WriteLine(i + " " + vehicle.PlateNumber + " " + vehicle.VehicleType + " " + vehicle.Color);
                }
                else
                {
                    Console.WriteLine(i);
                }
            }
        }
    }
};

