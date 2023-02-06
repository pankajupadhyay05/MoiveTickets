using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MoiveTickets.Data;
using MoiveTickets.Data.Base;
using MoiveTickets.Data.Services;
using MoiveTickets.Models;

namespace MoiveTickets.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IEntityBase<Actor> _service;

        public ActorsController(IActorsService service)
        {
             _service = service;
        }
        public async Task<IActionResult> Index()
        {
            var data = await _service.GetAllAsync();
            return View(data);
        }

        //Get : Actor/Create
        public IActionResult Create()
        {
            return View();
        }

        //Post : Actor/Create
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePic,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.AddAsync(actor);
            return RedirectToAction(nameof(Index));
        }

        //Get : Actors/Details/id

        public async Task<IActionResult> Details(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Get : Actors/Edit/id

        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Post : Actors/Edit/id

        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FullName,ProfilePic,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);
            }
            await _service.UpdateAsync(id, actor);
            return RedirectToAction(nameof(Index));
        }

        //Get : Actors/Delete/id

        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }

        //Post : Actors/Edit/id

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var actorDetails = await _service.GetByIdAsync(id);
            if (actorDetails == null) return View("NotFound");

            await _service.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
