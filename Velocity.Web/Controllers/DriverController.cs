using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Repository;
using Velocity.Data;

namespace Velocity.Web.Controllers
{
    public class DriverController : Controller
    {
        private readonly DriverRepository driverRepository;

        public DriverController(DriverRepository DriverRepository)
        {
            this.driverRepository = DriverRepository;
        }

        // GET: Driver
        public async Task<IActionResult> Index()
        {
            return View(await driverRepository.GetAllAsync());
        }

        // GET: Driver/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Driver driver = await driverRepository.GetAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // GET: Driver/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Driver/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DriverNumber,Weight,CartonsCount")] Driver driver)
        {
            if (ModelState.IsValid)
            {
                driver.Id = Guid.NewGuid();
                await driverRepository.CreateAsync(driver);
                return RedirectToAction(nameof(Index));
            }
            return View(driver);
        }

        // GET: Driver/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await driverRepository.GetAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }
            return View(driver);
        }

        // POST: Driver/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,DriverNumber,Weight,CartonsCount")] Driver driver)
        {
            if (id != driver.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    await driverRepository.UpdateAsync(driver);
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DriverExists(driver.Id))
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
            return View(driver);
        }

        // GET: Driver/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var driver = await driverRepository.GetAsync(id.Value);
            if (driver == null)
            {
                return NotFound();
            }

            return View(driver);
        }

        // POST: Driver/Delete/5
        [HttpPost, ActionName(nameof(Delete))]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var driver = await driverRepository.GetAsync(id);
            await driverRepository.DeleteAsync(driver);
            return RedirectToAction(nameof(Index));
        }

        private bool DriverExists(Guid id)
        {
            return driverRepository.Get(id) != null;
        }
    }
}
