using E_commerce.Data;
using E_commerce.Models;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller

    {
        public  CategoryController(ApplicationDbContext context, IToastNotification notification)
        {
            _context = context;
            _toastNotification = notification;
        }
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        

        public IActionResult CategoryList()
        {
            var cat = _context.categories.ToList();
            return View(cat);
        }
        [HttpGet]
        public IActionResult CreateCategory()

        {
            
            return View();
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateCategory(Category category )
        {
             //  if (ModelState.IsValid)
          // {
                _context.categories.Add(category);
                _context.SaveChanges();
            
            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
            return RedirectToAction(nameof(CategoryList));

          // }
          // return View(category);
        }
       
        [HttpGet]
        public IActionResult EditCategory(int Id)

        {
            var cat=_context.categories.Find(Id);

            return View(cat);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult EditCategory(int Id,Category category)
        {
            //  if (ModelState.IsValid)
            // {
            _context.categories.Update(category);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
            return RedirectToAction(nameof(CategoryList));

            // }
            // return View(category);
        }
        public IActionResult DeleteCategory(int Id)
        {
            var category = _context.categories.Find(Id);
            _context.categories.Remove(category);
            _context.SaveChanges();

            _toastNotification.AddSuccessToastMessage("Woo hoo - it works!");
            return RedirectToAction(nameof(CategoryList));
        }
    }
}
