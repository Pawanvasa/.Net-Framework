//1. When you post a message on Facebook, depending on the number of people who like your post,
//Facebook displays different information.

/*If no one likes your post, it doesn't display anything.
If only one person likes your post, it displays: [Friend's Name] likes your post.
If two people like your post, it displays: [Friend 1] and[Friend 2] like your post.
If more than two people like your post, it displays: [Friend 1], [Friend 2] and[Number of Other People] others 
like your post.
Write a program and continuously ask the user to enter different names, 
until the user presses Enter (without supplying a name).
Depending on the number of names provided, display a message based on the above pattern.
*/

List<string> userNames = new List<string>();
String? names;
do
{
    Console.WriteLine("Enter Names");
    names = Console.ReadLine();
    if (names != "")
    {
        userNames.Add(names);
    }
}
while (names != "");

if (userNames.Count == 1)
{
    Console.WriteLine($"{userNames[0]} likes your post");
}
else if (userNames.Count == 2)
{
    Console.WriteLine($"{userNames[0]} and {userNames[1]} likes your post");
}
else
{
    Console.WriteLine($"{userNames[0]}, {userNames[1]} and {userNames.Count - 2} other People");
}
Console.WriteLine("thanks");