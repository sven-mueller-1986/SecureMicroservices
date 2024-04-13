using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Refit;
using SecureMicroservices.Client.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.AddScoped<ITokenService, TokenService>();
//builder.Services.AddTransient<AuthorizationHandler>();

//var apiBaseAddress = builder.Configuration["ApiSettings:GatewayAddress"];
//ArgumentException.ThrowIfNullOrWhiteSpace(apiBaseAddress, "ApiSettings:GatewayAddress");

//builder.Services.AddRefitClient<IMovieApi>()
//    .ConfigureHttpClient(config =>
//    {
//        config.BaseAddress = new Uri(apiBaseAddress);
//    })
//    .AddHttpMessageHandler<AuthorizationHandler>();

//builder.Services.AddRefitClient<IIdentityApi>()
//    .ConfigureHttpClient(config =>
//    {
//        config.BaseAddress = new Uri(builder.Configuration["ApiSettings:IdentityAddress"]!);
//    });

builder.Services.AddAuthentication(options =>
{
    options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = OpenIdConnectDefaults.AuthenticationScheme;
})
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
        options.ResponseType = "code";

        options.Scope.Add("openid");
        options.Scope.Add("profile");

        options.SaveTokens = true;

        options.GetClaimsFromUserInfoEndpoint = true;
    });

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
