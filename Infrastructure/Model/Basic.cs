namespace Infrastructure.Model;

public class Basic
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreationTime { get; set; } = DateTime.Now;
    public DateTime? DeleteTime { get; set; } = null;
    public bool IsDeleted { get; set; } = false;
}