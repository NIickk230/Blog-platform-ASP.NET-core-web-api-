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
        


    }
}
