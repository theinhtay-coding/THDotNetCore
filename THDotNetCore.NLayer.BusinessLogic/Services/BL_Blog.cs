using Microsoft.EntityFrameworkCore;
using THDotNetCore.NLayer.DataAccess.Services;
using THDotNetCore.NLayer.DataAccess.Models;

namespace THDotNetCore.NLayer.BusinessLogic.Services
{
    public class BL_Blog
    {
        private readonly DA_Blog _da_Blog;

        public BL_Blog()
        {
            _da_Blog = new DA_Blog();
        }

        public List<BlogModel> GetBlogs()
        {
            List<BlogModel> lst = _da_Blog.GetBlogs();
            return lst;
        }

        public BlogModel GetBlog(int id)
        {
            var model = _da_Blog.GetBlog(id);
            return model;
        }

        public int CreateBlog(BlogModel requestModel)
        {
            var result = _da_Blog.CreateBlog(requestModel);
            return result;
        }

        public int UpdateBlog(int id, BlogModel requestModel)
        {
            var result = _da_Blog.UpdateBlog(id, requestModel);
            return result;
        }

        public int PatchBlog(int id, BlogModel requestModel)
        {
            var result = _da_Blog.PatchBlog(id, requestModel);
            return result;
        }

        public int DeleteBlog(int id)
        {
            var result = _da_Blog.DeleteBlog(id);
            return result;
        }
    }
}
