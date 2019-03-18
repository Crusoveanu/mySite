using Library.Data.Models;
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

        public IActionResult Detail(int id)
        {
            var patron = _patron.Get(id);

            var model = new PatronDetailModel
            {
                Id = patron.Id,
                LastName = patron.LasttName,
                FirstName = patron.FirstName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLIbraryBranch.Name,
                MemberSince = patron.LIbraryCard.Created,
                OverdueFees = patron.LIbraryCard.Fees,
                LibraryCardId = patron.LIbraryCard.Id,
                Telephone = patron.TelephoneNumber,
                AssetsCheckedOut = _patron.GetCheckouts(id).ToList() ?? new List<Checkoutt>(),
                CheckoutHistory = _patron.GetCheckoutHistory(id),
                Holds = _patron.GetHolds(id),
            };

            return View(model);
        }
    }
}
