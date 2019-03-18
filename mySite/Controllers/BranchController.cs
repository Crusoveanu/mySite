using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LibraryData;
using Microsoft.AspNetCore.Mvc;
using mySite.ModelsView.Branch;

namespace mySite.Controllers
{
    public class BranchController : Controller
    {
        private ILibraryBranch _branch;
        public BranchController(ILibraryBranch branch)
        {
            _branch = branch;
        }
        public IActionResult Index()
        {
            var branches = _branch.GetAll().Select(branch => new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                IsOpen = _branch.IsBranchOpen(branch.Id),
                NumberOfAssets = _branch.GetAssets(branch.Id).Count(),
                NumberOfPatrons = _branch.GetPatrons(branch.Id).Count(),
            });
            return View();
        }
    }
}
