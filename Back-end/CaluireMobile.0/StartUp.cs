using CaluireMobile._0.Models.Datas;
using CaluireMobile._0.Models.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;


using System;

namespace CaluireMobile._0
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
{
    services.AddDbContext<CaluireMobileContext>(options => 
        options.UseMySql(Configuration.GetConnectionString("maConnection"), 
        new MySqlServerVersion(new Version(8, 0, 31))));  // Remplacez 8, 0, 21 par la version de votre serveur MySQL            services.AddTransient<ClientsService>();
            
            services.AddTransient<ClientsService>();
            services.AddTransient<EmployesService>();
            services.AddTransient<OperationsServices>();
            services.AddTransient<RendezVousService>();
            services.AddTransient<PriseEnChargesService>();
            services.AddTransient<SocketioServices>();
            services.AddTransient<ProduitsService>();
            services.AddTransient<TraductionsService>();
            services.AddTransient<TraitersService>();
            services.AddTransient<TypesproduitsService>();
            services.AddTransient<TransactionspaimentService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "CaluireMobile", Version = "v1" });
            });
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "CaluireMobile v1"));
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}