using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using TP1.Data;
using TP1.Service;

var builder = WebApplication.CreateBuilder(args);

//////////////////

//    options.UseMySql(
//        builder.Configuration.GetConnectionString("DefaultConnection"),
//        new Microsoft.EntityFrameworkCore.MySqlServerVersion(new Version(8, 0, 33))
//    )
//);


///////////////////////////////





// Add services to the container.










builder.Services.AddControllers();
// Learn more abodout configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

//var mySQLConfiguration = new MySqlConfiguration(builder.Configuration.GetConnectionString("mainConnection"));
//builder.Services.AddSingleton(mySQLConfiguration);
var connectionString = builder.Configuration.GetConnectionString("mainConnection");
builder.Services.AddDbContext<AppDbContext>(options => options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

var app = builder.Build();



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
