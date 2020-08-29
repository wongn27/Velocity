using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Repository;
using Velocity.Data;

namespace Velocity.Web.Controllers
{
    public class TransitController : Controller
    {
        private readonly TransitRepository TransitRepository;

        public TransitController(TransitRepository TransitRepository)
        {
            this.TransitRepository = TransitRepository;
        }

        // GET: Transit
        public async Task<IActionResult> Index()
        {
            return View(await TransitRepository.GetAllAsync());
        }

        // GET: Transit/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Transit = await TransitRepository.GetAsync(id.Value);
            if (Transit == null)
            {
                return NotFound();
            }

            return View(Transit);
        }

        // GET: Transit/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Transit/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TransitNumber,Weight,CartonsCount")] Transit Transit)
        {
            if (ModelState.IsValid)
            {
                Transit.Id = Guid.NewGuid();
                await TransitRepository.CreateAsync(Transit);
                return RedirectToAction(nameof(Index));
            }
            return View(Transit);
        }

        // GET: Transit/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Transit = await TransitRepository.GetAsync(id.Value);
            if (Transit == null)
            {
                return NotFound();
            }
            return View(Transit);
        }

        // POST: Transit/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TransitNumber,Weight,CartonsCount")] Transit Transit)
        {
            if (id != Transit.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await TransitRepository.UpdateAsync(Transit);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TransitExists(Transit.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(Transit);
        }

        // GET: Transit/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Transit = await TransitRepository.GetAsync(id.Value);
            if (Transit == null)
            {
                return NotFound();
            }

            return View(Transit);
        }

        // POST: Transit/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var Transit = await TransitRepository.GetAsync(id);
            await TransitRepository.DeleteAsync(Transit);
            return RedirectToAction(nameof(Index));
        }

        private bool TransitExists(Guid id)
        {
            return TransitRepository.Get(id) != null;
        }
    }
}
