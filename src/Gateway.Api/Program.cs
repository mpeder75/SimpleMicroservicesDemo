var builder = WebApplication.CreateBuilder(args);

/// <sumnmary>
/// Reverse Proxy tilføjes til IOC container
/// vi loader konfigurationen fra appsettings.json, som definere hvilke 
/// api der skal tilføjes til reverse proxy
/// </sumnmary>
builder.Services.AddReverseProxy().
    LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// app.UseHttpsRedirection();

// Reverse Proxy middleware tilføjes til pipeline

app.MapReverseProxy();

app.Run();
