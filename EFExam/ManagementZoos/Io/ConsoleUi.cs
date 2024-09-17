using residential_complex.Io.Interfaces;

namespace residential_complex.Io;
using static System.Console;

public class ConsoleUi:IUi
{
    public void ShowMessage(string message)
    {
        WriteLine(message);
    }
    
    public int GetIntegerFromUser(string msg)
    {
        var canParseNumber = false;
        var number = 0;
        while (!canParseNumber)
        {
            WriteLine($"Enter your {msg} :");
            canParseNumber = int.TryParse(ReadLine(), out number);
        }

        return number;
    }

    public string GetStringFromUser(string msg)
    {
        Write($"Enter {msg} :");
        var input = ReadLine();

        if (input != null) return input;
        WriteLine($"{msg} is invalid !! . try again !");
        return GetStringFromUser(msg);
    }

    public DateTime GetDateTimeFromUser(string message)
    {
        var canParseDate = false;
        DateTime time = default;
        while (!canParseDate)
        {
            WriteLine(" Enter Time for this Order :");
            canParseDate = DateTime.TryParse(ReadLine(), out time);
        }

        return time;
    }

    public double GetDoubleFromUser(string message)
    {
        var canParseNumber = false;
        var number = 0.0;
        while (!canParseNumber)
        {
            WriteLine($"Enter your {message} :");
            canParseNumber = Double.TryParse(ReadLine(), out number);
        }

        return number;
    }

    public decimal GetDecimalFromUser(string msg)
    {
        var canParseNumber = false;
        decimal number = 0;
        while (!canParseNumber)
        {
            WriteLine($"Enter your {msg} :");
            canParseNumber = decimal.TryParse(ReadLine(), out number);
        }

        return number;
    }
   
    
}