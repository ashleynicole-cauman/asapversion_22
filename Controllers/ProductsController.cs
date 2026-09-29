using Microsoft.AspNetCore.Mvc;
using asapversion_22.Data;
using asapversion_22.Models;

namespace asapversion_22.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductsController(ApplicationDbContext db)
        {
            _db = db;
        }

        // Shows the list of products
        public IActionResult Index()
        {
            var products = _db.Products.ToList();
            return View(products);
        }

        // Shows the empty add form
        public IActionResult Create()
        {
            return View();
        }

        // Saves a new product
        [HttpPost]
        public IActionResult Create(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}