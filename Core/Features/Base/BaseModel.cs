namespace Core;

public interface IBaseModel
{
    string Id {  get; set; }
}

public abstract class BaseModel : IBaseModel
{
    public string Id { get; set; } = Guid.NewGuid().ToString();
}
