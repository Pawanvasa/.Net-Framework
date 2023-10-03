// See https://aka.ms/new-console-template for more information
Console.WriteLine("Hello, World!");
int[] nums = {1,2,3,4 };
int[] res = new int[nums.Length];
res[0] = nums[0];
for (int i = 1; i < nums.Length; i++)
{
    int temp = nums[i];
    res[i] = temp + res[i - 1];
}

foreach(int n in res)
{
    Console.WriteLine(n);
}