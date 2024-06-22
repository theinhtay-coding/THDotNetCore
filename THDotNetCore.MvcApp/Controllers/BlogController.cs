using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THDotNetCore.MvcApp.Db;

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
}
