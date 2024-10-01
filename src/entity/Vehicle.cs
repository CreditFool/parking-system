class Vehicle(String vehicleType, String plateNumber, String color)
{
    private String vehicleType = vehicleType;
    private String plateNumber = plateNumber;
    private String color = color;

    public void SetVehicleType(String vehicleType)
    {
        this.vehicleType = ToCapital(vehicleType);
    }

    public void SetPlateNumber(String plateNumber)
    {
        this.plateNumber = plateNumber.ToUpper();
    }

    public void SetColor(String color)
    {
        this.color = ToCapital(color);
    }

    public String GetVehicleType()
    {
        return vehicleType;
    }

    public String GetPlateNumber()
    {
        return plateNumber;
    }

    public String GetColor()
    {
        return color;
    }

    private static string ToCapital(String word)
    {
        return char.ToUpper(word[0]) + word[1..];
    }
}