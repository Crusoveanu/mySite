using Library.Data.Models;
using LibraryData.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryData
{
    public interface ICheckout
    {
        IEnumerable<Checkoutt> GetAll();
        Checkoutt Get(int id);
        void Add(Checkoutt newCheckout);
        IEnumerable<CheckoutHistory> GetCheckoutHistory(int id);
        void PlaceHold(int assetId, int libraryCardId);
        void CheckoutItem(int assetId, int libraryCardId);
        void CheckInItem(int assetId);
        Checkoutt GetLatestCheckout(int assetId);
        int GetNumberOfCopies(int assetId);
        bool IsCheckedOut(int assetId);

        string GetCurrentHoldPatron(int assetId);
        string GetCurrentHoldPlaced(int assetId);
        string GetCurrentPatron(int assetId);
        IEnumerable<Hold> GetCurrentHolds(int id);

        void MarkLost(int id);
        void MarkFound(int id);
    }
}
