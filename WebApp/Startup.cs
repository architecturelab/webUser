namespace WebApp
{
    using Microsoft.AspNetCore.Authentication.Cookies;
    using Microsoft.AspNetCore.Builder;
    using Microsoft.AspNetCore.Hosting;
    using Microsoft.AspNetCore.Http;
    using Microsoft.Extensions.Configuration;
    using Microsoft.Extensions.DependencyInjection;
    using Microsoft.Extensions.Hosting;
    using System;
    using System.Threading.Tasks;
    using WebApp.Models.General;

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
            services.Configure<MySettings>(Configuration.GetSection(MySettings.SectionName));
            services.AddControllersWithViews();
            services.AddOptions();

            services.AddRazorPages();

            #region Inicio de sesión basado en cookie
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.Cookie.Name = "_authGestionActivos";
                options.Cookie.HttpOnly = true;
                options.LoginPath = new PathString("/Cuenta/Login");
                options.LogoutPath = new PathString("/Cuenta/logout");
                options.AccessDeniedPath = new PathString("/Cuenta/Login");
                options.ExpireTimeSpan = DateTime.Now.Subtract(DateTime.UtcNow).Add(TimeSpan.FromHours(24));
                options.SlidingExpiration = true;
            });

            services.AddControllers();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                //app.UseHsts();
            }

            // Seccion para verificar en que ambiente se encuentra el proyecto
            //app.Run(async (context) =>
            //{
            //    await context.Response.WriteAsync("Entorno " + env.EnvironmentName);
            //});

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Cuenta}/{action=Login}/{id?}");
            });
        }
    }
}
