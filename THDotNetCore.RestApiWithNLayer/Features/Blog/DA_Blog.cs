using System.Reflection.Metadata;
using THDotNetCore.RestApiWithNLayer.Db;
using THDotNetCore.RestApiWithNLayer.Models;

namespace THDotNetCore.RestApiWithNLayer.Features.Blog
{
    public class DA_Blog
    {
        private readonly AppDbContext _context;
        public DA_Blog()
        {
            _context = new AppDbContext();
        }

        public List<BlogModel> GetBlogs()
        {
            List<BlogModel> lst = _context.Blogs.ToList();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var model = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            return model;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            _context.Blogs.Add(requestModel);
            var result = _context.SaveChanges();
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            item.BlogTitle = requestModel.BlogTitle;
            item.BlogAuthor = requestModel.BlogAuthor;
            item.BlogContent = requestModel.BlogContent;

            //_context.Blogs.Update(requestModel);
            var result = _context.SaveChanges();
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            if (!string.IsNullOrEmpty(requestModel.BlogTitle))
            {
                item.BlogTitle = requestModel.BlogTitle;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogAuthor))
            {
                item.BlogAuthor = requestModel.BlogAuthor;
            }
            if (!string.IsNullOrEmpty(requestModel.BlogContent))
            {
                item.BlogContent = requestModel.BlogContent;
            }

            var result = _context.SaveChanges();
            return result;
        }

        public int DeleteBlog(int id)
        {
            var item = _context.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null) return 0;

            _context.Blogs.Remove(item);
            var result = _context.SaveChanges();
            return result;
        }
    }
}
