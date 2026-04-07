using GroceryApp.Data.Entities;

namespace GroceryApp.Data.Repositories
{
    public class GroceryRepository : IGroceryRepository
    {
        // This class is responsible for all direct interactions with the database. It should contain no business logic, only data access code.
        private readonly GroceriesContext _context;

        // The constructor takes a database connection, which will be provided by dependency injection.
        public GroceryRepository(GroceriesContext context) 
        {
            _context = context;
        }

        // This method retrieves all grocery items from the database, ordered by name.
        public IEnumerable<GroceryItem> GetAll() 
        {
            return _context.GroceryItems.OrderBy(item => item.Name);
        }


        // This method retrieves a single grocery item by its name. It returns null if no item is found.
        public GroceryItem? GetByName(string name)
        {
            return _context.GroceryItems.FirstOrDefault(item => item.Name == name);
        }


        // This method deletes all items from the grocery_items table.
        public void DeleteAll() 
        { 
            _context.GroceryItems.RemoveRange(_context.GroceryItems); 
            _context.SaveChanges();
        }

        // This method deletes a single item by its ID.
        // GroceryRepository.cs
        public void DeleteCompleted()
        {
        _context.GroceryItems.RemoveRange(_context.GroceryItems.Where(item => item.IsCompleted));
        _context.SaveChanges();
        } 

        // This method inserts a new grocery item into the database and returns the ID of the newly created item.
        public int Insert(string name)
        { 
            var newItem = new GroceryItem { Name = name, IsCompleted = false };
            _context.GroceryItems.Add(newItem); 
            _context.SaveChanges(); 
            return newItem.Id;
        }

        // This method toggles the completion status of an item by its ID.
        public void ToggleStatus(int id)
        { 
            var item = _context.GroceryItems.FirstOrDefault(item => item.Id == id);
            if (item != null)
            {
                item.IsCompleted = !item.IsCompleted;
                _context.SaveChanges();
            } 
            else 
            {
                throw new Exception($"Item with ID {id} not found.");
            }
        }
    }
}

