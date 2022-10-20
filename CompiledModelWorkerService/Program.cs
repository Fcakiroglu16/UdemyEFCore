using CompiledModelWorkerService;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using UdemyEFCore.CodeFirst.DAL;

IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((context,services) =>
    {



        //Multitenant
        //services.AddDbContext<AppDbContext>((sp,options) =>
        //{
        //    options.UseSqlServer(context.Configuration.GetConnectionString("SqlCon"));

        //});

        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(context.Configuration.GetConnectionString("SqlCon"));

              options.UseModel(MyCompiledModels.AppDbContextModel.Instance);
        });



        services.AddHostedService<Worker>();
    })
    .Build();

host.Run();
