using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SignalR.Hubs;
using SignalR.Services;
using SignalR_Infraestructura.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

builder.Services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = new PathString("/Cuentas/Login");
    options.AccessDeniedPath = new PathString("/Cuentas/Bloqueado");
});

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequiredLength = 6;
    options.Password.RequireLowercase = true;
    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(2);
    options.Lockout.MaxFailedAccessAttempts = 2;
});

//Estas son las opciones de configuración de identity

builder.Services.Configure<IdentityOptions>(options =>

{

    options.Password.RequiredLength = 6; //--> Cantidad minima de caracteres para la contraseña

    options.Password.RequireLowercase = true; //-> Solicitar caracteres en minuscula

    options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5); //-> Tiempo de bloqueo de la cuenta despues de varios intentos fallidos.

    options.Lockout.MaxFailedAccessAttempts = 2; //-> Numero de intentos para bloquear la aplicación

});

builder.Services.AddSignalR();

builder.Services.AddScoped<IAnswerGeneratorServices, AnswerGeneratorServices>();

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

app.UseEndpoints(endpoints =>
{
    endpoints.MapHub<MessageHub>("/message");
    endpoints.MapHub<ChatHub>("/messageChat");
});

app.Run();
