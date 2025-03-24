using System.Reflection.Metadata;
using Blog_Platform.Models;
using Microsoft.AspNetCore.Mvc;

namespace Blog_Platform.Controllers
{
    [ApiController]
    [Route("api/Blogs")]
    public class BlogController : Controller
    {
        private static List<BlogPfModel> Blogs = new List<BlogPfModel>();
        private static int blogId = 1;

        [HttpGet]
        public IActionResult GetBlog()
        {
            return Ok(Blogs);
        }

        [HttpPost]
        public IActionResult CreateBlog([FromBody] BlogPfModel Blog)
        {
            if (Blog == null || string.IsNullOrEmpty(Blog.Title) || string.IsNullOrEmpty(Blog.Author)){
                return BadRequest("title and author are requiered");
            }

            Blog.Id = blogId++;
            Blogs.Add(Blog);
            return CreatedAtAction(nameof(GetBlog), new { id = Blog.Id }, Blog);
        }

        [HttpDelete("{Id}")]
        public IActionResult DeleteBlog(int Id)
        {
            BlogPfModel Blog = null;
            foreach(var b in Blogs)
            {
                if(b.Id == Id)
                {
                    Blog = b;
                    break;
                }
            }

            if (Blog == null)
            {
                return NotFound();
            }

            Blogs.Remove(Blog);
            return NoContent();
        }

        [HttpPost("")]
        public IActionResult editBlog(string author, string titile, string description)
        {

        }
    }
}
