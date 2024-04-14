namespace WebApplication1.Models;

public class Animal
{
    public int IdAnimal { get; set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string ColorCoat { get; set; }
    public double Weight { get; set; }

    public Animal(int idAnimal, string name, string category, string colorCoat, double weight)
    {
        this.IdAnimal = idAnimal;
        this.Name = name;
        this.Category = category;
        this.ColorCoat = colorCoat;
        this.Weight = weight;
    }
}