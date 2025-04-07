using Microsoft.AspNetCore.Http.Features;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
// using Server.Data;
using UniMate2.Data;
using UniMate2.Models.Domain;
using UniMate2.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Configure logging
builder.Logging.ClearProviders();
builder.Logging.AddConsole();
builder.Logging.AddDebug();
builder.Logging.SetMinimumLevel(LogLevel.Information);

// Add services to the container
builder.Services.AddDbContext<ServerDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
);

// Register repositories in the right order to avoid circular dependencies
builder.Services.AddScoped<IDislikeRepository, DislikeRepository>();
builder.Services.AddScoped<ILikeRepository, LikeRepository>();
builder.Services.AddScoped<IFriendsRepository, FriendsRepository>();
builder.Services.AddScoped<IEventsRepository, EventsRepository>();
builder.Services.AddScoped<IUsersRepository, UsersRepository>();
builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add Bootstrap Icons
builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation();

builder
    .Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<ServerDbContext>()
    .AddDefaultTokenProviders();

// Set up form file size limits for image uploads
builder.Services.Configure<FormOptions>(options =>
{
    options.MultipartBodyLengthLimit = 10 * 1024 * 1024; // 10 MB
});

builder.Services.AddControllersWithViews();
var app = builder.Build();

// Create a logger for startup processes
var logger = app.Services.GetRequiredService<ILogger<Program>>();
logger.LogInformation("Application starting up");

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}

// Create uploads directory in wwwroot
var uploadsDirectory = Path.Combine(
    app.Environment.WebRootPath ?? Path.Combine(Directory.GetCurrentDirectory(), "wwwroot"),
    "uploads"
);
if (!Directory.Exists(uploadsDirectory))
{
    logger.LogInformation($"Creating uploads directory at: {uploadsDirectory}");
    Directory.CreateDirectory(uploadsDirectory);
    logger.LogInformation($"Directory created: {Directory.Exists(uploadsDirectory)}");

    // Write a test file to verify permissions
    try
    {
        var testFile = Path.Combine(uploadsDirectory, "app_startup_test.txt");
        File.WriteAllText(testFile, $"Test file created at {DateTime.Now}");
        logger.LogInformation($"Test file created successfully at {testFile}");
    }
    catch (Exception ex)
    {
        logger.LogError($"ERROR: Failed to write test file: {ex.Message}");
    }
}

// Configure static files with higher priority for uploads folder
app.UseStaticFiles(); // Serve files from wwwroot

// Add middleware to log all requests to /uploads/* paths
app.Use(
    async (context, next) =>
    {
        var path = context.Request.Path.Value ?? "";
        if (path.StartsWith("/uploads/"))
        {
            logger.LogInformation($"Request for: {path}");
            var filePath = Path.Combine(
                Directory.GetCurrentDirectory(),
                "wwwroot",
                path.TrimStart('/')
            );
            logger.LogInformation($"Physical path: {filePath}, Exists: {File.Exists(filePath)}");
        }

        await next();
    }
);

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(name: "default", pattern: "{controller=Home}/{action=Index}/{id?}");

logger.LogInformation("Application started and ready to handle requests");
app.Run();
