using Coditas.ECom.DataAccess1.Models;
using Microsoft.EntityFrameworkCore;
using Coditas.ECom.Repositories;
using MVC_Apps.CustomeFilters;
using MVC_Apps.CustomSessionExtensions;
using Microsoft.AspNetCore.Identity;
using MVC_Apps.Data;
using MVC_Apps.Models;
using Microsoft.AspNetCore.Authorization;
using MVC_Apps;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//this is used to accecpt the request mvc and api controllers
//for mvc controller this helps to locate view to execute
builder.Services.AddControllersWithViews();

//builder.Services.AddHostedService<MoveImageBackgroundService>();

builder.Services.AddDbContext<eShoppingContext>(
    x => x.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"))
    );

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SecurityDbContext>();

/*builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<SecurityDbContext>();*/

builder.Services.AddDbContext<SecurityDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SecurityDbContextConnection"));
});

builder.Services.AddIdentity<IdentityUser,IdentityRole>(
    options => options.SignIn.RequireConfirmedAccount = false)
    .AddEntityFrameworkStores<SecurityDbContext>().AddDefaultUI();

builder.Services.AddRazorPages();


builder.Services.AddAuthorization(options =>
{
    // AuthorizationPolicyBuider
    options.AddPolicy("ReadPolicy", policy =>
    {
        policy.RequireRole("Administrator", "Manager", "Clerk", "Operator");
    });
    options.AddPolicy("CreatePolicy", policy =>
    {
        policy.RequireRole("Administrator", "Manager", "Clerk");
    });
    options.AddPolicy("EditPolicy", policy =>
    {
        policy.RequireRole("Administrator", "Manager");
    });
    options.AddPolicy("DeletePolicy", policy =>
    {
        policy.RequireRole("Administrator");
    });
});

//Check the User's AUTHORIZATION
builder.Services.AddAuthorization(options =>
{
    // The Custom Policy for View Accessibility
    options.AddPolicy("AllOps", policy =>
    {
        // The USer MUST be Adim
        policy.RequireRole("Administrator");
        // MUST be 18years 
    });
    options.AddPolicy("UD", policy =>
    {
        // The USer MUST be Adim
        policy.RequireRole("Administrator", "Manager");
        // MUST be 18years 
    });
});
// Custom Request Handler for AUTHORIZATION Check


builder.Services.AddControllersWithViews(Options => {
    //Options.Filters.Add(typeof(LogRequestAttribute));
    Options.Filters.Add(typeof(AppExceptionAttribute));

});


builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options => {
    options.IdleTimeout = TimeSpan.FromMinutes(20);
});


builder.Services.AddScoped<IDBRepository<Category, int>, CategoryRepository>();
builder.Services.AddScoped<IDBRepository<Product, int>, ProductRepository>();



var app = builder.Build();


// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    //Show Error During development these are standerd messages
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
//Middleware used to read and write files on server for upload and download
//By Defualt this is used to read contents of 'wwwroot'
app.UseStaticFiles();



//create load and execute rout table for
//mvc controller routing to execute
//an action method of a controller class
app.UseRouting();

app.UseSession();
app.UseAuthentication();;

//used in case of role based security
app.UseAuthorization();

//map the incomming http request url to coresponding controller
//and the action method from the controller
//"{controller}/{action}/{id?}
//{controller} : the name of the controller in url
//{action} : action method from the controller mentioned in url
//{id? } :the nu;;abe parameter which is a scalar type varible passed to action method

//e.g
//http://Myserver/MyApp/MyController/MyAction
//{controller} :MyController
//{action} : MyAction
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

IServiceProvider serviceProvider = builder.Services.BuildServiceProvider();
await GlobalOps.CreateApplicationAdministrator(serviceProvider);

app.Run();

