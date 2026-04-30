var builder = WebApplication.CreateBuilder(args)
     .AddHCMPlatform(options =>
     {
         options.EnableSqlSugar = false;
     });

var app = builder.Build();

app.UseHCMPlatform();
app.Run();
