using Library.ServiceContract.DTOs.CreateDTO;
using Library.ServiceContract.DTOs.ReadDTO;
using Library.ServiceContract.DTOs.UpdateDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.ServiceContract.Interfaces
{
    public interface IDelivererService
    {
        List<DelivererReadDTO> GetAllDeliverers();
        DelivererReadDTO GetDelivererByID(Guid delivererID);
        Guid AddNewDeliverer(DelivererCreateDTO deliverer);
        void UpdateDeliverer(DelivererUpdateDTO deliverer, Guid delivererID);
        bool DeleteDelivrer(Guid delivererID);
    }
}
