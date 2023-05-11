using Neusta.Workshop.Buchungssystem.Application;
using Neusta.Workshop.Buchungssystem.RestApi.Interfaces;
using Neusta.Workshop.Buchungssystem.RestApi.Mappers;
using Neusta.Workshop.Buchungssystem.Storage;

WebApplicationBuilder? builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddRouting(options => options.LowercaseUrls = true);

builder.Services.AddApplication();
builder.Services.AddInfrastructure();
builder.Services.AddTransient<IPersonMapper, PersonMapper>();
builder.Services.AddTransient<IRaumMapper, RaumMapper>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

WebApplication? app = builder.Build();

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
