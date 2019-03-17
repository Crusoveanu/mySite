using LibraryData;
using Microsoft.AspNetCore.Mvc;
using mySite.ModelsView.Patron;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.Controllers
{
    public class PatronController : Controller
    {
        private IPatron _patron;
        public PatronController(IPatron patron)
        {
            _patron = patron;
        }

        public IActionResult Index()
        {
            var allPatron = _patron.GetAll();

            var patronModels = allPatron.Select(p => new PatronDetailModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LasttName,
                LibraryCardId = p.LIbraryCard.Id,
                OverdueFees = p.LIbraryCard.Fees,
                HomeLibraryBranch = p.HomeLIbraryBranch.Name
            }).ToList();

            var model = new PatronIndexModel()
            {
                Patrons = patronModels
            };

            return View(model);
        }

    }
}
