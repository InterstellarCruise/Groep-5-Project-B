using System.Text.Json.Serialization;
public class TheReservationModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("showid")]
    public int Showid { get; set; }
    
    [JsonPropertyName("accountid")]
    public int Accountid { get; set; }

    [JsonPropertyName("ressedchair")]
    public List<int> Ressedchair { get; set; }

    public TheReservationModel(int id, int showid, int accountid, List<int> ressedchairs)
    {
        Id = id;
        Showid = showid;
        Accountid = accountid;
        Ressedchair = ressedchairs;
    }
}