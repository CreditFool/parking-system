using ParkingSystem.Service;
using ParkingSystem.Entity;

namespace ParkingSystem.App
{
    class App
    {
        private readonly VehicleService service = new();

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

                case "leave":
                    Console.WriteLine(service.LeaveVehicle(commands));
                    break;

                case "type_of_vehicles":
                    Console.WriteLine(service.CountByType(commands));
                    break;

                case "registration_numbers_for_vehicles_with_odd_plate":
                    Console.WriteLine(service.PrintVehiclesWithOddPlate());
                    break;

                case "registration_numbers_for_vehicles_with_even_plate":
                    Console.WriteLine(service.PrintVehiclesWithEvenPlate());
                    break;

                case "registration_numbers_for_vehicles_with_colour":
                    Console.WriteLine(service.PrintVehiclesWithColor(commands));
                    break;

                case "slot_numbers_for_vehicles_with_colour":
                    Console.WriteLine(service.PrintVehiclesSlotWithColor(commands));
                    break;

                case "slot_number_for_registration_number":
                    Console.WriteLine(service.PrintVehiclesSlotWithPlate(commands));
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
            Console.WriteLine("Slot\t No.\t\t Type\t Registration No Colour");
            for (int i = 0; i < vehicles.Length; i++)
            {
                Vehicle? vehicle = vehicles[i];
                if (vehicle != null)
                {
                    Console.WriteLine((i + 1) + "\t " + vehicle.PlateNumber + "\t " + vehicle.VehicleType + "\t " + vehicle.Color);
                }
                else
                {
                    Console.WriteLine((i + 1));
                }
            }
        }
    }
};

