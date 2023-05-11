using System.Text.Json.Serialization;
public class ReservationModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("showid")]
    public int Showid { get; set; }

    [JsonPropertyName("accountid")]
    public int Accountid { get; set; }

    [JsonPropertyName("ressedchairs")]
    public List<int> Ressedchairs { get; set; }
    [JsonPropertyName("amount")]
    public double Amount { get; set; }

    public ReservationModel(int id, int showid, int accountid, List<int> ressedchairs, double amount)
    {
        Id = id;
        Showid = showid;
        Accountid = accountid;
        Ressedchairs = ressedchairs;
        Amount = amount;
    }
}