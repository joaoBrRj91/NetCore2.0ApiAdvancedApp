using JohnStore.Domain.StoreContext.Repositories;
using JohnStore.Domain.StoreContext.Services;
using JohnStore.Infra.StoreContext.DataContext;
using JohnStore.Infra.StoreContext.Repositories;
using JohnStore.Infra.StoreContext.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace johnstore.api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            #region Midllewares
            services.AddMvc();
            #endregion

            #region DI Midllewares
            services.AddScoped<JohnStoreDataContext>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IEmailService, EmailService>();
            #endregion
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();


            app.UseMvc();

        }
    }
}
