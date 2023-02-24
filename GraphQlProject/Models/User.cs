namespace GraphQlProject.Models;

public class User
{
    public string id { get; set; }
    public bool isActive { get; set; }
    public Contact contact { get; set; }
}

public class Contact
{
    public string firstName { get; set; }
    public string lastName { get; set; }
    public string email { get; set; }
    public string phoneNumber { get; set; }
}
