using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Repository;
using Velocity.Data;
using Velocity.Data.Models;

namespace Velocity.Web.Controllers
{
    public class ContainerController : Controller
    {
        private readonly ContainerRepository containerRepository;

        public ContainerController(ContainerRepository containerRepository)
        {
            this.containerRepository = containerRepository;
        }

        // GET: Container
        public async Task<IActionResult> Index()
        {
            return View(await containerRepository.GetAllAsync());
        }

        // GET: Container/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Container container = await containerRepository.GetAsync(id.Value);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // GET: Container/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Container/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ContainerNumber,Weight,CartonsCount")] Container container)
        {
            if (ModelState.IsValid)
            {
                container.Id = Guid.NewGuid();
                await containerRepository.CreateAsync(container);
                return RedirectToAction(nameof(Index));
            }
            return View(container);
        }

        // GET: Container/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Container container = await containerRepository.GetAsync(id.Value);
            if (container == null)
            {
                return NotFound();
            }
            return View(container);
        }

        // POST: Container/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,ContainerNumber,Weight,CartonsCount")] Container container)
        {
            if (id != container.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await containerRepository.UpdateAsync(container);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContainerExists(container.Id))
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
            return View(container);
        }

        // GET: Container/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Container container = await containerRepository.GetAsync(id.Value);
            if (container == null)
            {
                return NotFound();
            }

            return View(container);
        }

        // POST: Container/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            Container container = await containerRepository.GetAsync(id);
            await containerRepository.DeleteAsync(container);
            return RedirectToAction(nameof(Index));
        }

        private bool ContainerExists(Guid id)
        {
            return containerRepository.Get(id) != null;
        }
    }
}
