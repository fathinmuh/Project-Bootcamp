using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
namespace AspNetCoreTodo.Services
{
    public class TodoItemService : ITodoItemService
    {
        private readonly ApplicationDbContext _context;
        private readonly ITodoItemRepository _todoItemRepository;
        public TodoItemService(ApplicationDbContext context, ITodoItemRepository todoItemRepository)
        {
            _context = context;
            _todoItemRepository = todoItemRepository;
        }
        public async Task<TodoItem[]> GetIncompleteItemsAsync(IdentityUser user)
        {
            return await _todoItemRepository.GetIncompleteItemsAsync(user.Id);
        }

        public async Task<bool> AddItemAsync(TodoItem newItem, IdentityUser user)
        {
            newItem.Id = Guid.NewGuid();
            newItem.IsDone = false;
            newItem.DueAt = DateTimeOffset.Now.AddDays(3);
            // await _context.Items.AddAsync(newItem);
            await _todoItemRepository.InsertAsync(newItem);
            // var saveResult = await _context.SaveChangesAsync();
            var saveResult = await _todoItemRepository.SaveAsync();
            return saveResult == 1;
        }

        public async Task<bool> MarkDoneAsync(Guid id, IdentityUser user)
        {
            var item = await _todoItemRepository.MarkDoneAsync(id,user.Id);
            if (item == null) return false;
            item.IsDone = true;

            var saveResult = await _todoItemRepository.SaveAsync();
            return saveResult == 1; //	One	entity	should	have	been	updated
        }
    }
}