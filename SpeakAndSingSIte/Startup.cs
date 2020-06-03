using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SiteSpeakAndSing.Domain;
using SiteSpeakAndSing.Domain.Repositories.Absrtact;
using SiteSpeakAndSing.Domain.Repositories.EntityFramework;
using SiteSpeakAndSing.Service;

namespace SpeacAndSingSIte
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            //подключаем configuration из ahhsettings.json
            Configuration.Bind("Project", new Config());

            //подключасем нужный функционал приложения в качестве сервисов
            services.AddTransient<ITextFieldsRepositories, FETextFieldsRepositories>();
            services.AddTransient<IServiceItemsRepositories, EFServiceItemsRepositories>();
            services.AddTransient<ITeacherRepositories, EFTeachersRepositories>();
            services.AddTransient<DataManager>();

            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //настраиваем identity систему
            services.AddIdentity<IdentityUser, IdentityRole>(opts =>
            {
                opts.User.RequireUniqueEmail = true;
                opts.Password.RequiredLength = 6;
                opts.Password.RequireNonAlphanumeric = false;
                opts.Password.RequireLowercase = false;
                opts.Password.RequireUppercase = false;
                opts.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //настраиваем authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "Speak&Sing";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //настраиваем политуку фвторизвации для Admin area
            services.AddAuthorization(x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });
            //lобавили поддержку контроллеров и представлений(view)
            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAythorization("Admin", "AdminArea"));
            })
            //а здесь мы привязали конкретную версию
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // порядок подключения очень важен (middleware)

            // в процессе разработки сайта необшодимо видеть где возникла ошибка, 
            // но видно это только в режиме разработчика development
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

            // подключаем систему маршрутизации
            app.UseRouting();

            //подключаем аутентификацию и авторизацию
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //подключаем поддержку статических файлов(css, js картинки скрипты)
            app.UseStaticFiles();

            //регистрируем нужные маршруты(endpoints)
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
