namespace Webapi_basics.Models
{
    public class ToDoItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public bool Completed { get; set; }
    }
}
