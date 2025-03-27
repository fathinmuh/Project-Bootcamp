using Microsoft.AspNetCore.Mvc;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.DTO;
using AspNetCoreTodo.MappingProfile;
using AspNetCoreTodo.Data;


using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using AutoMapper;


namespace AspNetCoreTodo.Controllers
{
    [Authorize]
    public class TodoController : Controller
    {
        private readonly ITodoItemService _todoItemService;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IMapper _mapper;

        public TodoController(ITodoItemService todoItemService, UserManager<IdentityUser> userManager, IMapper mapper)
        {
            _todoItemService = todoItemService;
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task<IActionResult> Index(TodoItemDTO newItemDTO)
        {
            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var items = await _todoItemService.GetIncompleteItemsAsync(currentUser);

            var itemDTOs = _mapper.Map<IEnumerable<TodoItemDTO>>(items);
            var model = new TodoViewModel()
            {
                Items = itemDTOs
            };
            return View(model);
        }
        // var newItem = _mapper.Map<TodoItemDTO>(items);
        // var todoItem = _mapper.Map<TodoItem >(newitem);    
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddItem(TodoItemDTO newItemDTO)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", newItemDTO);
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var newItem = _mapper.Map<TodoItem>(newItemDTO);


            var successful = await _todoItemService.AddItemAsync(newItem, currentUser);
            if (!successful)
            {
                return BadRequest("Could	not	add	item.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null) return Challenge();

            var successful = await _todoItemService.MarkDoneAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest("Could	not	mark	item	as	done.");
            }
            return RedirectToAction("Index");
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteItem(Guid id)
        {
            if (id == Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var currentUser = await _userManager.GetUserAsync(User);
            if (currentUser == null)
            {
                return Challenge();
            }

            var successful = await _todoItemService.DeleteItemAsync(id, currentUser);
            if (!successful)
            {
                return BadRequest(new { error = "Could not delete item." });
            }

            return RedirectToAction("Index");
        }

    }
}