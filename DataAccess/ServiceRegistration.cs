using DataAccess.Concrete.EntityFramework;
using DataAccess.Configurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public static class ServiceRegistration
    {
        public static void AddDataAccessServices(this IServiceCollection services)
        {
            string data = Configuration.ConnectionString;
            services.AddDbContext<TicketBookingContext>(options=>options.UseSqlServer(Configuration.ConnectionString));
        }
    }
}