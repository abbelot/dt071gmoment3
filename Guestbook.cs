using System.Text.Json;

namespace moment3
{
    internal class Guestbook
    {
        // Private list that holds all posts
        private List<Post> posts;
        private string fileName;

        // Constructor for creating new guestbook
        public Guestbook(string fileName)
        {
            posts = new List<Post>();
            this.fileName = fileName;
        }

        // Method to add post and save to file
        public void AddPost(string name, string message)
        {
            posts.Add(new Post(name, message));
            SaveToFile();
        }

        // Method to remove a post at a specified index and saves updated list
        public void RemovePost(int index)
        {
            if (index >= 0 && index < posts.Count)
            {
                posts.RemoveAt(index);
                SaveToFile();
            }
        }

        // Display all posts in the console
        public void DisplayPosts()
        {
            for (int i = 0; i < posts.Count; i++)
            {
                Console.WriteLine($"[{i}] {posts[i].Name} - {posts[i].Message}");
            }
        }

        // Serialize the list of posts to JSON and writes it to a file
        public void SaveToFile()
        {
            // Serialize post and save to json file
            string json = JsonSerializer.Serialize(posts);
            File.WriteAllText(fileName, json);
        }

        // Loads and deserializes the list of posts from JSON file if it exists
        public void LoadFromFile()
        {
            if (File.Exists(fileName))
            {
                string json = File.ReadAllText(fileName);
                posts = JsonSerializer.Deserialize<List<Post>>(json) ?? new List<Post>();
            }
        }
    }
}
