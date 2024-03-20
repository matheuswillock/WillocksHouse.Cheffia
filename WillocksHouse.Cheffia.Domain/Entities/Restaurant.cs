namespace WillocksHouse.Cheffia.Domain.Entities;

public class Restaurant
{
    public Restaurant()
    {
    }

    public Restaurant(Guid ownerId, string name, Guid menuId)
    {
        OwnerId = ownerId;
        Name = name;
        MenuId = menuId;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public Guid OwnerId { get; set; }
    public string Name { get; set; }
    public Guid MenuId { get; set; }
}