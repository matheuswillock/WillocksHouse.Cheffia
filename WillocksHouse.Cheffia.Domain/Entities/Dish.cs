namespace WillocksHouse.Cheffia.Domain.Entities;

public class Dish
{
    public Dish()
    {
    }

    public Dish(string name, string description, decimal price)
    {
        Name = name;
        Description = description;
        Price = price;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Description { get; set; }
    public decimal Price { get; set; }
}