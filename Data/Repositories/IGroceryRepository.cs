using GroceryApp.Data.Entities;

namespace GroceryApp.Data.Repositories
{
    // This interface defines the contract for the GroceryRepository. It specifies what methods the repository must implement, without dictating how they should be implemented.
    public interface IGroceryRepository
    {
        IEnumerable<GroceryItem> GetAll();
        GroceryItem? GetByName(string name);
        void DeleteAll();
        void DeleteCompleted();
        int Insert(string name);
        void ToggleStatus(int id);
    }
}