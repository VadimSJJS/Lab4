using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    public class OutgoingController : Controller
    {
        private PharmacyContext db;

        public OutgoingController(PharmacyContext context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var pharmacyTypes = db.Outgoings
                .Include(ia => ia.Medicine)
                .ToList();
            return View(pharmacyTypes);
        }
    }
}
