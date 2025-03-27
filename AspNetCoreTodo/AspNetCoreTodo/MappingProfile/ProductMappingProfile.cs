using AutoMapper;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.DTO;


namespace AspNetCoreTodo.MappingProfile
{
    public class TodoItemMappingProfile:Profile
    {
        public TodoItemMappingProfile()
        {
            CreateMap<TodoItem, TodoItemDTO>();
            CreateMap<TodoItemDTO, TodoItem>();
        }
    }
}