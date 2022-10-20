using System.Diagnostics;
using UdemyEFCore.CodeFirst.DAL;

namespace CompiledModelWorkerService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IServiceProvider _serviceProvider;
        public Worker(ILogger<Worker> logger, IServiceProvider serviceProvider)
        {
            _logger = logger;
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
           
                Enumerable.Range(1, 10).ToList().ForEach(x =>
                {
                    var stopWatch = new Stopwatch();
                

                    using var scope = _serviceProvider.CreateScope();
                    stopWatch.Start();
                    var dbContext = scope.ServiceProvider.GetRequiredService<AppDbContext>();

                    Console.WriteLine($"Elapsed Time : {stopWatch.Elapsed}");

                    stopWatch.Stop();

                });

             



            
        }
    }
}