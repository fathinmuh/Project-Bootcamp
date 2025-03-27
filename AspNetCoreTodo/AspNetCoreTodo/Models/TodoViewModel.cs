using AspNetCoreTodo.DTO;
namespace AspNetCoreTodo.Models
{
    public class TodoViewModel
    {
        // public TodoItem[] Items { get; set; }
        public IEnumerable<TodoItemDTO> Items { get; set; }
    }
}