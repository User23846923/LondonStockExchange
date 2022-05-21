
using LondonStockExchange.DataLayer;
using LondonStockExchange.Models;

namespace LondonStockExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var repo = new TradeRepository();
            repo.Insert(new Trade { Id = 1, BrokerId = 1, Ticker = "BT.L", Amount = 1000, Price = 25.0M });
            repo.Insert(new Trade { Id = 2, BrokerId = 1, Ticker = "VOD.L", Amount = 100, Price = 10.0M });
            repo.Insert(new Trade { Id = 3, BrokerId = 1, Ticker = "VOD.L", Amount = 100, Price = 20.0M });
            repo.Insert(new Trade { Id = 4, BrokerId = 1, Ticker = "VOD.L", Amount = 100, Price = 30.0M });

            builder.Services.AddControllers();
            builder.Services.AddSingleton<ITradeRepository>(repo);
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
