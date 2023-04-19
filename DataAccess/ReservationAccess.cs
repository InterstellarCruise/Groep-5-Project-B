using System.Text.Json;

public static class ReservationsAccess
{
    static string path = System.IO.Path.GetFullPath(System.IO.Path.Combine(Environment.CurrentDirectory, @"DataSources/reservations.json"));


    public static List<TheReservationModel> LoadAll()
    {
        string json = File.ReadAllText(path);
        return JsonSerializer.Deserialize<List<TheReservationModel>>(json);
    }


    public static void WriteAll(List<TheReservationModel> reservations)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string json = JsonSerializer.Serialize(reservations, options);
        File.WriteAllText(path, json);
    }



}
