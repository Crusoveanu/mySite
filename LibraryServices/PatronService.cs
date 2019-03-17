using Library.Data.Models;
using LibraryData;
using LibraryData.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryServices
{
    public class PatronService : IPatron
    {
        private LIbraryContext _context;

        public PatronService(LIbraryContext context)
        {
            _context = context;
        }

        public void Add(Patron newPatron)
        {
            _context.Add(newPatron);
            _context.SaveChanges();
        }

        public Patron Get(int id)
        {
            return _context.Patrons
                .Include(patron => patron.LIbraryCard)
                .Include(patron => patron.HomeLIbraryBranch)
                .FirstOrDefault(patron => patron.Id == id);
        }

        public IEnumerable<Patron> GetAll()
        {
            return _context.Patrons
                .Include(patron => patron.LIbraryCard)
                .Include(patron => patron.HomeLIbraryBranch);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistory(int patronId)
        {
            var cardId = _context.Patrons
                .Include(patron => patron.LIbraryCard)
                .FirstOrDefault(patron => patron.Id == patronId)
                .LIbraryCard.Id;

            return _context.CheckoutHistories
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId)
                .OrderByDescending(co => co.CheckedOut);
        }

        public IEnumerable<Checkoutt> GetCheckouts(int patronId)
        {
            var cardId = _context.Patrons
                .Include(patron => patron.LIbraryCard)
                .FirstOrDefault(patron => patron.Id == patronId)
                .LIbraryCard.Id;

            return _context.Checkouts
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId);
        }

        public IEnumerable<Hold> GetHolds(int patronId)
        {
            var cardId = _context.Patrons
                .Include(patron => patron.LIbraryCard)
                .FirstOrDefault(patron => patron.Id == patronId)
                .LIbraryCard.Id;

            return _context.Holds
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .Where(co => co.LibraryCard.Id == cardId)
                .OrderByDescending(co => co.HoldPlaced);
        }
    }
}
