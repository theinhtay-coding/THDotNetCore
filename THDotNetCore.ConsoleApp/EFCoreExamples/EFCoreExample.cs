using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using THDotNetCore.ConsoleApp.Dtos;

namespace THDotNetCore.ConsoleApp.EFCoreExamples
{
    public class EFCoreExample
    {
        public readonly AppDbContext db = new AppDbContext();

        public void Run()
        {
            Read();
            //Edit(10);
            //Create("title", "author", "content");
            //Update(10, "title1", "author1", "content1");
            //Delete(11);
        }

        public void Read()
        {
            List<BlogDto> lst = db.Blogs.ToList();

            foreach (BlogDto blog in lst)
            {
                Console.WriteLine(blog.BlogId);
                Console.WriteLine(blog.BlogTitle);
                Console.WriteLine(blog.BlogAuthor);
                Console.WriteLine(blog.BlogContent);
                Console.WriteLine("-----------------------------");
            }
        }

        public void Edit(int id)
        {
            //db.Blogs.FirstOrDefault(x => x.Equals(id));
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            Console.WriteLine(item.BlogId);
            Console.WriteLine(item.BlogTitle);
            Console.WriteLine(item.BlogAuthor);
            Console.WriteLine(item.BlogContent);
        }

        public void Create(string title, string author, string content)
        {
            var item = new BlogDto
            {
                BlogTitle = title,
                BlogAuthor = author,
                BlogContent = content
            };
            db.Blogs.Add(item);
            int result = db.SaveChanges();

            string message = result > 0 ? "Saved Successful." : "Saving Failed";
            Console.WriteLine(message);
        }

        public void Update(int id, string title, string author, string content)
        {
            //var item = db.Blogs.AsNoTracking().FirstOrDefault(x => x.BlogId == id);
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }

            item.BlogTitle = title;
            item.BlogAuthor = author;
            item.BlogContent = content;

            int result = db.SaveChanges();
            string message = result > 0 ? "Updated Successful." : "Updated Failed";
            Console.WriteLine(message);
        }

        public void Delete(int id)
        {
            var item = db.Blogs.FirstOrDefault(x => x.BlogId == id);
            if (item is null)
            {
                Console.WriteLine("No Data Found");
                return;
            }
            db.Blogs.Remove(item);
            int result = db.SaveChanges();
            string message = result > 0 ? "Deleted Successful." : "Deleted Failed";
            Console.WriteLine(message);
        }
    }
}
