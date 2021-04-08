using Microsoft.EntityFrameworkCore;
using MyCompany.Domain.Entities;
using MyCompany.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepository : IServiceItemRepository
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepository(AppDbContext context)
        {
            this.context = context;
        }
        public void DeleteServiceItem(Guid Id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = Id });
            context.SaveChanges();
        }

        public IQueryable<ServiceItem> GetServiceItem()
        {
            return context.ServiceItems;
        }

        public ServiceItem GetServiceItemById(Guid Id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == Id);
        }

        public void SaveServiceItem(ServiceItem entity)
        {
            if (entity.Id == default)
            {
                context.Entry(entity).State = EntityState.Added;
            }
            else
            {
                context.Entry(entity).State = EntityState.Modified;
            }
            context.SaveChanges();
        }
    }
}
