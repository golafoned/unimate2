using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models;
using UniMate2.Models.Domain;

namespace UniMate2.Controllers;

public class HomeController(UserManager<User> userManager) : Controller
{
    private readonly UserManager<User> _userManager = userManager;

    public IActionResult Index()
    {
        var userNames = _userManager.Users.Select(u => u.UserName).ToList();
        return View(userNames);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }
}
