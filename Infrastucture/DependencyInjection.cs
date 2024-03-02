using Web.Domain.Repositories;
using Web.Domain;

namespace Web.Infastructure;
public static class DependencyInjection
{
    public static void AddInfrastructureServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationContext>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IArticleRepository, ArticleRepository>();
        services.AddScoped<IUnitOfWork>(sp => sp.GetService<ApplicationContext>());

    }
}