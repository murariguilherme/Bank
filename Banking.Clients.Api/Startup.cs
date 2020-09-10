using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Banking.Clients.Infra.Data;
using Banking.Clients.Api.Extensions;
using Banking.Clients.Application.Interfaces;
using Banking.Core.Messages.Notifications;
using MediatR;
using Banking.Core.Communication;
using Microsoft.AspNetCore.Http;
using Banking.Clients.Api.Configuration;
using Banking.Clients.Api.Data;
using Banking.Clients.Domain;
using Banking.Clients.Infra;
using Banking.Clients.Infra.Repository;
using AutoMapper;
using Banking.Clients.Application.Commands;

namespace Banking.Api
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
            services.AddControllers();
            services.AddMediatR(typeof(Startup));
            services.AddIdentityConfig(Configuration);
            services.AddScoped<IMediatorHandler, MediatorHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IRequestHandler<UpdateClientCommand, bool>, ClientCommandHandler>();
            services.AddScoped<ApplicationDbContext>();
            services.AddScoped<MyIdentityDbContext>();
            services.AddScoped<IUser, AspNetUser>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IRepository<Client>, ClientRepository>();
            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddAutoMapper(typeof(Startup));

            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
