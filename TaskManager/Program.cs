using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using TaskManager.Data;
using TaskManager.Helpers;
using TaskManager.Data.DbInitializer;
using TaskManager.Services;
using TaskManager.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DevConnection"));
});


builder.Services.AddScoped<ITaskService, TaskService>();
builder.Services.AddScoped<IListService, ListService>();
builder.Services.AddAutoMapper(typeof(MappingProfile));


builder.Services.AddScoped<IDbInitializer, DbInitializer>();
// Shto Swagger
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Task Manager API",
        Description = "A simple ASP.NET Core MVC API for managing tasks"
    });
});



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}
else
{
    // Konfiguro Swagger vetëm në zhvillim
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Task Manager API V1");
        c.RoutePrefix = string.Empty; // Swagger UI do të jetë në root të aplikacionit
    });
}

var dbInitializer = app.Services.CreateScope().ServiceProvider.GetRequiredService<IDbInitializer>();
dbInitializer.Initialize();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
