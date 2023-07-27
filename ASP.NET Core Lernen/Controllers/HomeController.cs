using ASP.NET_Core_Lernen.Data;
using ASP.NET_Core_Lernen.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace ASP.NET_Core_Lernen.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly TestDB _testDB;

        public HomeController(ILogger<HomeController> logger, TestDB testDB)
        {
            _logger = logger;
            this._testDB = testDB;
        }

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("/Home/AddPerson")]
        public IActionResult AddPerson()
        {
            return View();
        }

        [HttpPost]
        [Route("/Home/AddPerson")]
        public async Task<IActionResult> AddPerson(PersonViewModel personVM)
        {
            var person = new Person()
            {
                Forname = personVM.Forname,
                Lastname = personVM.Lastname,
                Birthday = personVM.Birthday,
            };
            
            await _testDB.Persons.AddAsync(person);
            await _testDB.SaveChangesAsync();
            
            return RedirectToAction("ListPersons");
        }

        [HttpGet]
        [Route("Home/ListPersons")]
        public async Task<IActionResult> ListPersons() 
        {
            var listPerson = await _testDB.Persons.ToListAsync();

            var listPersonVM = new List<ListPersoneViewModel>();

            Parallel.ForEach(listPerson, (person) =>
            {
                var personeVM = new ListPersoneViewModel()
                {
                    Id = person.Id,
                    Forname = person.Forname,
                    Lastname = person.Lastname,
                    Birthday = person.Birthday,
                };
                listPersonVM.Add(personeVM);
            });

            return View(listPersonVM);
        }

        [HttpGet]
        [Route("Home/DeletePerson/{id:int}")]
        public async Task<IActionResult> DeletePerson(uint id)
        {
            var person = await _testDB.Persons.SingleAsync(p => p.Id == id);
            _testDB.Persons.Remove(person);
            await _testDB.SaveChangesAsync();

            return RedirectToAction("ListPersons");
        }
    }
}