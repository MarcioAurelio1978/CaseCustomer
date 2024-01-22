using CaseCustomer.Application.Interfaces;
using CaseCustomer.Application.Mappings;
using CaseCustomer.Application.Services;
using CaseCustomer.Domain.Interfaces;
using CaseCustomer.Infrastructure.Context;
using CaseCustomer.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CaseCustomer.CrossCutting.Ioc
{
    public static class DependencyInjectionAPI
    {
        public static IServiceCollection AddInfrastructureAPI(this IServiceCollection services,
        IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
               options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IDocumentoRepository, DocumentoRepository>();
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClienteService, ClienteService>();
            services.AddScoped<IDocumentoService, DocumentoService>();         

            services.AddAutoMapper(typeof(DomainToDTOMappingProfile));            

            return services;
        }
    }
}
