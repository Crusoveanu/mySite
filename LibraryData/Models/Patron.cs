using System;

namespace LibraryData.Models
{
    public class Patron
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LasttName { get; set; }
        public string Address { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string TelephoneNumber { get; set; }
        public virtual LibraryCard LIbraryCard { get; set; }
        public virtual LibraryBranch HomeLIbraryBranch { get; set; }
    }
}
