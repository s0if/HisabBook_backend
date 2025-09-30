
using HisabBook.API.Middleware;
using HisabBook.APPLICATION.Mapping;
using HisabBook.APPLICATION.UseCase;
using HisabBook.DOMAIN.Interface;
using HisabBook.PERSISTENCE;
using HisabBook.PERSISTENCE.Repository;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

namespace HisabBook.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            //service registration
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });
            builder.Services.AddScoped<AddTransactionMoney>();
            builder.Services.AddScoped<CreateTransactionMoney>();
            builder.Services.AddScoped<EditTransactionMoney>();
            builder.Services.AddScoped<UpdateTransactionMoney>();
            builder.Services.AddScoped<DeleteTransactionMoney>();
            builder.Services.AddScoped<GetAllTransactionMoney>();
            builder.Services.AddScoped<SalarySummary>();


            builder.Services.AddScoped< ITransactionMoneyRepository, TransactionMoneyRepository> ();

            builder.Services.AddControllers()
            .AddJsonOptions(options =>
            {
                options.JsonSerializerOptions.Converters.Add(new System.Text.Json.Serialization.JsonStringEnumConverter());
            });

            builder.Services.AddCors(option => option.AddPolicy("allowAll", build =>
            {
                build.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod();
            }));
            builder.Services.AddControllers();
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            builder.Services.AddOpenApi();

            var app = builder.Build();
            

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.MapOpenApi();
                app.MapScalarApiReference();
            }
            app.UseMiddleware<ExceptionHandlingMiddleware>();

            app.UseCors("allowAll");
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
