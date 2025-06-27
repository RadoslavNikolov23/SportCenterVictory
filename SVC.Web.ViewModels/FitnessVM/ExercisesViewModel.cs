namespace SVC.Web.ViewModels.FitnessVM
{
    using System.Text.Json.Serialization;

    public class ExercisesViewModel
    {
        [JsonPropertyName("id")]
        public string Id { get; set; } = null!;

        [JsonPropertyName("name")]
        public string Name { get; set; } = null!;

        [JsonPropertyName("force")]
        public string? Force { get; set; }

        [JsonPropertyName("level")]
        public string? Level { get; set; }

        [JsonPropertyName("mechanic")]
        public string? Mechanic { get; set; }

        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }


        [JsonPropertyName("primaryMuscles")]
        public List<string> PrimaryMuscles { get; set; } = new List<string>();

        [JsonPropertyName("secondaryMuscles")]
        public List<string>? SecondaryMuscles { get; set; }

        [JsonPropertyName("instructions")]
        public List<string> Instructions { get; set; } = new List<string>();

        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [JsonPropertyName("images")]
        public List<string>? Images { get; set; }
    }

}
