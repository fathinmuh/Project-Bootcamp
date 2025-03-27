using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Repository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace AspNetCoreTodo.Repository
{
    public class TodoItemRepository : ITodoItemRepository
    {
        private readonly ApplicationDbContext _context;

        // Constructor initializing the EmployeeDBContext
        public TodoItemRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<TodoItem>> GetAllAsync()
        {
            return await _context.Items.ToListAsync(); // Fetch all employees from the database
        }

        public async Task<TodoItem?> GetByIdAsync(Guid id, string userId)
        {
            return await _context.TodoItems
                .FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task InsertAsync(TodoItem todoItem)
        {
            await _context.Items.AddAsync(todoItem); // Add a new employee
        }

        public async Task DeleteAsync(TodoItem item)
        {
            _context.TodoItems.Remove(item);
            await Task.CompletedTask;
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync(); // Commit changes to the database
        }

        public async Task<TodoItem[]> GetIncompleteItemsAsync(string UserId)
        {
            return await _context.Items
                            .Where(x => x.IsDone == false)
                            .ToArrayAsync();
        }

        public async Task<TodoItem> MarkDoneAsync(Guid id, string UserId)
        {
            return await _context.Items
            .Where(x => x.Id == id)
            .SingleOrDefaultAsync();
        }
    }
}