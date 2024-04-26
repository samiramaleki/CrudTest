using Mc2.CrudTest.Application.Interfaces;
using Mc2.CrudTest.Persistence.EF;
using Mc2.CrudTest.Persistence.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using System;
using FluentValidation.AspNetCore;
using Mc2.CrudTest.Application.CQRS.Invoices.Create;
using Mc2.CrudTest.Application.CQRS.Invoices.Update;

namespace Mc2.CrudTest.Presentation.Server
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddControllersWithViews();
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IUnitOfWork, EntityFrameworkUnitOfWork>();
            services.AddScoped<IInvoiceRepository, InvoiceRepository>();
            services.AddScoped<IIndependentCreditNoteRepository, IndependentCreditNoteRepository>();
            services.AddScoped<IDependentCreditNoteRepository, DependentCreditNoteRepository>();

            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateInvoiceCommandValidator>());
            services.AddControllers().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<UpdateInvoiceCommandValidator>());
            services.AddDbContext<FinanceDbContext>(
                options => options.UseSqlServer(Configuration["ConnectionString"]));


            services.AddSwaggerGen(c =>
               {
                   c.SwaggerDoc("v1", new OpenApiInfo { Title = "Testapi", Version = "v1" });

               });


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseWebAssemblyDebugging();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Mc2.CrudTest v1"));

            app.UseHttpsRedirection();
            app.UseBlazorFrameworkFiles();
            app.UseStaticFiles();


            app.UseRouting();
            app.UseCors(x => x
            .AllowAnyMethod()
            .AllowAnyHeader()
            .SetIsOriginAllowed(origin => true)
            .AllowCredentials());
            
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapFallbackToFile("index.html");
            });
        }
    }
}
