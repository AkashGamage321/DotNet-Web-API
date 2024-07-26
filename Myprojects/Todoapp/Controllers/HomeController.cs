using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using Todoapp.Data;
using Todoapp.Models;

namespace Todoapp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly AppDbContext _context;

        public HomeController(ILogger<HomeController> logger, AppDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var tasks = _context.TaskModels.ToList();
            return View(tasks);
        }

        public IActionResult Privacy()
        {
            var tasks = _context.TaskModels.ToList();
            return View(tasks);
        }
        public IActionResult Create(){
            return View();
        }

        [HttpPost]
        public IActionResult Create([Bind("Id" ,"Title")]TaskModel task)
        {
            if (task == null)
            {
                return BadRequest();
            }
            if (ModelState.IsValid)
            {
                _context.TaskModels.Add(task);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(task);
        }
        [HttpGet]

        public IActionResult Edit(int id ){
            var task = _context.TaskModels.Find(id);
            if (task ==null){
                return NotFound();
            }
            return View(task);
        }
        [HttpPost]

        public IActionResult Edit (TaskModel task){
            if (task == null){
                return BadRequest();
            }
            if(!ModelState.IsValid){
                return BadRequest();
            }
            var Newtask = _context.TaskModels.Find(task.Id);
            if (Newtask == null ){
                return NotFound();
            }
            Newtask.Title = task.Title;
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        public IActionResult Delete(int id ){
            var task = _context.TaskModels.Find(id);
            if(task ==null){
                return NotFound();
            }
            _context.TaskModels.Remove(task);
            return RedirectToAction(nameof(Index));
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
