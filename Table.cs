public class Table<T>
{
    public int Padding { get; set; }
    public char HeaderBorder { get; set; } = '-';
    public string[] Headers => _tableValues.First();
    public IEnumerable<string[]> Rows => _tableValues.Skip(1);
    private List<string[]> _tableValues;
    public Table()
    {
        var headers = typeof(T)
            .GetProperties()
            .Select(s => s.Name)
            .ToArray();

        _tableValues = [headers];
    }

    public void AddRow(T obj)
    {
        if(obj == null) 
            throw new ArgumentNullException("bruh");

        var properties = obj.GetType().GetProperties();
        var values = new List<string>();

        foreach(var property in properties)
        {
            values.Add(property.GetValue(obj)?.ToString() ?? "");
        }

        _tableValues.Add(values.ToArray());
    }

    public override string ToString()
    {
        // analyze column widths
        var widths = new int[_tableValues[0].Count()];

        foreach(var entry in _tableValues)
        {
            for(int i = 0; i<widths.Length; i++)
            {
                widths[i] = int.Max(widths[i], entry[i].Length);
            }
        }

        string padding = new string(' ', Padding);
        var tableStr = "";
        
        // print headers
        for(int i = 0; i<widths.Length; i++)
        {
            tableStr += padding + Headers[i].PadRight(widths[i]) + padding;
        }
        tableStr += "\n" + new string(HeaderBorder, widths.Sum() + Padding * widths.Length * 2) + "\n";

        // print entries
        foreach(var entry in Rows)
        {
            for(int i = 0; i<widths.Length; i++)
            {
                tableStr += padding + entry[i].PadRight(widths[i]) + padding;
            }
            tableStr += "\n";
        }

        return tableStr;
    }
}
