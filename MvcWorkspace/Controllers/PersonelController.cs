using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MvcWorkspace.Data;
using MvcWorkspace.Models;
using MvcWorkspace.Models.ViewModels;

namespace MvcWorkspace.Controllers
{
    public class PersonelController : Controller
    {
        
        private readonly AppDbContext _db;
        //dependency injection
        public PersonelController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            PersonelVM personelVM=new PersonelVM();

            IEnumerable<Personel> personeller =_db.Personeller.Include(p=>p.Bolum);
            //List<string> kayitlar = new List<string>();

            //foreach (var p in personeller)
            //{
            //    kayitlar.Add($"{p.Id}_{p.Name}");
            //}
            personelVM.PersonelSayi = personeller.Count();
            ViewBag.bagsayi= personeller.Count();
            personelVM.PersonelListe= personeller;
            return View(personelVM);
            //return View(personeller);
            //return View(kayitlar);
        }
    }
}
