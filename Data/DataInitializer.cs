using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

public class DataInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DataInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        string currentDirectory = Directory.GetCurrentDirectory();
        string path = "Data/";
        string fullPath = Path.Combine(currentDirectory, path, "milkProducts.json");
        var data = new List<Milk>();
        using (StreamReader reader = new StreamReader(fullPath))
        {
            string json = reader.ReadToEnd();
            data = JsonConvert.DeserializeObject<List<Milk>>(json);
        }
        
        modelBuilder.Entity<Milk>()
        .HasData(data!);
    }
}