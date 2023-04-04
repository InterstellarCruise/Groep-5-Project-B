using System.Text.Json.Serialization;


public class FilmModel
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("description")]
    public string Description { get; set; }

    [JsonPropertyName("ageLimit")]
    public int AgeLimit { get; set; }

    [JsonPropertyName("length")]
    public double Length { get; set; }
    [JsonPropertyName("genres")]
    public List<string> Genre { get; set; }

    public FilmModel(int id, string name, string description, int ageLimit, List<string> genre)
    {
        Id = id;
        Name = name;
        Description = description;
        AgeLimit = ageLimit;
        Genre = genre;
    }

}
