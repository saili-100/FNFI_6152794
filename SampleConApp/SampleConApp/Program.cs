namespace SampleConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the name");
            string name = Console.ReadLine();

            Console.WriteLine("Enter the address");
            string address = Console.ReadLine();
            Console.WriteLine($"The Inputs are as follows:\n The name entered is {name} The Address is {address}");
        }
    }
}
