using SalesPlatform_Web.Extensions;
using SalesPlatform_Application.DependencyInjection;
using SalesPlatform_Infrastructure.DependencyInjection;
using SalesPlatform_Application.Mappings;
using Microsoft.Extensions.Configuration;
using SalesPlatform_Application.IServices;
using SalesPlatform_Application.Services;
using SalesPlatform_Application.Hubs;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddApplication().AddInfrastructure();

builder.Services.AddDbContextService(builder.Configuration);
builder.Services.AddApplicationService(builder.Configuration);
builder.Services.AddAutoMapper(typeof(UserMapper).Assembly);
builder.Services.AddCorsService();
builder.Services.AddSwaggerGenService();
builder.Services.AddIdentityService();
builder.Services.AddSignalR();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("MyPolicy");
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<ChatHub>("/chat");

app.Run();
