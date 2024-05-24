using DefensieTrainer.Dal.Repositories;
using DefensieTrainer.Domain.IRepositories;
using DefensieTrainer.Domain.IServices;
using DefensieTrainer.Domain.Service;

ConfigurationProvider config = new ConfigurationProvider();

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IRequirementServices, RequirementService>();
builder.Services.AddScoped<IRequirementRepository, RequirementRepository>();
builder.Services.AddScoped<IClusterService, ClusterService>();
builder.Services.AddScoped<IClusterRepository, ClusterRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

var connectionString = config.GetConnectionString();
builder.Services.AddSingleton(connectionString);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Use session middleware
app.UseSession();

app.UseAuthorization();

app.MapControllerRoute(
    name: "register",
    pattern: "Account/Register",
    defaults: new { controller = "Register", action = "Register" });

app.MapControllerRoute(
    name: "login",
    pattern: "Account/Login",
    defaults: new { controller = "Login", action = "Login" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
