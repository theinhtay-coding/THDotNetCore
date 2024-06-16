// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Data.SqlClient;
using THDotNetCore.ConsoleApp.AdoDotNetExamples;
using THDotNetCore.ConsoleApp.DapperExamples;
using THDotNetCore.ConsoleApp.EFCoreExamples;
using THDotNetCore.ConsoleApp.Services;

Console.WriteLine("Hello, World!");

//AdoDotNetExample adoDotNetExample = new AdoDotNetExample();
//adoDotNetExample.Read();
//adoDotNetExample.Edit(2);
//adoDotNetExample.Create("Test Title", "Test Author", "Test Content");
//adoDotNetExample.Update(11, "Test Title 3", "Test Author 3", "Test Content 3");
//adoDotNetExample.Delete(11);

//DapperExample dapperExample = new DapperExample();
//dapperExample.Run();

//EFCoreExample eFCoreExample = new EFCoreExample();
//eFCoreExample.Run();

var connectionString = ConnectionStrings.SqlConnectionStringBuilder.ConnectionString;
var sqlConnectionStringBuilder = new SqlConnectionStringBuilder(connectionString);
var serviceProvider = new ServiceCollection()
    .AddScoped(n => new AdoDotNetExample(sqlConnectionStringBuilder))
    .AddScoped(n => new DapperExample(sqlConnectionStringBuilder))
    .AddDbContext<AppDbContext>(opt =>
    {
        opt.UseSqlServer(connectionString);
    })
    .AddScoped<EFCoreExample>()
    .BuildServiceProvider();

//AppDbContext db = serviceProvider.GetRequiredService<AppDbContext>();

var adoDotNetExample = serviceProvider.GetRequiredService<AdoDotNetExample>();
adoDotNetExample.Read();

//var dapperExample = serviceProvider.GetRequiredService<DapperExample>();
//dapperExample.Run();

Console.ReadKey();