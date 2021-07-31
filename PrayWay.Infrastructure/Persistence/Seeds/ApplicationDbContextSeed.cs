using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using PrayWay.Domain.Entities;
using PrayWay.Infrastructure.Persistence.DbContexts;

namespace PrayWay.Infrastructure.Persistence.Seeds
{
    public static class ApplicationDbContextSeed
    {
        public static async Task SetDefaultDataAsync(ApplicationDbContext dbContext)
        {
            try
            {
                await dbContext.Database.MigrateAsync();
                if (dbContext.Places.Any()) return;

                var places = new List<Place>
                {
                    new Place
                    {
                        Address = "Гагарина 44",
                        Description = "Кумыкская мечать",
                        Latitude = 42.95202515734384,
                        Longitude = 47.524967193603516,
                        PublishDate = DateTime.Today.AddDays(-5),
                        Title = "Мечеть"
                    },
                    new Place
                    {
                        Address = "ул. Дахадаева, 136",
                        Description =
                            "Центральная Джума-мечеть Махачкалы или «Юсуф Бей Джами» — главная джума-мечеть Махачкалы. Строительство мечети было начато в 1991 году благодаря финансированию одной из богатых турецких семей.",
                        Latitude = 42.95202515734384,
                        Longitude = 47.524967193603516,
                        PublishDate = DateTime.Today,
                        Title = "Центральная Джума-мечеть"
                    }
                };

                foreach (var place in places)
                {
                    await dbContext.Places.AddAsync(place);
                }

                await dbContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        } 
    }
}