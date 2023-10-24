using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SizesController : Controller
    {

        public SizesController(ApplicationDbContext context, IToastNotification notification)
        {
            _context = context;
            _toastNotification = notification;
        }
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        public IActionResult SizesList()

        {
            var sizes = _context.sizes.ToList();
            return View(sizes);
        }
        [HttpGet]
        public IActionResult CreateSize()

        {

            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateSize(Size size)
        {
            //  if (ModelState.IsValid)
            // {
            _context.sizes.Add(size);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
            return RedirectToAction(nameof(SizesList));

            // }
            // return View(category);
        }

        [HttpGet]
        public IActionResult EditSize(int Id)

        {
            var sizes = _context.sizes.Find(Id);

            return View(sizes);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditSize(int Id, Size size)
        {
            //  if (ModelState.IsValid)
            // {
            _context.sizes.Update(size);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
            return RedirectToAction(nameof(SizesList));

            // }
            // return View(category);
        }
        public IActionResult DeleteSize(int Id)
        {
            var size = _context.sizes.Find(Id);
            if (size != null)
            {
                _context.sizes.Remove(size);
                _context.SaveChanges();

                _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
                return RedirectToAction(nameof(SizesList));
            }
            _toastNotification.AddErrorToastMessage("error");
            return RedirectToAction(nameof(SizesList));
        }
    }
}
