using DependencyInjectionRegistrationOption.BLL;
using DependencyInjectionRegistrationOption.Core.Helper;
using DependencyInjectionRegistrationOption.Core.Helper.Interfaces;
using DependencyInjectionRegistrationOption.Core.Middleware;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddScoped<IOperationScoped, Operation>();
builder.Services.AddSingleton<IOperationSingleton, Operation>();
builder.Services.AddTransient<IOperationTransient, Operation>();
builder.Services.AddScoped(typeof(DummyBusiness));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseFirstMiddleware();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();