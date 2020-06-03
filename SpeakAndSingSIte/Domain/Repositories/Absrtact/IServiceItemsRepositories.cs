using SiteSpeakAndSing.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Repositories.Absrtact
{
    public interface IServiceItemsRepositories
    {
        IQueryable<ServiceItem> GetServiceItems();
        ServiceItem GetServiceItemsById(Guid id);
        void SaveServiceItems(ServiceItem entity);
        void DeliteServiceItems(Guid id);
    }
}