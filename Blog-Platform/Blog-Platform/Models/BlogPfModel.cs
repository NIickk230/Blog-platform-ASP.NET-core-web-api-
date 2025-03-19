namespace Blog_Platform.Models
{
    public class BlogPfModel
    {
        private string Author { get; set; }
        private string Title { get; set; }
        private string Description { get; set; }

        public BlogPfModel(string author, string title, string description)
        {
            Author = author;
            Title = title;
            Description = description;
        }

    }
}
