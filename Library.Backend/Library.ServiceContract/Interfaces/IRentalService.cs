using System;
using System.Collections.Generic;
using System.Text;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;

namespace Library.ServiceContract.Interfaces
{
    public interface IRentalService
    {

        List<RentalReadDTO> GetAllRentals();
        RentalReadDTO GetRentalByID(Guid rentalID);
        Guid AddNewRental(RentalCreateDTO rental);
        void UpdateRental(RentalUpdateDTO rental, Guid rentalID);
        bool DeleteRental(Guid rentalID);
    }
}
