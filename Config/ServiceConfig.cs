using Api_Antivirus.Data;
using Api_Antivirus.Interface;
using Api_Antivirus.Services;
using Microsoft.EntityFrameworkCore;

namespace Api_Antivirus.Config
{
    public static class ServiceConfig
    {
        public static void ConfigureServices(this IServiceCollection services, IConfiguration configuration)
        {
            // Inyección de dependencias
            services.AddScoped<IBootcamp, BootcampService>();
            services.AddScoped<IBootcampTopic, BootcampTopicService>();
            services.AddScoped<ICategories, CategoriesService>();
            services.AddScoped<IInstitutions, InstitutionsService>();
            services.AddScoped<IOpportunities, OpportunitiesService>();
            services.AddScoped<ITopic, TopicService>();
            services.AddScoped<IUserOpportunities, UserOpportunitiesService>();
            services.AddScoped<IUsers, UsersService>();
            services.AddScoped<AuthService>();

            
            // Configuración de la base de datos
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
        }
    }
}