﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using THDotNetCore.MvcApp2.Db;
using THDotNetCore.MvcApp2.Models;

namespace THDotNetCore.MvcApp2.Controllers;

public class BlogController : Controller
{
    private readonly AppDbContext _db;

    public BlogController(AppDbContext appDbContext)
    {
        _db = appDbContext;
    }

    [ActionName("Index")]
    public async Task<IActionResult> BlogIndex()
    {
        // select * from tbl_Blog with (nolock)
        var lst = await _db.Blogs
            .AsNoTracking()
            .OrderByDescending(x => x.BlogId)
            .ToListAsync();
        return View("BlogIndex", lst);
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
        //return Redirect("/Blog");
        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ?"Saving Successful." : "Saving Failed."
        };
        return Json(message);
    }

    [HttpGet]
    [ActionName("Edit")]
    public async Task<IActionResult> BlogEdit(int id)
    {
        var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }
        return View("BlogEdit", item);
    }

    [HttpPost]
    [ActionName("Update")]
    public async Task<IActionResult> BlogUpdate(int id, BlogModel blog)
    {
        var item = await _db.Blogs
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.BlogId == id);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        item.BlogTitle = blog.BlogTitle;
        item.BlogAuthor = blog.BlogAuthor;
        item.BlogContent = blog.BlogContent;

        _db.Entry(item).State = EntityState.Modified; // Need to add due to adding AsNoTracking

        var result = await _db.SaveChangesAsync();
        //return Redirect("/Blog");
        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Updating Successful." : "Updating Failed."
        };
        return Json(message);
    }

    [HttpPost]
    [ActionName("Delete")]
    public async Task<IActionResult> BlogDelete(BlogModel blog)
    {
        var item = await _db.Blogs.FirstOrDefaultAsync(x => x.BlogId == blog.BlogId);
        if (item is null)
        {
            return Redirect("/Blog");
        }

        _db.Blogs.Remove(item);
        var result = await _db.SaveChangesAsync();
        var message = new MessageModel()
        {
            IsSuccess = result > 0,
            Message = result > 0 ? "Deleting Successful." : "Deleting Failed."
        };
        return Json(message);
    }
}
