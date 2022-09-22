using DemoBankProject.Data;
using DemoBankProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DemoBankProject.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext _db;
        public AccountController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        { 
                IEnumerable<Account> objAccountList = _db.Accounts;
                return View(objAccountList);
         
        }

        public IActionResult Create()
        {

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Account Accountobj)
        {
            if (ModelState.IsValid)
            {
                _db.Accounts.Add(Accountobj);
                _db.SaveChanges();
                TempData["success"] = "Customer Created Successfully";
                return RedirectToAction("Index");
            }
            return View(Accountobj);

        }

        public IActionResult Edit(int? AccountId)
        {
            if (AccountId == null || AccountId == 0)
            {
                return NotFound();
            }
            var AccountsFromDb = _db.Accounts.Find(AccountId);


            if (AccountsFromDb == null)
            {
                return NotFound();
            }
            return View(AccountsFromDb);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Account obj)
        {
            if (ModelState.IsValid)
            {
                _db.Accounts.Update(obj);
                _db.SaveChanges();
                TempData["success"] = "Customer Edited Successfully";
                return RedirectToAction("Index");
            }
            return View(obj);

        }
        //public IActionResult Delete(string? AccountNumber)
        //{
        //    if (AccountNumber == null)
        //    {
        //        return NotFound();
        //    }
        //    var AccountsFromDb = _db.Accounts.Find(AccountNumber);


        //    if (AccountsFromDb == null)
        //    {
        //        return NotFound();
        //    }
        //    return View(AccountsFromDb);
        //}
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public IActionResult DeletePost(string? AccountNumber)
        //{
        //    var Accountobj = _db.Accounts.Find(AccountNumber);
        //    if (Accountobj == null)
        //    {
        //        return NotFound();
        //    }

        //    _db.Accounts.Remove(Accountobj);
        //    _db.SaveChanges();
        //    TempData["success"] = "Customer Deleted Successfully";
        //    return RedirectToAction("Index");



        //}
    }
}
