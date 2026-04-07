using GroceryApp.Data.Entities;
using GroceryApp.Services.Interfaces;

namespace GroceryApp.Services.MockService
{
    public class MockGroceryService : IGroceryService
    {
        private readonly List<GroceryItem> _items = new();
        private int _nextId = 1;
 
        public int AddNewItem(string name, bool shouldCheck)
        {
            var item = new GroceryItem { Id = _nextId++, Name = name, IsCompleted = shouldCheck };
            _items.Add(item);
            return item.Id;
        }
 
        public void ClearAllItems() => _items.Clear();
 
        public void ClearCompletedItems() => _items.RemoveAll(i => i.IsCompleted);
 
        public List<GroceryItem> GetAll() => _items;
 
        public void ToggleItemStatus(int id)
        {
            var item = _items.FirstOrDefault(i => i.Id == id);
            if (item != null) item.IsCompleted  = !item.IsCompleted;
        }
    }

}

