using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace mySite.ModelsView.Branch
{
    public class BranchDetailModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public string Name { get; set; }
        public string OpenTime { get; set; }
        public string Telephone { get; set; }
        public bool IsOpen { get; set; }
        public string Description { get; set; }
        public int NumberOfPatrons { get; set; }
        public int NumberOfAssets { get; set; }
        public decimal TotalAssetsValue { get; set; }
        public string ImageUrl { get; set; }
        public IEnumerable<string> Hours { get; set; }
    }
}
