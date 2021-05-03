using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using PizzaMais.Produto.Communs.Interfaces;
using PizzaMais.Produto.Communs.Interfaces.Service;
using PizzaMais.Produto.Core.Service;
using System.Data.SqlClient;

namespace PizzaMais.Produto.Core.Middleware
{
    public static class IOC
    {
        public static IServiceCollection Register(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(_ => new SqlConnection(configuration.GetConnectionString("PizzaMais")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped<IFornecedorService, FornecedorService>();

            return services;
        }
    }
}
