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

    [HttpGet] // Reverted from [HttpGet("Index")]
    public async Task<IActionResult> Index(string order = "asc", string searchTerm = "", int page = 1)
    {
        int pageSize = 10; // Кількість елементів на сторінці
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

        var count = events.Count;
        var pagedEvents = events.Skip((page - 1) * pageSize).Take(pageSize).ToList();

        ViewBag.SearchTerm = searchTerm;
        ViewBag.CurrentOrder = order; // Зберігаємо поточний порядок сортування

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(count / (double)pageSize);
        ViewBag.HasPreviousPage = (page > 1);
        ViewBag.HasNextPage = (page < ViewBag.TotalPages);

        return View(pagedEvents);
    }

    [HttpGet] // This maps to "Events/Create"
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
