using Exercise02;
Post post = new Post();

post.title = "C# Intermediate";
post.description = "Is this code suitable for its purpose? Is there a better way to handle this that means less (or no) reliance on the catch and retry mechanic?";
post.createdDateTime = DateTime.Now;
int choice;
do
{
    Console.WriteLine("Enter your Choice");
    Console.WriteLine("1. Up_vote");
    Console.WriteLine("2. Down_vote");
    Console.WriteLine("3. Print Current vote value");
    choice = Convert.ToInt32(Console.ReadLine());
    switch (choice)
    {
        case 1:
            post.up_vote();
            break;
        case 2:
            post.down_vote();
            break;
        case 3:
            Console.WriteLine($"Title : {post.title}");
            Console.WriteLine ($"Descriptuon : {post.description}");
            Console.WriteLine($"Created Time and date : {post.createdDateTime}");
            Console.WriteLine($"Current Vote Value : {post.currentVoteValue}");
            Console.WriteLine();
            break;
    }

} while (true);