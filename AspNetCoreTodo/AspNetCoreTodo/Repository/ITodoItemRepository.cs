using System.Collections.Generic;
using AspNetCoreTodo.Models;
using Microsoft.AspNetCore.Identity;
namespace AspNetCoreTodo.Repository
{
    public interface ITodoItemRepository
    {
        Task <IEnumerable<TodoItem>> GetAllAsync();            // Retrieve all employees
        Task<TodoItem?> GetByIdAsync(Guid id, string userId);          // Retrieve a single employee by ID
        Task InsertAsync(TodoItem todoItem);            // Insert a new employee
        Task DeleteAsync(TodoItem item);               // Delete an employee by ID
        Task <int>SaveAsync();
        Task<TodoItem[]> GetIncompleteItemsAsync (string UserId);
        Task<TodoItem> MarkDoneAsync(Guid id, string UserId);
    }
}