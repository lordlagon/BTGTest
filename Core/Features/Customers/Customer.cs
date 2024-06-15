namespace Core;

public class Customer : IBaseModel
{
    public string Id { get ; set ; } = Guid.NewGuid().ToString();
    public string Name { get; set; }
    public string LastName { get; set; }
    public int Age { get; set; }
    public string Address { get; set; }
}