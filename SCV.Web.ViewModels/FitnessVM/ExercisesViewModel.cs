namespace SCV.Web.ViewModels.FitnessVM
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

        [JsonPropertyName("mechanic")]
        public string? Mechanic { get; set; }

        [JsonPropertyName("equipment")]
        public string? Equipment { get; set; }

        [JsonPropertyName("primaryMuscles")]
        public string PrimaryMuscles { get; set; } = null!;

        [JsonPropertyName("secondaryMuscles")]
        public string? SecondaryMuscles { get; set; }

        [JsonPropertyName("instructions")]
        public string? Instructions { get; set; }

        [JsonPropertyName("category")]
        public string Category { get; set; } = null!;

        [JsonPropertyName("imageUrlOne")]
        public string? ImageUrlOne { get; set; }

        [JsonPropertyName("imageUrlTwo")]
        public string? ImageUrlTwo { get; set; }

    }

}
