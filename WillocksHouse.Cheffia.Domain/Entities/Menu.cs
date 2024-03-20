namespace WillocksHouse.Cheffia.Domain.Entities;

public class Menu
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public List<Guid> Dishes { get; set; } = new();
}