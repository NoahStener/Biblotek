
using Microsoft.EntityFrameworkCore;
using MinimalAPI.Data;
using MinimalAPI.EndPoint;
using MinimalAPI.Repository;

namespace MinimalAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            //lägger till CORS-policy
            builder.Services.AddCors((setup) => setup.AddPolicy("default", (options) =>
            {
                options.AllowAnyMethod()
                .AllowAnyHeader()
                .AllowAnyOrigin();
            }));

            // Add services to the container.
            builder.Services.AddAuthorization();

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddAutoMapper(typeof(MappingConfig));


            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
            builder.Services.AddScoped<IBookRepository , BookRepository>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("default");

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.ConfigurationBookEndPoints();
            
            app.Run();
        }
    }
}
