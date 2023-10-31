using Microsoft.AspNetCore.Mvc;

namespace Lab4.Controllers
{
    public class ProducerController : Controller
    {
        private PharmacyContext db;

        public ProducerController(PharmacyContext context)
        {
            db = context;
        }

        [ResponseCache(CacheProfileName = "ModelCache")]
        public IActionResult ShowTable()
        {
            var pharmacyTypes = db.Producers.ToList();
            return View(pharmacyTypes);
        }
    }
}
