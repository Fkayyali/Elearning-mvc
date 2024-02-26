using Api.Filters;
using Data;
using Microsoft.EntityFrameworkCore;
using Service;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<ICoursesService, CoursesService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IUserCourseService, UserCourseService>();
builder.Services.AddScoped<ITokenService, TokenService>();

var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.MapWhen(context => context.Request.Path.StartsWithSegments("/courses"), builder =>
{ 
    builder.UseMiddleware<TokenValidationMiddleware>();
});
app.UseRouting();

app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
