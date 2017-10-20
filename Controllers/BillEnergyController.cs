using energy_bill.Models;
using Microsoft.AspNetCore.Mvc;

namespace energy_bill.Controllers
{
    public class BillEnergyController : Controller
    {
         private IBillEnergyRepository _repository;    

        public BillEnergyController(IBillEnergyRepository repository)
        {
            _repository = repository;
        }

        public IActionResult Index()
        {
            var bills = _repository.GetAll();
            ViewBag.theBillMax = _repository.GetTheBillMax();
            ViewBag.theBillMin = _repository.GetTheBillMin();
            return View(bills);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(BillEnergy bill)
        {
            _repository.Save(bill);
            return RedirectToAction("Index");
        }

        public IActionResult Delete(int id)
        {
            _repository.Delete(id);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            return View(_repository.GetById(id));
        }

        [HttpPost]
        public IActionResult Edit(BillEnergy bill)
        {
            _repository.Update(bill);
            return RedirectToAction("Index");
        }
    }
}