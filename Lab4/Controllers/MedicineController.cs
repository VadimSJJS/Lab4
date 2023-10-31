using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab4.Controllers
{
    public class MedicineController : Controller
    {
        private PharmacyContext db;

        public MedicineController(PharmacyContext context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var pharmacyTypes = db.Medicines
                .Include(ia => ia.Producer)
                .ToList();
            return View(pharmacyTypes);
        }
    }
}
