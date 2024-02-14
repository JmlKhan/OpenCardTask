using Library.Data;
using Library.Services.Interfaces;
using Library.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionStrings = builder.Configuration.GetSection("ConnectionStrings");
builder.Services.AddDbContext<AppDbContext>(o => o.UseSqlServer(connectionStrings["DefaultConnection"]));
//for local db
//builder.Services.AddDbContext<AppDbContext>(o => o.UseNpgsql(connectionStrings["pg"]));

builder.Services.AddTransient<DbInitializer>();
builder.Services.AddScoped<IStudentService, StudentService>();
builder.Services.AddScoped<IPublisherService, PublisherService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

//db initializer
using var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var initializer = services.GetRequiredService<DbInitializer>();

initializer.Run();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
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

app.Run();
