namespace moment3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Instantiate a Guestbook object and load existing posts
            var guestbook = new Guestbook("guestbook.json");
            guestbook.LoadFromFile();

            // Flag to keep the application running
            bool running = true;

            // Main loop for the menu
            while (running)
            {
                // Clear console and print menu options
                Console.Clear();
                Console.WriteLine("AMANDAS GÄSTBOK\n\n");
                Console.WriteLine("1. Skriv i gästboken");
                Console.WriteLine("2. Ta bort inlägg\n");
                Console.WriteLine("X. Avsluta\n");

                // Display all current posts
                guestbook.DisplayPosts();

                // Read user choice from console
                string choice = Console.ReadLine();

                // Handle user input and navigate to the action
                switch (choice)
                {
                    case "1":
                        AddPost(guestbook);
                        break;
                    case "2":
                        RemovePost(guestbook);
                        break;
                    // Exit application with X or x
                    case "X":
                    case "x":
                        running = false;
                        break;
                    default:
                        // Handle invalid input
                        Console.WriteLine("Vänligen välj ett av alternativen.");
                        break;
                }

                // Pause the console if the application is still running
                if (running)
                {
                    Console.WriteLine("\nTryck på valfri tangent för att fortsätta...");
                    Console.ReadKey();
                }
            }
        }

        // Method to add post using the guestbook instance
        private static void AddPost(Guestbook guestbook)
        {
            Console.Write("Ange ditt namn: ");
            string name = Console.ReadLine();

            Console.Write("Skriv ditt inlägg: ");
            string message = Console.ReadLine();

            // Validate input and add post
            if (!string.IsNullOrWhiteSpace(name) && !string.IsNullOrWhiteSpace(message))
            {
                guestbook.AddPost(name, message);
            }
            else
            {
                // Handle case where name or message is empty
                Console.WriteLine("Namn och inlägg får inte vara tomt.");
            }
        }

        // Method to remove a post using the guestbook instance
        private static void RemovePost(Guestbook guestbook)
        {
            Console.Write("Ange index för inlägget som ska tas bort: ");

            // Parse the input index and remove the post if valid
            if (int.TryParse(Console.ReadLine(), out int index))
            {
                guestbook.RemovePost(index);
                Console.WriteLine("Inlägget har tagits bort.");
            }
            else
            {
                // Handle invalid index input
                Console.WriteLine("Ogiltigt index.");
            }
        }
    }
}