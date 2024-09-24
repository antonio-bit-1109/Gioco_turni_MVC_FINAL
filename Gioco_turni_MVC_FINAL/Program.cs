using Gioco_turni_MVC_FINAL.Repository;
using Microsoft.AspNetCore.Identity;

var builder = WebApplication.CreateBuilder(args);

// Aggiungi i servizi al contenitore.
builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddDefaultUI() // Abilita le view di Identity UI
    .AddUserStore<UserRepository>() // Usa UserRepository come UserStore
    .AddDefaultTokenProviders();

builder.Services.AddControllersWithViews();

// Registra UserRepository come servizio ( la stringa di connessione è passata internamente alla classe UserRepository)
builder.Services.AddScoped<IUserStore<IdentityUser>, UserRepository>();
builder.Services.AddScoped<IUserPasswordStore<IdentityUser>, UserRepository>();
builder.Services.AddScoped<IUserEmailStore<IdentityUser>, UserRepository>();

var app = builder.Build();

// Configura la pipeline delle richieste HTTP.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
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
