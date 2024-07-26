using Microsoft.AspNetCore.Mvc;
using Webapi_basics.Models;

namespace Webapi_basics.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ToDoController : ControllerBase
    {
        private static List<ToDoItem> _toDoItems = new List<ToDoItem>
        {
            new ToDoItem { Id = 1, Title = "You are My sunshine", Completed = true },
            new ToDoItem { Id = 2, Title = "Summertime in beach", Completed = false }
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            if (_toDoItems.Count == 0)
            {
                return NotFound();
            }
            return Ok(_toDoItems);
        }
        
        [HttpGet("{id}")]
        public IActionResult GetToDoItemById(int id)
        {
            if(_toDoItems.Count == 0 ){
                return NotFound();
            }

            var toDoItems = _toDoItems.FirstOrDefault(item=> item.Id == id);
            if(toDoItems == null ){
                return NotFound();
            }

            return Ok(_toDoItems);
        }
        [HttpPost]
        public IActionResult CreateToDoItem([FromBody]ToDoItemDTO newItemDTO)
        {
            if(newItemDTO ==null){
                return BadRequest();
            }
            if(!ModelState.IsValid){
                return BadRequest(ModelState);
            }
            var newItem = new ToDoItem{
                Title = newItemDTO.Title , 
                Completed = newItemDTO.Completed
            };
            int newId = _toDoItems.Max(item => item.Id)+1;
            newItem.Id = newId ;

            _toDoItems.Add(newItem);

            return CreatedAtAction(nameof(GetToDoItemById) , new{id = newItem.Id} , newItem); //whenever you create getbyid fuction nameof(givethatname)

        }
    }
}
