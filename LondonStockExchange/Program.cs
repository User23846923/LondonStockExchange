using LondonStockExchange.DataLayer;
using LondonStockExchange.Services;

namespace LondonStockExchange
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();

            builder.Services.AddSingleton<IDbContext, DbContext>();
            builder.Services.AddSingleton<IVwapCalculator, VwapCalculator>();
            builder.Services.AddSingleton<ITradesService, TradesService>();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

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
