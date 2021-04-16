using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IRentalRepository
    {
        List<Rental> GetAllRentals();
        Rental GetRentalByID(Guid rentalID);
        Guid AddNewRental(Rental rental);
        void UpdateRental(Rental rental, Guid rentalID);
        bool DeleteRental(Guid rentalID);
    }
}
