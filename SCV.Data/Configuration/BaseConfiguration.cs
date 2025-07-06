namespace SCV.Data.Configuration
{
    using Newtonsoft.Json;

    public abstract class BaseConfiguration
    {
        public T[] SeedFromJson<T>(string filePath)
        {
            if (!File.Exists(filePath))
            {
                throw new FileNotFoundException($"Seed data file not found: {filePath}");
            }

            string jsonFile = File
                                .ReadAllText(filePath);


            T[] genericListEntities = JsonConvert
                                             .DeserializeObject<T[]>(jsonFile)!;

            return genericListEntities;
        }
    }
}
