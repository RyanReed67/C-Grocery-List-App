using Microsoft.AspNetCore.Mvc;
using GroceryApp.Services.Interfaces;

namespace GroceryApp.Controllers;

public class HomeController : Controller
{
    private readonly IGroceryService _service;

    public HomeController(IGroceryService service)
    {
        _service = service;
    }

    [HttpPost]
    public IActionResult AddItem(string name, bool check = false)
    {
        var success = true;
        var message = string.Empty;
        var id = 0;
        try 
        {
            id = _service.AddNewItem(name, check);
        }
        catch (Exception ex) 
        {
            message = ex.Message;
            success = false;
        }
        return Json(new { success, id, name, message });

    }

    [HttpPost]
    public IActionResult ClearAll()
    {
        var success = true;
        try 
        {
            _service.ClearAllItems();
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
            success = false;
        }
        return Json(new { success });

    }

    [HttpPost]
    public IActionResult ClearCompleted()
    {
        var success = true;
        try 
        {
            _service.ClearCompletedItems();
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
            success = false;
        }
        return Json(new { success });

    }

    public PartialViewResult GetItems() 
    {
        return PartialView("_Items", _service.GetAll());
    }

    public IActionResult Index() 
    {
        return View();
    }

    [HttpPost]
    public IActionResult ToggleItem(int id)
    {
        var success = true;
        try 
        {
            _service.ToggleItemStatus(id);
        }
        catch (Exception ex) 
        {
            Console.WriteLine(ex.Message);
            success = false;
        }
        return Json(new { success });
    }
}
