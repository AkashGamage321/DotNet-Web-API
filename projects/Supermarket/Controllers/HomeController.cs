using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Supermarket.Models;
using Supermarket.Data; 
using System.Linq;

namespace Supermarket.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context;

    public HomeController(ILogger<HomeController> logger , AppDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    public IActionResult Index()
    {
        var items = _context.Item.ToList();

        return View(items);
    }
    public IActionResult UserView(){
        var items = _context.Item.ToList();
        return View(items);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult Product(){
        return View();
    }
    [HttpPost]
    public IActionResult Product([Bind("Id" , "Name" , "Description" , "Price")]Items item){
        if(item == null){
            return BadRequest();
        }
        if(ModelState.IsValid){
            _context.Item.Add(item);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        return View(item);
    }

    [HttpGet("info/{id}")]
    public IActionResult Info(int id){

        var itemId = _context.Item.FirstOrDefault(i => i.Id == id); 
        if (itemId == null ){
            return NotFound();
        }
        return View(itemId);
    }
    public IActionResult Order()
    {
        return View();
    }
    // [HttpPost("order/{id}")]    
    // public IActionResult Order(int id , [Bind("ItemId" , "Address" , "Phone" , "Stakes")] Cart_info cart){
    //     var confirm = _context.Cart.FirstOrDefault(i => i.ItemId ==id);

    //     if (ModelState.IsValid){
    //         _context.Cart.Add(cart);
    //         _context.SaveChanges();
    //         return RedirectToAction(nameof(Info), new { id = id });
    //     }


    //     return View(confirm);
    // }

    [HttpPost("order/{id}")]
    public IActionResult Order(int id, [Bind("ItemId", "Address", "Phone", "Stakes")] Cart_info cart)
    {
        var confirm = _context.Item.FirstOrDefault(i => i.Id == id); // Assuming you meant Item, not Cart
        if (confirm == null)
        {
            return NotFound();
        }
        if (cart == null)
        {
            return BadRequest();
        }
        if (ModelState.IsValid)
        {
            _context.Cart.Add(cart); // Ensure your DbSet is named Cart
            _context.SaveChanges();
            return RedirectToAction(nameof(Info), new { id = id });
        }
        return View(confirm);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
