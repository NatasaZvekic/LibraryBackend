using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;

namespace Library.Services.Services
{
    public class RentalService : IRentalService
    {

        private readonly IRentalRepository rentalsRepository;
        private readonly IMapper mapper;

        public RentalService(IRentalRepository rentalsRepository, IMapper mapper)
        {
            this.rentalsRepository = rentalsRepository;
            this.mapper = mapper;
        }

        public List<RentalReadDTO> GetAllRentals(Boolean completed)
        {
            return mapper.Map<List<RentalReadDTO>>(rentalsRepository.GetAllRentals( completed));
        }

        public List<RentalReadDTO> GetRentalByID(Guid rentalID)
        {
            return mapper.Map<List<RentalReadDTO>>(rentalsRepository.GetRentalByID(rentalID));
        }

        public Guid AddNewRental(RentalCreateDTO rental)
        {
            return rentalsRepository.AddNewRental(mapper.Map<Rental>(rental));
        }
        public void UpdateRental(RentalUpdateDTO rental, Guid rentalID)
        {
            rentalsRepository.UpdateRental(mapper.Map<Rental>(rental), rentalID);
        }
        public bool DeleteRental(Guid rentalID)
        {
            return rentalsRepository.DeleteRental(rentalID);
        }
    }
}
