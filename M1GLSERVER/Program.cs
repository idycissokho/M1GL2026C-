using M1GLSERVER.Components;
using M1GLSERVER.EntityE2E;
using M1GLSERVER.Repositories;
using M1GLSERVER.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Lire la cha�ne de connexion unique et enregistrer le DbContext
var connectionString = builder.Configuration.GetConnectionString("connBdMemoire")
    ?? throw new InvalidOperationException("Connection string 'connBdMemoire' not found.");

builder.Services.AddDbContext<DbMemoireContextE2E>(options =>
    options.UseNpgsql(connectionString));

// Enregistrer les repositories
builder.Services.AddScoped<IMemoireRepository, MemoireRepository>();
builder.Services.AddScoped<IEncadreurRepository, EncadreurRepository>();
builder.Services.AddScoped<IEtudiantRepository, EtudiantRepository>();
builder.Services.AddScoped<IFiliereRepository, FiliereRepository>();

// Enregistrer les services
builder.Services.AddScoped<IMemoireService, MemoireService>();
builder.Services.AddScoped<IEncadreurService, EncadreurService>();
builder.Services.AddScoped<IEtudiantService, EtudiantService>();
builder.Services.AddScoped<IFiliereService, FiliereService>();

// Ajouter les contrôleurs
builder.Services.AddControllers();

// Add services to the container.
builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

var app = builder.Build();



// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

// Mapper les contrôleurs
app.MapControllers();

app.Run();
