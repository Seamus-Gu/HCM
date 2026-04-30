var builder = WebApplication.CreateBuilder(args)
     .AddHCMPlatform();

var app = builder.Build();

app.UseHCMPlatform();
app.Run();
