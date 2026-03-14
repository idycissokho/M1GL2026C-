using MemoireAppBlazor.Components;
using MemoireAppBlazor.Services;
using MemoireAppBlazor.Services.ApiClients;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped(sp => new HttpClient
{
    BaseAddress = new Uri("http://localhost:5197")
});

builder.Services.AddScoped<MemoireApiClient>();
builder.Services.AddScoped<EncadreurApiClient>();
builder.Services.AddScoped<EtudiantApiClient>();
builder.Services.AddScoped<FiliereApiClient>();
builder.Services.AddScoped<AuthApiClient>();
builder.Services.AddScoped<AuthStateService>();


var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseAntiforgery();

app.MapStaticAssets();
app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();
