using Aplicacion.UnitOfWork;
using Dominio.Interfaces;

namespace API.Extensions;

    public static class ApplicationServiceExtension
    {
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()//WithOrigins("https://domini.com")
                .AllowAnyMethod() //WithMethods("GET", "POST")
                .AllowAnyHeader()); //WithHeader(*accept*, "content-type")
            });

         public static void AddAplicacionServices(this IServiceCollection services)
        {
            //services.AddScoped<IPais, PaisRepository>();
            //services.AddScoped<IRegion, RegionRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
        } 
    }