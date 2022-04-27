using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OrdersManagement.Data;
using OrderManagement.Model;
using OrdersManagement.Model;
using OrdersManagement.Repository.Interface;
using OrdersManagement.Repository.Implementation;

namespace OrdersManagement
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<IOrderManagement, OrderRepository>();
            services.AddDbContext<OrdersManagementContext>(optionsAction: option => option.UseInMemoryDatabase(Configuration.GetConnectionString("Db")));
            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "OrdersManagement", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OrdersManagement v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            var scope = app.ApplicationServices.CreateScope();
            var context = scope.ServiceProvider.GetService<OrdersManagementContext>();
            SeedData(context);
        }

        private void SeedData(OrdersManagementContext context)
        {
            List<Product> product = new List<Product>()
                {
                    new Product()
                    {
                        ProductId = Guid.Parse("8a5fde85-5326-40a9-9d50-ceed187109d6"),
                        ProductName = "Pepperoni Pizza",
                        CostPrice = 20.50m,
                        Description = "Sweet and enjoyable",
                        QuantityInStock = 2,
                        SellingPrice = 30.00m
                    },
                    new Product()
                    {
                        ProductId = Guid.Parse("7f95897a-28ef-4f8a-ae93-3ca8ab5cb720"),
                        ProductName = "Windsor Pizza",
                        CostPrice = 20.50m,
                        Description = "Just nice",
                        QuantityInStock = 2,
                        SellingPrice = 30.00m
                    }
                };

            var Customers = new List<Customer> {
                   new Customer() { CustomerId = Guid.Parse("fab4fac1-c546-41de-aebc-a14da6895711"), FirstName = "Paul", LastName = "Luke", CityAddress = "2144 Scotchmere Dr, Sarnia, Ontario.", PhoneNumber = "250-992-9441" },
                   new Customer() { CustomerId = Guid.Parse("c7b013f0-5201-4317-abd8-c211f91b7330"), FirstName = "Sandra", LastName = "Sands", CityAddress = "2058 Holdom Avenue, Surrey, British Columbia.", PhoneNumber = "780-625-3051" }
                   };
            context.AddRange(product);
            context.AddRange(Customers);
            context.SaveChanges();
        }
    }
}
