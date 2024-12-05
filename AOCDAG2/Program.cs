using System.Runtime.InteropServices;
using System.Text;

class Program
{
    static void Main()
    {
        string filepath = "D:\\Users\\1004121\\AOC\\AOCDAG2\\test.txt";
        string text = File.ReadAllText(filepath, Encoding.UTF8);

        Console.WriteLine(text);

        foreach (var line in text.Split('\n'))
        {
            Console.WriteLine(line);
            int[] array = line.Split(' ').Select(int.Parse).ToArray();

            for (int i = 0; i < array.Length - 1; i++)
            {
                Console.WriteLine(i);
                int diff = array[i] - array[i+1];
                Console.WriteLine(diff);
            }
        }
    }
}