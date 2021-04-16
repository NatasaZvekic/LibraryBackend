using AutoMapper;
using Library.RepositoryContract.Entities;
using Library.RepositoryContract.Interfaces;
using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using Library.ServiceContract.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.Services.Services
{
    public class DelivererService : IDelivererService
    {
        private readonly IDelivererRepository deliveryRepository;
        private readonly IMapper mapper;

        public DelivererService(IDelivererRepository deliveryRepository, IMapper mapper)
        {
            this.mapper = mapper;
            this.deliveryRepository = deliveryRepository;
        }
        public List<DelivererReadDTO> GetAllDeliverers()
        {
            return mapper.Map<List<DelivererReadDTO>>(deliveryRepository.GetAllDeliverers());
        }

        public DelivererReadDTO GetDelivererByID(Guid delivererID)
        {
            return mapper.Map<DelivererReadDTO>(deliveryRepository.GetDelivererByID(delivererID));
        }
        public Guid AddNewDeliverer(DelivererCreateDTO deliverer)
        {
            return deliveryRepository.AddNewDeliverer(mapper.Map<Deliverer>(deliverer));
        }

        public void UpdateDeliverer(DelivererUpdateDTO deliverer, Guid delivererID)
        {
            deliveryRepository.UpdateDeliverer(mapper.Map<Deliverer>(deliverer), delivererID);
        }
        public bool DeleteDelivrer(Guid delivererID)
        {
            return deliveryRepository.DeleteDeliverer(delivererID);
        }
    }
}
