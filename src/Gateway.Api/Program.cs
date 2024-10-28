var builder = WebApplication.CreateBuilder(args);

builder.Services.AddReverseProxy().
    LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

var app = builder.Build();

//if (app.Environment.IsDevelopment())
//{
//    app.UseSwagger();
//    app.UseSwaggerUI();
//}

// app.UseHttpsRedirection();

// Reverse Proxy middleware tilf�jes til pipeline
app.MapReverseProxy();

app.Run();
