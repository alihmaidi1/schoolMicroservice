namespace Common.ExtensionMethod;

public static class StringExtension
{
    
    public static string GenerateCode(this string str)
    {

        Random random = new Random();   
        return random.Next(0,1000000).ToString("D6");

    }

    
}