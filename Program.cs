using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using TodosList.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<TodosContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("TodosContext") ?? throw new InvalidOperationException("Connection string 'TodosContext' not found.")));
var app = builder.Build();

// Configure the HTTP request pipeline.
if (builder.Environment.IsDevelopment())

{
}
else
{
    builder.Services.AddDbContext<TodosContext>(options =>
        options.UseSqlServer(builder.Configuration.GetConnectionString("ProductionTodosContext")));
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
