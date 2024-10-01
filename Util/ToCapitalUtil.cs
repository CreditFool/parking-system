class ToCapitalUtil
{
    public static string ToCapital(string word)
    {
        return char.ToUpper(word[0]) + word[1..].ToLower();
    }
}