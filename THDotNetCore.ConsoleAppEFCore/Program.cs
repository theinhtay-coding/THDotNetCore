using THDotNetCore.ConsoleAppEFCore.Databases.Models;
// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");

AppDbContext db = new AppDbContext();
db.TblBlogs.ToList();
