namespace WebApplication1.Models;

public class Animal
{
    public static int id = 0;
    public int IdAnimal { get; private set; }
    public string Name { get; set; }
    public string Category { get; set; }
    public string ColorCoat { get; set; }
    public double Weight { get; set; }

    public Animal(string name, string category, string colorCoat, double weight)
    {
        id++;
        this.IdAnimal = id;
        this.Name = name;
        this.Category = category;
        this.ColorCoat = colorCoat;
        this.Weight = weight;
    }

    public void SetIdAnimal(int id)
    {
        this.IdAnimal = id;
    }

}