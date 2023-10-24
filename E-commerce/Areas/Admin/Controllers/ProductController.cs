using E_commerce.Data;
using E_commerce.Models;
using E_commerce.ProductViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NToastNotify;
using System.IO;
namespace E_commerce.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        public ProductController(ApplicationDbContext context, IToastNotification notification)
        {
            _context = context;
            _toastNotification = notification;
        }
        private readonly ApplicationDbContext _context;
        private readonly IToastNotification _toastNotification;
        public IActionResult ProductsList()
        {
            var products = _context.products.Include(p => p.Category)
                 .Include(p => p.productSizes).ThenInclude(p => p.Size)
                 .ToList();
            return View(products);
        }
        [HttpGet]
        public IActionResult CreateProduct()
        {
            var productvm = new ViewModel
            {
                productSizes = _context.sizes.ToList()
            };

            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View(productvm);
        }
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult CreateProduct(ViewModel model,IFormFile file)

        {

            if (ModelState.IsValid)
            {
                if (file != null)
                {
                    string ImageName = Guid.NewGuid().ToString() + "jpg";
                    string imageUrl=Path.Combine(Directory.GetCurrentDirectory(),@"wwwroot\ProductImage",ImageName);
                    using (var stream = System.IO.File.Create(imageUrl))
                    {
                        file.CopyTo(stream);
                    };
                    model.ProductImage = ImageName;
                }
                var product = new Product
                {
                    ProductImage = model.ProductImage,
                    ProdutName = model.ProdutName,
                    ProductDescription = model.ProductDescription,
                    Price = model.Price,
                    CategoryId = model.CategoryId,
                    productSizes = new List<ProductSize>()
                };
                if (model.SelectedtSizeId != null && model.SelectedtSizeId.Any())
                {
                    foreach (var sizeId in model.SelectedtSizeId)
                    {
                        var size = _context.sizes.Find(sizeId);
                        if (size != null)
                        {
                            var productsize = new ProductSize
                            {
                                Product = product,
                                Size = size
                            };
                            product.productSizes.Add(productsize);

                        }


                    }
                }
                _context.products.Add(product);
                _context.SaveChanges();

                _toastNotification.AddSuccessToastMessage("recorded with succes");
                return RedirectToAction(nameof(ProductSize));
            }
            model.productSizes = _context.sizes.ToList();
            ViewData["CategoryId"] = new SelectList(_context.categories, "CategoryId", "CategoryName");
            return View(model); 
        }
    }
}
