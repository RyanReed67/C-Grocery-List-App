using GroceryApp.Data.Entities;

namespace GroceryApp.Services.Interfaces
{

public interface IGroceryService
{
    int AddNewItem(string name, bool shouldCheck);
    void ClearAllItems();
    void ClearCompletedItems();
    List<GroceryItem> GetAll();
    void ToggleItemStatus(int id);
}
}