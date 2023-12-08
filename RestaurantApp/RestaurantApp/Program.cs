using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using RestaurantApp.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    //bilo ovo
   // app.UseSwaggerUI();
    //dodala ja ovo

    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API ");
    });
    
}

//dodala
app.UseCors(
               options => options
               .SetIsOriginAllowed(x => _ = true)
               .AllowAnyMethod()
               .AllowAnyHeader()
               .AllowCredentials()
           ); //This needs to set everything allowed

//dodala
app.UseRouting();

//dodala
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller}/{action=Index}/{id?}");
});

app.UseHttpsRedirection();

app.MapControllers();

app.Run();
