using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using HotelManagement.Database;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionStringBuilder = new SqlConnectionStringBuilder(@"Server=LAPTOP-HGV8Q04P\SQLEXPRESS;Database=Hotel;User Id=sa;Password=Sinh!@121;");
connectionStringBuilder.TrustServerCertificate = true;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionStringBuilder.ConnectionString));

builder.Services.AddControllersWithViews();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.UseStaticFiles();

app.MapControllers();

app.Run();
