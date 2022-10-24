using App.API;
using Microsoft.EntityFrameworkCore;
using UdemyEFCore.CodeFirst.DAL;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<AppDbContext>((sp, options) =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlCon"));
    options.AddInterceptors(new LogDurationDbContextInterceptor(sp.GetRequiredService<ILogger<LogDurationDbContextInterceptor>>()));
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();