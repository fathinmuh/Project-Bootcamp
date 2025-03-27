using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AspNetCoreTodo.Data;
using AspNetCoreTodo.Services;
using AspNetCoreTodo.Models;
using AspNetCoreTodo.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using AutoMapper;
using AspNetCoreTodo.DTO;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();
builder.Services.AddControllersWithViews();

builder.Services.AddFluentValidationAutoValidation();
//Enables integration between FluentValidation and ASP.NET client-side validation.
builder.Services.AddFluentValidationClientsideAdapters();
//Registering Model and Validator to show the error message on client side
builder.Services.AddTransient<IValidator<TodoItem>, TodoItemValidator>();
builder.Services.AddTransient<IValidator<TodoItemDTO>, TodoItemDTOValidator>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);



// Menambahkan MVC
builder.Services.AddMvc();
builder.Services.AddScoped<ITodoItemRepository, TodoItemRepository>();

builder.Services.AddScoped<ITodoItemService, TodoItemService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
