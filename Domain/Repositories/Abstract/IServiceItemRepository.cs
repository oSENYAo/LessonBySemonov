using MyCompany.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyCompany.Domain.Repositories.Abstract
{
    public interface IServiceItemRepository
    {
        IQueryable<ServiceItem> GetServiceItem();
        ServiceItem GetServiceItemById(Guid Id);
        void SaveServiceItem(ServiceItem entity);
        void DeleteServiceItem(Guid Id);
    }
}
