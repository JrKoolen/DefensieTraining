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
builder.Services.AddScoped<IUserServices, UserService>();

var connectionString = config.GetConnectionString();
builder.Services.AddSingleton(connectionString);

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
    name: "register",
    pattern: "Account/Register",
    defaults: new { controller = "Register", action = "Register" });

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");



app.Run();
