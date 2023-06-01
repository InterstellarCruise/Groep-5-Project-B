using System.Text.Json.Serialization;
public class BarModel : IModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }
    
    [JsonPropertyName("accountid")]
    public int Accountid { get; set; }

    [JsonPropertyName("start_time")]
    public string Start_Time { get; set; }

    [JsonPropertyName("amount")]
    public int Amount { get; set; }

    public BarModel(int id, string date, int accountid, string start_time, int amount)
    {
        Id = id;
        Date = date;
        Accountid = accountid;
        Start_Time = start_time;
        Amount = amount;
    }
}