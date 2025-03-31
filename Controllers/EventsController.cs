using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models;
using UniMate2.Models.Domain;
using UniMate2.Repositories;

namespace UniMate2.Controllers;

public class EventsController(UserManager<User> userManager, IEventsRepository eventsRepository)
    : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IEventsRepository _eventsRepository = eventsRepository;

    [HttpGet]
    public async Task<IActionResult> Index(string order = "asc")
    {
        var events = await _eventsRepository.GetAllEvents();

        if (order.Equals("desc"))
        {
            events = events.OrderByDescending(e => e.StartDate).ToList();
        }
        else
        {
            events = events.OrderBy(e => e.StartDate).ToList();
        }

        return View(events);
    }
}
