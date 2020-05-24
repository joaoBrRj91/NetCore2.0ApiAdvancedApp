using Elmah.Io.AspNetCore;
using JohnStore.Domain.StoreContext.Handlers;
using JohnStore.Domain.StoreContext.Repositories;
using JohnStore.Domain.StoreContext.Services;
using JohnStore.Infra.StoreContext.DataContext;
using JohnStore.Infra.StoreContext.Repositories;
using JohnStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using System.IO;
using johnstore.shared.Database;

namespace johnstore.api
{
    public class Startup
    {

        public IConfiguration Configuration { get; set; }

        public void ConfigureServices(IServiceCollection services)
        {
            #region Configuration Settings
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
            DbSettings.ConnectionString = Configuration["ConnectionString"];
            #endregion

            #region Midllewares
            services.AddMvc().SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_2_1);
            services.AddResponseCompression();
            services.AddApplicationInsightsTelemetry(Configuration);

            services.AddSwaggerGen(s => {
                s.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "My API", Version = "v1" });
            });

            //Elmah.io server web apra logs (Criar conta e substituir os valores de ApiKey e LogId pelos informados na criação da conta)
            services.AddElmahIo(e =>
            {
                //Key de autenticação do Elmah.IO
                e.ApiKey = "API_KEY";
                //GUID da aplicação(API) que o log será enviado
                e.LogId = new System.Guid("LOG ID");
            });

            #endregion

            #region DI Midllewares
            //services.AddSingleton(Configuration);
            services.AddScoped<JohnStoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            services.AddTransient<CustomerHandler>();
            #endregion
           
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseMvc();
            app.UseResponseCompression();
            app.UseSwagger();
            app.UseSwaggerUI(s => s.SwaggerEndpoint("/swagger/v1/swagger.json", "Balta Store - V1"));
            app.UseElmahIo();
        }
    }
}
