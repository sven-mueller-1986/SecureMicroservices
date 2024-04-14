using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.IdentityModel.Protocols.OpenIdConnect;
using Refit;
using SecureMicroservices.Client.Authentication;
using SecureMicroservices.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// OID Code flow
//builder.Services.AddSingleton<ITokenService, TokenService>();

// OID Hybrid Flow
builder.Services.AddScoped<ITokenService, TokenHybridService>();

builder.Services.AddTransient<AuthenticationHandler>();

var apiBaseAddress = builder.Configuration["ApiSettings:GatewayAddress"];
ArgumentException.ThrowIfNullOrWhiteSpace(apiBaseAddress, "ApiSettings:GatewayAddress");

builder.Services.AddRefitClient<IMovieApi>()
    .ConfigureHttpClient(config =>
    {
        config.BaseAddress = new Uri(apiBaseAddress);
    })
    .AddHttpMessageHandler<AuthenticationHandler>();

builder.Services.AddRefitClient<IIdentityApi>()
    .ConfigureHttpClient(config =>
    {
        config.BaseAddress = new Uri(builder.Configuration["ApiSettings:IdentityAddress"]!);
    });

builder.Services.AddAuthentication(OpenIdConnectDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme, options =>
    {
        options.Cookie.SameSite = SameSiteMode.None;
        options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
        options.Cookie.IsEssential = true;
    })
    .AddOpenIdConnect(options =>
    {
        options.SignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;

        options.Authority = "https://localhost:5059";

        options.ClientId = "movies_mvc_client";
        options.ClientSecret = "secret";
        options.ResponseType = OpenIdConnectResponseType.CodeIdToken;

        options.Scope.Add("openid");
        options.Scope.Add("profile");
        options.Scope.Add("movieAPI");

        options.SaveTokens = true;

        options.GetClaimsFromUserInfoEndpoint = true;
    });

// OID Hybrid Flow
builder.Services.AddHttpContextAccessor();

// OID Code flow
//builder.Services.AddSingleton(new ClientCredential
//(
//    grantType: "client_credentials",
//    scope: "movieAPI",
//    clientId: "movieClient",
//    clientSecret: "secret"
//));

builder.Services.AddAuthorization();
builder.Services.AddRazorPages(options =>
{
    options.Conventions.AuthorizeFolder("/Movies");
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();

app.Run();
