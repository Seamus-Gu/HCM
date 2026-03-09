
var builder = WebApplication.CreateBuilder(args)
     .AddPIHCMPlatform();

var app = builder.Build();

app.InitConfigure();
app.Run();
