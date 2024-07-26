using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Bookshop.Models;
using Bookshop.Data;
namespace Bookshop.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly AppDbContext _context ;
    private readonly AppDbContext _contextInfo ;


    public HomeController(ILogger<HomeController> logger , AppDbContext context , AppDbContext contextInfo)
    {
        _logger = logger;
        _context = context;
        _contextInfo = contextInfo;
    }


    // public IActionResult Index()
    // {
    //     var books = _context.Book.ToList();
    //     return View(books);
    // }
    public IActionResult Index()
    {
        var books = _context.Book.ToList();
        return View(books);
    
    }

    public IActionResult Create(){
        return View();
    }
    

    [HttpPost]
    [ValidateAntiForgeryToken]

    public IActionResult Create([Bind("Id" , "Title")]Books book){
            _context.Add(book);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        
        return View(book);
    }

    public IActionResult Details(){
        var temp = _contextInfo.Booksinfo.ToList();
        return View(temp);
    }



    public IActionResult  Info(){
        return View();
    }
    [HttpPost]
    public IActionResult Info([Bind("Id" , "Title" , "Description" , "Price", "Author")] BookInfo info){
        if (ModelState.IsValid){
            _contextInfo.Add(info);
            _contextInfo.SaveChanges();
            return RedirectToAction(nameof(Details));
        }
        return View(info);
        
    }
    [HttpGet]
    public IActionResult Edit(int id){
        var task = _contextInfo.Booksinfo.Find(id);
        if(task == null){
            return NotFound();
        }
        return View(task);
    }
    [HttpPost]

    public IActionResult Edit(BookInfo info){
        if(info ==null){
            return BadRequest();
        }
        if(!ModelState.IsValid){
            return BadRequest();
        }
        var Newinfo = _contextInfo.Booksinfo.Find(info.Id);
        if(Newinfo == null){
            return NotFound();
        }
        Newinfo.Title = info.Title;
        Newinfo.Description = info.Description;
        Newinfo.Price = info.Price;
        Newinfo.Author = info.Author;
        _contextInfo.SaveChanges();
        return RedirectToAction(nameof(Details));
    }



    
    public IActionResult Privacy()
    {
        return View();
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
