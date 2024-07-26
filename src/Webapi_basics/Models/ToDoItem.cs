
using System.ComponentModel.DataAnnotations;

namespace Webapi_basics.Models
{
    public class ToDoItem{
        public int Id { get; set; }
        [Required(ErrorMessage ="Title is Required!")]
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }



}