using HistoricoMedico.Application.Commands.CriarConsulta;
using HistoricoMedico.Application.Services.Implementations;
using HistoricoMedico.Application.Services.Interfaces;
using HistoricoMedico.Infrastructure.Persistence;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HistoricoMedico.API
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

            services.AddDbContext<HistoricoMedicoDbContext>(
                options => options.UseSqlServer(Configuration.GetConnectionString("HistoricoMedicoCs")));

            //services.AddSingleton<HistoricoMedicoDbContext>();

            services.AddScoped<IMedicoService, MedicoService>();
            services.AddScoped<IConsultaService, ConsultaService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            services.AddScoped<IDependenteService, DependenteService>();
            

            services.AddControllers();

            services.AddMediatR(typeof(CriarConsultaCommand));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HistoricoMedico.API", Version = "v1" });
            });

          
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HistoricoMedico.API v1"));
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
