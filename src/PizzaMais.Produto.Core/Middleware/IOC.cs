using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaMais.Produto.Communs.Interfaces;
using System.Data.SqlClient;

namespace PizzaMais.Produto.Core.Middleware
{
    public static class IOC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(_ => new SqlConnection(configuration.GetConnectionString("PizzaMais")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            return services;
        }
    }
}
