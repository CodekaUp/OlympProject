using Microsoft.Identity.Client;
using OlympProject.WebApi.Repositories;
using OlympProject.WebApi.Interfaces;
using Microsoft.EntityFrameworkCore;
using OlympProject.Database;

namespace OlympProject
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddTransient<OlympProject.WebApi.Interfaces.IAccount, AccountRepository>();
            builder.Services.AddTransient<IAnimal, AnimalRepository>();
            builder.Services.AddTransient<IAnimalType, AnimalTypeRepository>();
            builder.Services.AddTransient<ILocationPoint, LocationPointRepository>();

            var connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Database=testdb;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;";
            builder.Services.AddDbContext<AppDBContext>(options =>
                options.UseSqlServer(connectionString));

            // Add services to the container.
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

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}