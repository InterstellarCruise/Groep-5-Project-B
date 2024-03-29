using System.Text.Json;

public static class BarAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/bar.json"));


    public static List<BarModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<BarModel>>(json);
    }


    public static void WriteAll(List<BarModel> bars)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(bars, options);
        File.WriteAllText(path, json);
    }



}