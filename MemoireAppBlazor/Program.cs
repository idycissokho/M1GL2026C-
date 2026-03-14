using MemoireAppBlazor.Components;
using MemoireAppBlazor.Services.ApiClients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

// HttpClient vers M1GLSERVER
builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5197")
});

builder.Services.AddScoped<MemoireApiClient>();
builder.Services.AddScoped<EncadreurApiClient>();
builder.Services.AddScoped<EtudiantApiClient>();
builder.Services.AddScoped<FiliereApiClient>();
builder.Services.AddScoped<AuthApiClient>();
builder.Services.AddScoped<MemoireAppBlazor.Services.AuthSessionService>();

// Session pour stocker le token JWT
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromHours(8);
    options.Cookie.HttpOnly = true;
    options.Cookie.IsEssential = true;
});

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseSession();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
