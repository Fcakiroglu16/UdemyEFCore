// See https://aka.ms/new-console-template for more information

using System.Diagnostics;
using UdemyEFCore.CodeFirst.DAL;



Enumerable.Range(1, 10).ToList().ForEach(x =>
{
    var stopWatch = new Stopwatch();
    stopWatch.Start();

    using var context = new AppDbContext();

    Console.WriteLine($"Elapsed Time : {stopWatch.Elapsed}");

    stopWatch.Stop();

});
















