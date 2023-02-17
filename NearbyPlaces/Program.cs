using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using NearbyPlaces.Data;
using NearbyPlaces.Hubs;
using NearbyPlaces.Reositories;
using NearbyPlaces.Repositories;
using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();


builder.Services.AddControllers();
builder.Services.AddDbContext<PlacesDbContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddMvc().AddXmlSerializerFormatters();

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles); //Had to add it to be able to send all skills of particular HeistMember


builder.Services.AddScoped<ISuccessfulRequestRepository, SuccessfulRequestRepository>();
builder.Services.AddScoped<ISuccessfulResponseRepository, SuccessfulResponseRepository>();
builder.Services.AddSignalR();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();


app.MapHub<RequestHub>("/hubs/requestCount");
app.UseAuthorization();

app.MapControllers();
app.MapRazorPages();
app.Run();
