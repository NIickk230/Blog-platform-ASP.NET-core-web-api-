using System.Reflection.Metadata;

namespace Blog_Platform.Models
{
    public class BlogPfModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public BlogPfModel(string author, string title, string description, int id)
        {
            Id = id;
            Author = author;
            Title = title;
            Description = description;
        }
        
        public BlogPfModel SearchBlog(List<BlogPfModel> blogs, int id)
        {
            BlogPfModel Blog = null;
            foreach (var b in blogs)
            {
                if (b.Id == Id)
                {
                    Blog = b;
                }
            }
            return Blog;
        }

        public BlogPfModel editBlog(BlogPfModel blog, string author, string title, string description)
        {
            blog.Author = author;
            blog.Title = title;
            blog.Description = description;
            return blog;
        }

    }
}
