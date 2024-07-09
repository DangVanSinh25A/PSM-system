using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;
using HotelManagement.Database;
using HotelManagement.Sevice;
using HotelManagement.Repositories;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionStringBuilder = new SqlConnectionStringBuilder(@"Server=LAPTOP-HGV8Q04P\SQLEXPRESS;Database=Hotel;User Id=sa;Password=Sinh!@121;");
connectionStringBuilder.TrustServerCertificate = true;
builder.Services.AddDbContext<AppDbContext>(
    options => options.UseSqlServer(connectionStringBuilder.ConnectionString));

builder.Services.AddControllersWithViews();

builder.Services.AddScoped<ISellerRepository, SellerRepository>();
builder.Services.AddScoped<ISellerService, SellerService>();

builder.Services.AddScoped<IHotelRepository, HotelRepository>();
builder.Services.AddScoped<IHotelService, HotelService>();

builder.Services.AddScoped<IChannelRepository, ChannelRepository>();
builder.Services.AddScoped<IChannelService, ChannelService>();

builder.Services.AddScoped<IPaymentConstraintRepository, PaymentConstraintRepository>();
builder.Services.AddScoped<IPaymentConstraintService, PaymentConstraintService>();

builder.Services.AddScoped<ICancelPolicyRepository, CancelPolicyRepository>();
builder.Services.AddScoped<ICancelPolicyService, CancelPolicyService>();

builder.Services.AddScoped<IAdditionalRepository, AdditionalRepository>();
builder.Services.AddScoped<IAdditionalService, AdditionalService>();

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

app.Urls.Add("http://192.168.1.131:5034");

app.Run();
