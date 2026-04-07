namespace GroceryApp.Data.Entities;

public class GroceryItem : BaseEntity
{
    public string Name { get; set; } = null!;

    public bool IsCompleted { get; set; }

    public DateTime? CreatedAt { get; set; }
}
