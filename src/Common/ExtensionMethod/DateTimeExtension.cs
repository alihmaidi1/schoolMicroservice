namespace Common.ExtensionMethod;

public static class DateTimeExtension
{
    public static DateTime RandomDateTime()
    {

         Random gen = new Random();
        DateTime start = DateTime.Now;           
        return start.AddDays(gen.Next(1,1000));
    }
    
    
}