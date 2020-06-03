using Microsoft.EntityFrameworkCore;
using SiteSpeakAndSing.Domain.Entities;
using SiteSpeakAndSing.Domain.Repositories.Absrtact;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiteSpeakAndSing.Domain.Repositories.EntityFramework
{
    public class EFServiceItemsRepositories : IServiceItemsRepositories
    {
        private readonly AppDbContext context;
        public EFServiceItemsRepositories(AppDbContext context)
        {
            this.context = context;
        }

        public IQueryable<ServiceItem> GetServiceItems()
        {
            return context.ServiceItems;
        }

        public ServiceItem GetServiceItemsById(Guid id)
        {
            return context.ServiceItems.FirstOrDefault(x => x.Id == id);
        }

        public void SaveServiceItems(ServiceItem entity)
        {
            if (entity.Id == default)
                context.Entry(entity).State = EntityState.Added;
            else
                context.Entry(entity).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeliteServiceItems(Guid id)
        {
            context.ServiceItems.Remove(new ServiceItem() { Id = id});
            context.SaveChanges();
        }
    }
}
