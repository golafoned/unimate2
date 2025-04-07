using System.Diagnostics;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UniMate2.Data;
using UniMate2.Models;
using UniMate2.Models.Domain;
using UniMate2.Models.DTO;
using UniMate2.Repositories;

namespace UniMate2.Controllers;

public class EventsController(UserManager<User> userManager, IEventsRepository eventsRepository)
    : Controller
{
    private readonly UserManager<User> _userManager = userManager;
    private readonly IEventsRepository _eventsRepository = eventsRepository;

    [HttpGet]
    public async Task<IActionResult> Index(string order = "asc", string searchTerm = "")
    {
        var events = string.IsNullOrWhiteSpace(searchTerm)
            ? await _eventsRepository.GetAllEvents()
            : await _eventsRepository.SearchEvents(searchTerm);

        if (order.Equals("desc"))
        {
            events = events.OrderByDescending(e => e.StartDate).ToList();
        }
        else
        {
            events = events.OrderBy(e => e.StartDate).ToList();
        }

        ViewBag.SearchTerm = searchTerm;
        return View(events);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(EventDto eventDto)
    {
        if (ModelState.IsValid)
        {
            await _eventsRepository.AddEvent(eventDto);
            return RedirectToAction(nameof(Index));
        }
        return View(eventDto);
    }

    [HttpPost]
    public async Task<IActionResult> Delete(Guid id)
    {
        var result = await _eventsRepository.DeleteEvent(id);
        if (!result)
        {
            return NotFound();
        }
        return RedirectToAction(nameof(Index));
    }
}
