using System.Text.Json.Serialization;

namespace DisparadorEmail;

public class Email
{
    [JsonPropertyName("email")]
    public string Valor { get; set; }
}
