using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Identity.Web;
using Microsoft.Identity.Web.UI;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using OdontoSystem.Data;
using OdontoSystem.Areas.Identity.Data;
using BusinessLogic.Context;
using BusinessLogic.Interfaces;
using BusinessLogic.Repositories;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("OdontoSystemContextConnection") ?? throw new InvalidOperationException("Connection string 'OdontoSystemContextConnection' not found.");

builder.Services.AddDbContext<OdontoSystemContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(connectionString);
});

builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseLazyLoadingProxies();
    options.UseSqlServer(connectionString);
});

builder.Services.ConfigureApplicationCookie(options =>
{
    options.Cookie.Name = ".AspNetCore.Identity.Application";
    options.ExpireTimeSpan = TimeSpan.FromDays(30);
    options.SlidingExpiration = true;
});

builder.Services.AddDefaultIdentity<OdontoSystemUser>(
                    options =>
                    {
                        options.SignIn.RequireConfirmedAccount = false;
                        options.Password.RequireUppercase = true;
                        options.Password.RequireLowercase = true;
                        options.Password.RequiredLength = 8;
                        options.Lockout.AllowedForNewUsers = true;
                        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(10);
                        options.Lockout.MaxFailedAccessAttempts = 5;

                        options.User.AllowedUserNameCharacters = null;
                        options.User.RequireUniqueEmail = true;
                    })
                .AddDefaultUI()
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<OdontoSystemContext>();

builder.Services.AddControllers();
builder.Services.AddSingleton<IPatientRepository, PatientRepository>();
builder.Services.AddSingleton<IPatientHistoryRepository, PatientHistoryRepository>();
builder.Services.AddSingleton<IPatientRecordRepository, PatientRecordRepository>();
builder.Services.AddSingleton<IAgendaRepository, AgendaRepository>();
builder.Services.AddSingleton<IConstraintsRepository, ConstraintsRepository>();
builder.Services.AddSingleton<IInventoryRepository, InventoryRepository>();
builder.Services.AddSingleton<IOdontogramRepository, OdontogramRepository>();
builder.Services.AddSingleton<IOrthodonticPatientRecordRepository, OrthodonticPatientRecordRepository>();
builder.Services.AddSingleton<IScheduleRepository, ScheduleRepository>();
builder.Services.AddSingleton<ITreatmentRepository, TreatmentRepository>();
builder.Services.AddSingleton<IAppointmentHistoryRepository, AppointmentHistoryRepository>();


builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
builder.Services.AddMvc();


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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
