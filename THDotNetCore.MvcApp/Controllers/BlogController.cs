using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THDotNetCore.MvcApp.Db;
using THDotNetCore.MvcApp.Models;

namespace THDotNetCore.MvcApp.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    public BlogController(AppDbContext appDbContext)
    {
        _db = appDbContext;
    }

    public async Task<IActionResult> Index()
    {
        var lst = await _db.Blogs.AsNoTracking().ToListAsync();
        return View(lst);
    }

    [ActionName("Create")]
    public IActionResult BlogCreate()
    {
        return View("BlogCreate");
    }

    [HttpPost]
    [ActionName("Save")]
    public async Task<IActionResult> BlogCreate(BlogModel blog)
    {
        await _db.Blogs.AddAsync(blog);
        var result = await _db.SaveChangesAsync();
        //return View("BlogCreate");
        return Redirect("/Blog");
    }
}
