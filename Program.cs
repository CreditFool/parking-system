// See https://aka.ms/new-console-template for more information
Vehicle vehicle;

String command;

do
{
    Console.Write("$ ");
    command = Console.ReadLine();
    Console.WriteLine(CommandValidatorUtil.Validate(command));
} while (command != "exit");