using System.Text.Json;

static class ShowAcces
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/Showss.json"));


    public static List<ShowModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<ShowModel>>(json);
    }


    public static void WriteAll(List<ShowModel> shows)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(shows, options);
        File.WriteAllText(path, json);
    }



}