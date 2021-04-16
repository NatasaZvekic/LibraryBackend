using Library.RepositoryContract.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Library.RepositoryContract.Interfaces
{
    public interface IDelivererRepository
    {
        List<Deliverer> GetAllDeliverers();
        Deliverer GetDelivererByID(Guid delivererID);
        Guid AddNewDeliverer(Deliverer deliverer);
        void UpdateDeliverer(Deliverer deliverer, Guid delivererID);
        bool DeleteDeliverer(Guid delivererID);
    }
}
