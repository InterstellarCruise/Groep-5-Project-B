using System.Text.Json.Serialization;
public class BarModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("date")]
    public string Date { get; set; }
    
    [JsonPropertyName("accountid")]
    public int Accountid { get; set; }

    [JsonPropertyName("reservationid")]
    public int Reservationid { get; set; }
    [JsonPropertyName("start_time")]
    public string Start_Time { get; set; }

    [JsonPropertyName("amount")]
    public Nullable<int> Amount { get; set; }

    public BarModel(int id, string date, int accountid,int reservationid, string start_time, int? amount)
    {
        Id = id;
        Date = date;
        Accountid = accountid;
        Reservationid = reservationid;
        Start_Time = start_time;
        Amount = amount;
    }
}