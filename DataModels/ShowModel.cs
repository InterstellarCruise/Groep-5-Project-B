using System.Text.Json.Serialization;


class ShowModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("filmId")]
    public int FilmId { get; set; }

    [JsonPropertyName("dateTime")]
    public string DateTime { get; set; }

    public ShowModel(int id, int filmId, string dateTime)
    {
        Id = id;
        FilmId = filmId;
        DateTime = dateTime;
    }

}




