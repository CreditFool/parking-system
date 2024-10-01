class CommandValidatorUtil
{
    private static readonly String[] availableCommands = [
        "create_parking_lot",
        "park",
        "leave",
        "status",
        "type_of_vehicles",
        "registration_numbers_for_vehicles_with_odd_plate",
        "registration_numbers_for_vehicles_with_even_plate",
        "registration_numbers_for_vehicles_with_colour",
        "slot_numbers_for_vehicles_with_colour",
        "slot_number_for_registration_number",
        "exit"
    ];

    public static bool Validate(String command)
    {
        String[] commandComponents = command.Split();
        if (commandComponents.Length < 1)
        {
            return false;
        }
        return availableCommands.Contains(commandComponents[0]);
    }
}