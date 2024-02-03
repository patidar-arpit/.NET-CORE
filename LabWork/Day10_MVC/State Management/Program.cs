namespace State_Management
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            //for session we have to add the service
            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(10); //session timeout
                options.Cookie.HttpOnly = true; //whether client side script can access cookie. false means yes
                options.Cookie.IsEssential = true; //cookie will be always created if true
            });

            //added so we can use ...
            //@inject IHttpContextAccessor HttpContextAccessor
            // ... in the View
            builder.Services.AddHttpContextAccessor();


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
                pattern: "{controller=Default}/{action=Session1}/{id?}");

            app.Run();
        }
    }
}
