using Jobify.DataAccess.Data;
using Jobify.DataAccess.Repository;
using Jobify.DataAccess.Repository.IRepository;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using JobApp.Areas.Identity.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.Authentication;
using System.Security.Claims; //

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var connectionString = builder.Configuration.GetConnectionString("JobAppContextConnection") ?? throw new InvalidOperationException("Connection string 'JobAppContextConnection' not found.");


builder.Services.AddDbContext<JobAppContext>(options => options.UseSqlServer(connectionString));


var config = builder.Configuration;
builder.Services.AddAuthentication()
   .AddGoogle(options =>
   {
       IConfigurationSection googleAuthNSection =
       config.GetSection("Authentication:Google");
       options.ClientId = googleAuthNSection["ClientId"];
       // options.RetrieveUserDetails = true;
       options.ClientSecret = googleAuthNSection["ClientSecret"];

   });



builder.Services.AddDefaultIdentity<JobAppUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JobAppContext>();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();


//Krijimi i tri roleve perkatese per authorization
using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "Punedhenesi", "Punekerkuesi" };

    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}


//Krijimi lokal i adminit
using (var scope = app.Services.CreateScope())
{
    var userManager = scope.ServiceProvider.GetRequiredService<UserManager<JobAppUser>>();

    string email = "admin@admin.com";
    string password = "Test1234,";
    string firstName = "Admin";
    string lastName = "Admin";

    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user = new JobAppUser();
        user.UserName = email;
        user.Email = email;
        user.FirstName = firstName;
        user.LastName = lastName;
        user.EmailConfirmed = true;  //e kemi vendosur per arsye te mos kerkimit te konfirmimit te email

        await userManager.CreateAsync(user, password);

        await userManager.AddToRoleAsync(user, "Admin");
    }


}
app.Run();
