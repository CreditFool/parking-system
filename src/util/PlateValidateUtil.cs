class PlateValidateUtil
{
    public static bool Validate(String plate)
    {
        String[] plateComponent = plate.Split("-");

        if (plateComponent.Length == 3)
        {
            try
            {
                Convert.ToInt32(plateComponent[1]);
            }
            catch (System.Exception)
            {
                return false;
            }

            return true;
        }
        return false;
    }
}