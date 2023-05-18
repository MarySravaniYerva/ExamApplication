using EA.BusinessLogic;
using EA.Database;
using EA.IBussinessLogic;
using EA.IRepository;
using EA.Repository;
using Microsoft.EntityFrameworkCore;

namespace ExamApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddSession(options =>
            {
                options.Cookie.Name = ".EmailId.Session";
                options.IdleTimeout = TimeSpan.FromSeconds(2000);
                //options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            });
            // builder.Services.AddDbContext<ExamApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));
            builder.Services.AddDbContext<ExamApplicationDbContext>(Options => Options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon")));

            builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<IEnrollmentService, EnrollmentService>();
            builder.Services.AddTransient<IEnrollmentRepository, EnrollmentRepository>();

            builder.Services.AddTransient<ILoginservice, LoginService>();
            builder.Services.AddTransient<ILoginRepository, LoginRepository>();

            builder.Services.AddTransient<IRegistrationRepository, RegistrationRepository>();
            builder.Services.AddTransient<IRegistrationService, RegistrationService>();

            builder.Services.AddTransient<IAdmitCardRepository, AdmitCardRepository>();
            builder.Services.AddTransient<IAdmitCardService, AdmitCardService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();
            app.UseSession();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Home}/{id?}");

            app.Run();
        }
    }
}