namespace moment3
{
    internal class Post
    {
        // Public properties to get or set the name and message of the post
        public string Name { get; set; }
        public string Message { get; set; }

        // Parameterless constructor for deserialization purposes
        public Post()
        {
            Name = string.Empty;
            Message = string.Empty;
        }

        // Constructor for creating a post with name and message
        public Post(string name, string message)
        {
            Name = name;
            Message = message;
        }
    }
}
