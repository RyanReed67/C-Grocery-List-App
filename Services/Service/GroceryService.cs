using System.Text.RegularExpressions;
using GroceryApp.Data.Repositories;
using GroceryApp.Data.Entities;
using GroceryApp.Services.Interfaces;

namespace GroceryApp.Services.Service;

public class GroceryService : IGroceryService
{

    private readonly IGroceryRepository _repo;
    public GroceryService(IGroceryRepository repo)
    {
       _repo = repo; 
    } 

    public int AddNewItem(string name, bool shouldCheck)
    {
        // Validation 
        if (Regex.IsMatch(name, @"[^a-zA-Z0-9\s]"))
            throw new Exception("Item name cannot contain special characters.");

        // Check for duplicates
        if (_repo.GetByName(name) != null)
            throw new Exception("An item with that name already exists.");

        // Execution
        int newId = _repo.Insert(name);

        // Post-install logic
        if (shouldCheck) _repo.ToggleStatus(newId);

        return newId;
    }

    // This method clears all items from the grocery list.
    public void ClearAllItems() 
    {
        _repo.DeleteAll(); // Make sure this line exists!
    }

    // This method clears only the completed items from the grocery list.
    public void ClearCompletedItems() 
    {
        // One direct call to the database
        _repo.DeleteCompleted(); 
    }

    public List <GroceryItem> GetAll()
    {
        return _repo.GetAll().ToList();
    } 

        // This method toggles the completion status of a specific item by its ID.
    public void ToggleItemStatus(int id)
    {
        _repo.ToggleStatus(id);
    }

}