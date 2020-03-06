using System;
using System.IO;
using System.Reflection;
using System.Text;
using GerenciamentoEvento.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;

namespace GerenciamentoEvento {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            services.AddDbContext<ApplicationDbContext> (options =>
                options.UseMySql (
                    Configuration.GetConnectionString ("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser> (options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext> ();
            services.AddControllersWithViews ();

            //Autenticação JWT
            string Key = "ProjetoApiEvento.com";
            var KeySimetrica = new SymmetricSecurityKey (Encoding.UTF8.GetBytes (Key));

            services.AddAuthentication (JwtBearerDefaults.AuthenticationScheme).AddJwtBearer (options => {
                //Como ler o Token JWT
                options.TokenValidationParameters = new TokenValidationParameters {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateIssuerSigningKey = true,
                //Dados de validação JWT
                ValidIssuer = "Eventos.com",
                ValidAudience = "Admin",
                IssuerSigningKey = KeySimetrica
                };
            });

            services.AddRazorPages ();

            //Swagger
            services.AddSwaggerGen (config => {
                config.SwaggerDoc ("v1", new Microsoft.OpenApi.Models.OpenApiInfo { Title = "API Eventos.com", Version = "v1" });
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine (AppContext.BaseDirectory, xmlFile);
                config.IncludeXmlComments (xmlPath);
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IWebHostEnvironment env) {
            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
                app.UseDatabaseErrorPage ();
            } else {
                app.UseExceptionHandler ("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts ();
            }
            app.UseHttpsRedirection ();
            app.UseStaticFiles ();
            app.UseRouting ();
            app.UseAuthentication ();
            app.UseAuthorization ();
            app.UseEndpoints (endpoints => {
                endpoints.MapControllerRoute (
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages ();
            });

            app.UseSwagger (config => {
                config.RouteTemplate = "eventos.com/{documentName}/swagger.json";
            }); //Gerar um arquivo JSON - Swagger.json
            app.UseSwaggerUI (config => { //View HTML do Swagger
                config.SwaggerEndpoint ("/eventos.com/v1/swagger.json", "v1 docs");
                
            });
        }
    }
}