using System.Collections.Generic;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
namespace AspNetCoreTodo.Repository
{
    public interface ITodoItemRepository
    {
        Task <IEnumerable<TodoItem>> GetAllAsync();            // Retrieve all employees
        Task <TodoItem> GetByIdAsync(int Id);          // Retrieve a single employee by ID
        Task InsertAsync(TodoItem todoItem);            // Insert a new employee
        Task DeleteAsync(int Id);               // Delete an employee by ID
        Task <int>SaveAsync();
        Task<TodoItem[]> GetIncompleteItemsAsync (string UserId);
        Task<TodoItem> MarkDoneAsync(Guid id, string UserId);
    }
}