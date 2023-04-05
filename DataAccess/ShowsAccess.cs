using System.Text.Json;

public static class ShowsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/shows.json"));


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
    public static void Add(ShowModel show)
    {
        var shows = LoadAll();
        shows.Add(show);
        WriteAll(shows);
    }



}