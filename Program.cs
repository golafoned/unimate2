using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models; // Add this for MappingProfile
using UniMate2.Models.Domain;
using UniMate2.Repositories;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ServerDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
);

builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddScoped<IFriendRequestRepository, FriendRequestRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

builder
    .Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ServerDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();
var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
