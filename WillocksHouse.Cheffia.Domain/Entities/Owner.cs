namespace WillocksHouse.Cheffia.Domain.Entities;

public class Owner
{
    public Owner()
    {
    }

    public Owner(string name, string email, string password, string document)
    {
        Name = name;
        Email = email;
        Password = password;
        Document = document;
    }

    public Guid Id { get; set; } = Guid.NewGuid();
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Document { get; set; }
}