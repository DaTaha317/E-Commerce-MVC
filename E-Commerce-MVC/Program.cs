using E_Commerce_MVC.Interfaces;
using E_Commerce_MVC.Models;
using E_Commerce_MVC.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace E_Commerce_MVC
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); ;

            // IoC container Registerations
            builder.Services.AddDbContext<ECommerceDB>(options => 
                options.UseLazyLoadingProxies()
                .UseSqlServer(builder.Configuration.GetConnectionString("cs"))
            );

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 5;

            }).AddEntityFrameworkStores<ECommerceDB>();

            builder.Services.AddScoped<IProductRepo,ProductRepo>();
            builder.Services.AddScoped<ICartItemRepo,CartItemRepo>();
            builder.Services.AddScoped<ICategoryRepo,CategoryRepo>();
            builder.Services.AddScoped<ICustomerRepo,CustomerRepo>();
            builder.Services.AddScoped<IOrderItemRepo,OrderItemRepo>();
            builder.Services.AddScoped<IPaymentRepo,PaymentRepo>();
            builder.Services.AddScoped<IShipmentRepo,ShipmentRepo>();
            builder.Services.AddScoped<IOrderRepo,OrderRepo>();


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
