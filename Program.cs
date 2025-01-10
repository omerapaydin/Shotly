using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Shotly.Data.Concrete.EfCore;
using Shotly.Entity;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddIdentity<ApplicationUser,IdentityRole>().AddEntityFrameworkStores<IdentityContext>().AddDefaultTokenProviders();

builder.Services.AddDbContext<IdentityContext> (options =>{
    options.UseSqlite(builder.Configuration["ConnectionStrings:sql_connection"]);
});



var app = builder.Build();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.UseStaticFiles();
app.UseHttpsRedirection();


app.MapControllerRoute(
    name:"default",
    pattern:"{controller=Home}/{action=Index}/{id?}"
);

app.Run();
