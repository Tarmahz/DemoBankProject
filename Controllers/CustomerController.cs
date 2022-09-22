using DemoBankProject.Data;
using DemoBankProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoBankProject.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CustomerController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        { 
                IEnumerable<Customer> objCustomerList = _db.Customers;
                return View(objCustomerList);
         
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Customer obj)
        {
            if (!ModelState.IsValid)
            {
                _db.Customers.Add(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer Created Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }

        public IActionResult Edit(int? CustomerId)
        {
            if (CustomerId == null || CustomerId == 0)
            {
                return NotFound();
            }
            var CustomersFromDb = _db.Customers.Find(CustomerId);


            if (CustomersFromDb == null)
            {
                return NotFound();
            }
            return View(CustomersFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Customer obj)
        {
            if (ModelState.IsValid)
            {
                _db.Customers.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        public IActionResult Delete(int? CustomerId)
        {
            if (CustomerId == null || CustomerId == 0)
            {
                return NotFound();
            }
            var CustomersFromDb = _db.Customers.Find(CustomerId);


            if (CustomersFromDb == null)
            {
                return NotFound();
            }
            return View(CustomersFromDb);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeletePost(int? CustomerId)
        {
            var obj = _db.Customers.Find(CustomerId);
            if (obj == null)
            {
                return NotFound();
            }

            _db.Customers.Remove(obj);
            _db.SaveChanges();
            TempData["success"] = "Customer Deleted Successfully";
            return RedirectToAction("Index");



        }
    }
}
