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
    public class DelivererRepository : IDelivererRepository
    {
        private readonly ContextDB context;
        private readonly IMapper mapper;

        public DelivererRepository(ContextDB context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public List<Deliverer> GetAllDeliverers()
        {
            return mapper.Map<List<Deliverer>>(context.DeliveryCompany.ToList());
        }

        public Deliverer GetDelivererByID(Guid delivererID)
        {
            var deliverer = context.DeliveryCompany.FirstOrDefault(e => e.DeliveryID == delivererID);
            return mapper.Map<Deliverer>(deliverer);
        }
        public Guid AddNewDeliverer(Deliverer deliverer)
        {
            var delivererDB = mapper.Map<DelivererDB>(deliverer);
            Guid delivererID = Guid.NewGuid();
            delivererDB.DeliveryID = delivererID;

            context.DeliveryCompany.Add(delivererDB);
            context.SaveChanges();

            return delivererID;
        }
        public void UpdateDeliverer(Deliverer deliverer, Guid delivererID)
        {
            var oldDeliverer = context.DeliveryCompany.FirstOrDefault(e => e.DeliveryID == delivererID);

            if (oldDeliverer == null)
            {
                throw new Exception("not found");
            }

            oldDeliverer.DeliveryAddress = deliverer.DeliveryAddress;
            oldDeliverer.DeliveryCompanyName = deliverer.DeliveryCompanyName;
            oldDeliverer.DeliveryContant = deliverer.DeliveryContant;

            context.SaveChanges();
        }

        public bool DeleteDeliverer(Guid delivererID)
        {
            var deliverer = context.DeliveryCompany.FirstOrDefault(e => e.DeliveryID == delivererID);
            if (deliverer == null)
            {
                return false;
            }

            context.DeliveryCompany.Remove(deliverer);
            context.SaveChanges();
            return true;
        }
    }
}
