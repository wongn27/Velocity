using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Velocity.Core.Repository;

namespace Velocity.Web.Controllers
{
    public class FeeController : Controller
    {
        private readonly FeeRepository feeRepository;

        public FeeController(FeeRepository feeRepository)
        {
            this.feeRepository = feeRepository;
        }

        // GET: Fee
        public async Task<IActionResult> Index()
        {
            return View(await feeRepository.GetAllAsync());
        }

        // GET: Fee/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var fee = await feeRepository.GetAsync(id.Value);
            if (fee == null)
            {
                return NotFound();
            }

            return View(fee);
        }
    }
}
