using GymApplication.Data;
using GymApplication.Email;
using GymApplication.Interface;
using GymApplication.Providers;
using GymApplication.Services;
using GymApplication.Utilities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);
//var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<GymContext>(options=>options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

builder.Services.AddIdentity<ApplicationUser, IdentityRole>().AddEntityFrameworkStores<GymContext>().AddDefaultTokenProviders().AddDefaultUI();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
//builder.Services.Configure<EmailService>(builder.Configuration.GetSection("EmailConfiguration"));
builder.Services.Configure<MailSettings>(builder.Configuration.GetSection("MailSettings"));
//register

builder.Services.AddScoped<IUtility, Utility>();
//builder.Services.AddScoped<IMain, MainProvider>();
builder.Services.AddScoped<IFitnessPlus, FitnessPlusProvider>();
//builder.Services.AddScoped<IEmailService, EmailServiceProvider>();
builder.Services.AddScoped<IDashboard, DashboardProvider>();
builder.Services.AddScoped<IEmailService, EMailService>();


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
app.UseAuthorization();

//app.UseAuthorization();
app.MapAreaControllerRoute(
    name: "Identity",
    areaName: "Identity",
    pattern: "Identity/{controller=Account}/{action=Login}/{id?}");


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=LandingPage}/{id?}");

using (var scope = app.Services.CreateScope())
{


    var roleManager=scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "Admin", "User" };
    foreach (var role in roles)
    {
        if (!await roleManager.RoleExistsAsync(role))
            await roleManager.CreateAsync(new IdentityRole(role));
    }
}
using (var scope = app.Services.CreateScope())
{
    var userManager=scope.ServiceProvider.GetRequiredService<UserManager<ApplicationUser>>();

    string email = "admin@gmail.com";
    string password = "Admin@123";
    if (await userManager.FindByEmailAsync(email) == null)
    {
        var user= new ApplicationUser();
        user.FullName = "Admin";
        user.PhoneNumber = "0000000000";
        user.UserName = email;
        user.Email = email;
        user.EmailConfirmed = true;
       await userManager.CreateAsync(user, password);
        await userManager.AddToRoleAsync(user, "Admin");
    }
}

app.MapRazorPages();
app.Run();