using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Velocity.Core.Repository;
using Velocity.Data;

namespace Velocity.Web.Controllers
{
    public class FeeController : Controller
    {
        private readonly FeeRepository FeeRepository;

        public FeeController(FeeRepository FeeRepository)
        {
            this.FeeRepository = FeeRepository;
        }

        // GET: Fee
        public async Task<IActionResult> Index()
        {
            return View(await FeeRepository.GetAllAsync());
        }

        // GET: Fee/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await FeeRepository.GetAsync(id.Value);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }
    }
}
