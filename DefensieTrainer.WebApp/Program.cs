using DefensieTrainer.Dal.Repositories;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.Service;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddHttpContextAccessor(); 

ConfigurationProvider config = new ConfigurationProvider();
string connectionString = config.GetConnectionString();
builder.Services.AddSingleton(connectionString);

builder.Services.AddScoped<ITrainingService, TrainingService>();
builder.Services.AddScoped<ITrainingRepository, TrainingRepository>(provider =>
{
    var connectionString = provider.GetRequiredService<string>();
    return new TrainingRepository(connectionString);
});
builder.Services.AddScoped<IRequirementServices, RequirementService>();
builder.Services.AddScoped<IRequirementRepository, RequirementRepository>(provider =>
{
    var connectionString = provider.GetRequiredService<string>();
    return new RequirementRepository(connectionString);
});

builder.Services.AddScoped<IClusterService, ClusterService>();
builder.Services.AddScoped<IClusterRepository, ClusterRepository>(provider =>
{
    var connectionString = provider.GetRequiredService<string>();
    return new ClusterRepository(connectionString);
});

builder.Services.AddScoped<IPersonService, PersonService>();
builder.Services.AddScoped<IPersonRepository, PersonRepository>(provider =>
{
    var connectionString = provider.GetRequiredService<string>();
    return new PersonRepository(connectionString);
});

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/Login/Login";
        options.AccessDeniedPath = "/Account/AccessDenied";
        options.Cookie.HttpOnly = true;
        options.Cookie.IsEssential = true;
        options.Cookie.Name = "DefensieTrainingAuth";
    });

builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RequireManagerRole", policy => policy.RequireRole("Manager"));
    options.AddPolicy("RequireCoachRole", policy => policy.RequireRole("Coach"));
    options.AddPolicy("RequireUserRole", policy => policy.RequireRole("User"));
});

builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
