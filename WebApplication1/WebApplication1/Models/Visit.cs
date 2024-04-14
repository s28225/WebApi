namespace WebApplication1.Models;

public class Visit
{
    public DateTime Date { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public double price { get; set; }

    public Visit(DateTime date, Animal animal, string description, double price)
    {
        this.Date = date;
        this.Animal = animal;
        this.Description = description;
        this.price = price;
    }
    
}