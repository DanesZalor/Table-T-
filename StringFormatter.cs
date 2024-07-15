public class ConsoleOutputFormat 
{
    public static string Plain      => Console.IsOutputRedirected ? "" : "\x1b[39m";
    public static string Red         => Console.IsOutputRedirected ? "" : "\x1b[91m";
    public static string Green       => Console.IsOutputRedirected ? "" : "\x1b[92m";
    public static string Yellow      => Console.IsOutputRedirected ? "" : "\x1b[93m";
    public static string Blue        => Console.IsOutputRedirected ? "" : "\x1b[94m";
    public static string Magenta     => Console.IsOutputRedirected ? "" : "\x1b[95m";
    public static string Cyan        => Console.IsOutputRedirected ? "" : "\x1b[96m";
    public static string Grey        => Console.IsOutputRedirected ? "" : "\x1b[97m";
    public static string Bold        => Console.IsOutputRedirected ? "" : "\x1b[1m";
    public static string NoBold      => Console.IsOutputRedirected ? "" : "\x1b[22m";
    public static string Underline   => Console.IsOutputRedirected ? "" : "\x1b[4m";
    public static string NoUnderline => Console.IsOutputRedirected ? "" : "\x1b[24m";
    public static string Reverse     => Console.IsOutputRedirected ? "" : "\x1b[7m";
    public static string NoReverse   => Console.IsOutputRedirected ? "" : "\x1b[27m";

    
}


public class StringFormatter
{
    public string Value {get; private set;}

    public StringFormatter(string value)
    {
        Value = value;
    }
    
    public StringFormatter InRed()
    {
        Value = $"{ConsoleOutputFormat.Red}{Value}";
        return this;
    }

    public StringFormatter InGreen()
    {
        Value = $"{ConsoleOutputFormat.Green}{Value}";
        return this;
    }

    public StringFormatter InBlue()
    {
        Value = $"{ConsoleOutputFormat.Blue}{Value}";
        return this;
    }

    public StringFormatter InYellow()
    {
        Value = $"{ConsoleOutputFormat.Yellow}{Value}";
        return this;
    }

    public StringFormatter InGrey()
    {
        Value = $"{ConsoleOutputFormat.Grey}{Value}";
        return this;
    }

    public StringFormatter InBold()
    {
        Value = $"{ConsoleOutputFormat.Bold}{Value}";
        return this;
    }

    public StringFormatter InUnderline()
    {
        Value = $"{ConsoleOutputFormat.Underline}{Value}";
        return this;
    }

    public string Build()
    {
        if (Value.Contains(ConsoleOutputFormat.Bold))
        {
            Value += ConsoleOutputFormat.NoBold;
        }

        if (Value.Contains(ConsoleOutputFormat.Underline))
        {
            Value += ConsoleOutputFormat.NoUnderline;
        }


        return $"{Value}{ConsoleOutputFormat.Plain}";
    }

    public override string ToString()
    {
        return Build();
    }
}

public static class StringFormatterExtensions
{
    public static StringFormatter Format(this string str)
        => new StringFormatter(str);
    

    public static StringFormatter InRed(this string str)
        => new StringFormatter(str).InRed();
    

    public static StringFormatter InBlue(this string str)
        => new StringFormatter(str).InBlue();
    

    public static StringFormatter InYellow(this string str)
        => new StringFormatter(str).InYellow();
    

    public static StringFormatter InGreen(this string str)
        => new StringFormatter(str).InGreen();
    
    public static StringFormatter InGrey(this string str)
        => new StringFormatter(str).InGrey();

    public static StringFormatter InBold(this string str)
        => new StringFormatter(str).InBold();
    
    public static StringFormatter InUnderline(this string str)
        => new StringFormatter(str).InUnderline();
}
