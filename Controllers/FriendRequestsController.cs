using Microsoft.AspNetCore.Mvc;
using UniMate2.Models.Domain;
using UniMate2.Models.Enums;
using UniMate2.Repositories;

namespace UniMate2.Controllers;

public class FriendRequestsController(IFriendRequestRepository repository) : Controller
{
    private readonly IFriendRequestRepository _repository = repository;

    public async Task<IActionResult> Index()
    {
        var requests = await _repository.GetAllAsync();
        return View(requests);
    }

    public IActionResult Create() => View();

    [HttpPost]
    public async Task<IActionResult> Create(FriendRequest model)
    {
        if (!ModelState.IsValid) return View(model);

        await _repository.AddAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Edit(Guid id)
    {
        var request = await _repository.GetByIdAsync(id);
        return request == null ? NotFound() : View(request);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(FriendRequest model)
    {
        if (!ModelState.IsValid) return View(model);

        await _repository.UpdateAsync(model);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Delete(Guid id)
    {
        var request = await _repository.GetByIdAsync(id);
        return request == null ? NotFound() : View(request);
    }

    [HttpPost, ActionName("Delete")]
    public async Task<IActionResult> DeleteConfirmed(Guid id)
    {
        await _repository.DeleteAsync(id);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Details(Guid id)
    {
        var request = await _repository.GetByIdAsync(id);
        return request == null ? NotFound() : View(request);
    }
}
