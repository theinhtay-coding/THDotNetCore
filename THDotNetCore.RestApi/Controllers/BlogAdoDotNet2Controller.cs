using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Data.SqlClient;
using THDotNetCore.RestApi.Models;
using THDotNetCore.Shared;

namespace THDotNetCore.RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogAdoDotNet2Controller : ControllerBase
    {
        private readonly AdoDotNetService _adoDotNetService = new AdoDotNetService(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);

        [HttpGet]
        public IActionResult GetBlogs()
        {
            string query = @"SELECT [BlogId]
                              ,[BlogTitle]
                              ,[BlogAuthor]
                              ,[BlogContent]
                          FROM [dbo].[Tbl_Blog]";
            var lst = _adoDotNetService.Query<BlogModel>(query);
            return Ok(lst);
        }

        [HttpGet("{id}")]
        public IActionResult GetBlog(int id)
        {
            string query = "select * from tbl_blog where BlogId = @BlogId";

            //AdoDotNetParameter[] parameters = new AdoDotNetParameter[1];
            //parameters[0] = new AdoDotNetParameter("@BlogId", id);
            //var lst = _adoDotNetService.Query<BlogModel>(query, parameters);

            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(query, new AdoDotNetParameter("@BlogId", id));

            //SqlConnection connection = new SqlConnection(ConnectionStrings.SqlConnectionStringBuilder.ConnectionString);
            //connection.Open();

            //SqlCommand cmd = new SqlCommand(query, connection);
            //cmd.Parameters.AddWithValue("@BlogId", id);
            //SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(cmd);
            //DataTable dt = new DataTable();
            //sqlDataAdapter.Fill(dt);
            //connection.Close();

            if (item is null)
            {
                return NotFound("No data found.");
            }

            return Ok(item);
        }

        [HttpPost]
        public IActionResult CreateBlog(BlogModel blog)
        {
            string query = @"INSERT INTO [dbo].[Tbl_Blog]
                                   ([BlogTitle]
                                   ,[BlogAuthor]
                                   ,[BlogContent])
                             VALUES
                                   (@BlogTitle
                                   ,@BlogAuthor
                                   ,@BlogContent)";

            int result = _adoDotNetService.Execute(query,
           new AdoDotNetParameter("@BlogTitle", blog.BlogTitle),
           new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor),
           new AdoDotNetParameter("@BlogContent", blog.BlogContent)
       );

            string message = result > 0 ? "Saved Successful." : "Saving Failed";
            return Ok(message);
        }

        [HttpPut]
        public IActionResult UpdateBlog(int id, BlogModel blog)
        {
            return Ok();
        }

        [HttpPatch("{id}")]
        public IActionResult PatchBlog(int id, BlogModel blog)
        {
            string queryById = "select * from tbl_blog where BlogId = @BlogId";
            var item = _adoDotNetService.QueryFirstOrDefault<BlogModel>(queryById, new AdoDotNetParameter("@BlogId", id));

            if (item is null)
            {
                return NotFound("No data found.");
            }

            List<AdoDotNetParameter> lstParameter = new List<AdoDotNetParameter>();
            string conditions = string.Empty;
            if (!string.IsNullOrEmpty(blog.BlogTitle))
            {
                conditions += " [BlogTitle] = @BlogTitle, ";
                lstParameter.Add(new AdoDotNetParameter("@BlogTitle", blog.BlogTitle));
            }

            if (!string.IsNullOrEmpty(blog.BlogAuthor))
            {
                conditions += " [BlogAuthor] = @BlogAuthor, ";
                lstParameter.Add(new AdoDotNetParameter("@BlogAuthor", blog.BlogAuthor));
            }

            if (!string.IsNullOrEmpty(blog.BlogContent))
            {
                conditions += " [BlogContent] = @BlogContent, ";
                lstParameter.Add(new AdoDotNetParameter("@BlogContent", blog.BlogContent));
            }

            if (conditions.Length == 0)
            {
                var response = new { IsSuccess = false, Message = "No data found." };
                return NotFound(response);
            }
            lstParameter.Add(new AdoDotNetParameter("@BlogId", id));

            conditions = conditions.Substring(0, conditions.Length - 2);
            string query = $@"UPDATE [dbo].[Tbl_Blog] SET {conditions} WHERE BlogId = @BlogId";

            int result = _adoDotNetService.Execute(query,
                lstParameter.ToArray()
            );

            string message = result > 0 ? "Updating Successful." : "Updating Failed.";
            return Ok(message);
        }

        [HttpDelete]
        public IActionResult DeleteBlog(int id)
        {
            return Ok();
        }
    }
}
