using Database;
using Database.Extantions;
using Microsoft.EntityFrameworkCore;
using PumpApi.Middlewares;
using PumpService.Extansions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDatabaseModule(builder.Configuration);
builder.Services.AddPumpService();
builder.Services.AddTransient<ExceptionMiddleware>();

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyAllowSpecificOrigins", builder =>
    {
        builder.WithOrigins("http://localhost:4200");
        builder.WithHeaders("*");
        builder.WithMethods("DELETE", "PUT");
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyAllowSpecificOrigins");
app.UseStaticFiles();


app.MapControllers();

using (var serviceScope = app.Services.CreateScope())
{
    var dbContext = serviceScope.ServiceProvider.GetRequiredService<ApplicationContext>();
    dbContext.Database.Migrate();
    Initializer.InitializeDB(dbContext);
}
app.UseMiddleware<ExceptionMiddleware>();
app.Run();
