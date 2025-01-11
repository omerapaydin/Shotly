using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shotly.Data.Abstract;
using Shotly.Data.Concrete;
using Shotly.Data.Concrete.EfCore;
using Shotly.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options=>{
    options.LoginPath = "/Account/Login";
});

builder.Services.AddDbContext<IdentityContext> (options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);
});

builder.Services.AddScoped<IPostRepository,EfPostRepository>();
builder.Services.AddScoped<ICommentRepository,EfCommentRepository>();




var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseHttpsRedirection();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<IdentityContext>();
    DbInitializer.Seed(context);
}

app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

app.Run();
