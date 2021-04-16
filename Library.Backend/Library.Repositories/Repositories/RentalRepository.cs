using AutoMapper;
using Library.Repositories.Entities;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Library.Repositories.Repositories
{
    public class RentalRepository : IRentalRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public RentalRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }
        public List<Rental> GetAllRentals()
        {
            return mapper.Map<List<Rental>>(context.Rentals.ToList());
        }

        public Rental GetRentalByID(Guid rentalID)
        {
            var rental = context.Rentals.FirstOrDefault(e => e.RentalID == rentalID);
            return mapper.Map<Rental>(rental);
        }
        public Guid AddNewRental(Rental rental)
        {
            var newRental = mapper.Map<RentalDB>(rental);
            var guid = Guid.NewGuid();
            newRental.RentalID = guid;
            newRental.RentalDate = DateTime.Today;

            context.Rentals.Add(newRental);
            context.SaveChanges();

            return guid;
        }

        public void UpdateRental(Rental rental, Guid rentalID)
        {
            var oldRental = context.Rentals.FirstOrDefault(e => e.RentalID == rentalID);

            if (oldRental == null)
            {
                throw new Exception("not found");
            }

            oldRental.BookID = rental.BookID;
            oldRental.DeliveryID = rental.DeliveryID;
            oldRental.EmployeeID = rental.EmployeeID;
            oldRental.UserID = rental.UserID;
            oldRental.RentalDate = rental.RentalDate;


            context.SaveChanges();
        }
        public bool DeleteRental(Guid rentalID)
        {
            var rental = context.Rentals.FirstOrDefault(e => e.RentalID == rentalID);
            if (rental == null)
            {
                return false;
            }

            context.Rentals.Remove(rental);
            context.SaveChanges();
            return true;
        }

    }
}
