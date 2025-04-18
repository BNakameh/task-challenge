using coding_challenge.Repositories;
using coding_challenge.Services;
using System.Threading.RateLimiting;

namespace coding_challenge
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register our mock service
            builder.Services.AddSingleton<IMockTaskService, MockTaskService>();
            builder.Services.AddSingleton<IMockTaskRepository, MockTaskRepository>();

            builder.Services.AddRateLimiter(options =>
            {
                options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

                options.AddPolicy("fixed", context =>
                    RateLimitPartition.Get(
                        context.Connection.RemoteIpAddress?.ToString() ?? "unknown",
                        key => new FixedWindowRateLimiter(
                            new FixedWindowRateLimiterOptions
                            {
                                PermitLimit = 10,
                                Window = TimeSpan.FromSeconds(30),
                                QueueProcessingOrder = QueueProcessingOrder.OldestFirst,
                                QueueLimit = 0
                            })
                    )
                );
            });

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowAll", policy =>
                {
                    policy.AllowAnyOrigin() 
                          .AllowAnyHeader()
                          .AllowAnyMethod();
                });
            });

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
            app.UseRateLimiter();

            app.UseCors("AllowAll");

            app.Run();
        }
    }
}
