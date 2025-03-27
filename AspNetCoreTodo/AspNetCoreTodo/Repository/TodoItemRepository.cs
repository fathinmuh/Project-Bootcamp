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

        public async Task<TodoItem> GetByIdAsync(int Id)
        {
            return await _context.Items.FindAsync(Id); // Fetch a specific employee by ID
        }

        public async Task InsertAsync(TodoItem todoItem)
        {
            await _context.Items.AddAsync(todoItem); // Add a new employee
        }

        public async Task DeleteAsync(int Id)
        {
            var todoItem = await _context.Items.FindAsync(Id);
            if (todoItem != null)
            {
                _context.Items.Remove(todoItem); // Remove employee from the database
            }
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