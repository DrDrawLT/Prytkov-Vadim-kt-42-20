using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.TeachersInterfaces;
using Prytkov_Vadim_kt_42_20_Lab_3.Interfaces.LoadsInterfaces;

namespace Prytkov_Vadim_kt_42_20_Lab_3.ServiceExtensions
{
    public static class ServiceExtensions
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<ILoadService, LoadService>();

            return services;
        }
    }
}
