using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;
using poc_graphql.api.Models1;
using poc_graphql.infrasctructure.data.repositories.cliente.querys;
using poc_graphql.infrasctructure.data.repositories.usuario.mutation;
using System.Data;

namespace poc_graphql.infrasctructure.ioc
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfraestructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PermisosContext>(options => options.UseNpgsql(configuration.GetConnectionString("cn")));
            services.AddTransient<IDbConnection>(db => new NpgsqlConnection(configuration.GetConnectionString("cn")));
            services.AddScoped<UsuarioQuery>();
            services.AddGraphQLServer()
                .RegisterDbContextFactory<PermisosContext>()
                .AddQueryType<UsuarioQuery>()
                .AddMutationType<UsuarioMutation>()
                .AddProjections()
                .AddFiltering()
                .AddSorting();

            return services;

        }
    }
}
