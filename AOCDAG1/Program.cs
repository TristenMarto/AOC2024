// See https://aka.ms/new-console-template for more information
using System;
using System.Diagnostics;
using System.IO;
using Microsoft.Win32.SafeHandles;

class Program
{
    static void Main()
    {
        string filepath = "D:\\Users\\1004121\\AOC\\AOCDAG1\\dag1.csv";
        List<int> leftList = new List<int>();
        List<int> rightList = new List<int>();
        Dictionary<int,int> DictOfOccurences;

        ParseLines(filepath, leftList, rightList);

        int[] leftArray = leftList.ToArray();
        int[] rightArray = rightList.ToArray();

        Array.Sort(leftArray);
        Array.Sort(rightArray);

        HashSet<int> uniqueRightValues = new HashSet<int>(rightArray);

        Console.WriteLine("Lenght: " + leftArray.Length);
        Console.WriteLine("Lenght: " + rightArray.Length);

        CalculateDifference(leftArray, rightArray);

        DictOfOccurences = CountOccurences(rightArray);

        foreach (var kvp in DictOfOccurences)
        {
            Console.WriteLine($"Key: {kvp.Key}, Value: {kvp.Value}");
        }

        int similarityScore = 0;
        foreach (var leftNumber in leftArray)
        {
            if (DictOfOccurences.ContainsKey(leftNumber))
            {
            int sim = leftNumber * DictOfOccurences[leftNumber];
            Console.WriteLine("num diff: " + sim);
            similarityScore += sim;
            }
        }
        Console.WriteLine(similarityScore);
    }

    private static void CalculateDifference(int[] leftArray, int[] rightArray)
    {
        int difference = 0;

        for (int i = 0; i < leftArray.Length; i++)
        {
            int diff = leftArray[i] - rightArray[i];
            Console.WriteLine(Math.Abs(diff));
            difference += Math.Abs(diff);
        }

        Console.WriteLine("TOtal difference: " + difference);
    }

    private static void ParseLines(string filepath, List<int> leftList, List<int> rightList)
    {
        string line;
        using (StreamReader sr = new StreamReader(filepath))
        {
            while ((line = sr.ReadLine()) != null)
            {
                string[] values = line.Split('\n');

                foreach (var value in values)
                {
                    Console.WriteLine("----------------------");
                    Console.WriteLine("newLine");
                    Console.WriteLine("----------------------");
                    string[] numbers = value.Split("   ");
                    leftList.Add(int.Parse(numbers[0]));
                    rightList.Add(int.Parse(numbers[1]));
                    foreach (var num in numbers)
                    {
                        Console.WriteLine("value x " + num + ' ');
                    }
                }
                Console.WriteLine();
            }
        }
    }

    private static Dictionary<int, int> CountOccurences(int[] array)
    {
        Dictionary<int, int> occDict = new Dictionary<int, int>();
        foreach (var num in array)
        {
            if (occDict.ContainsKey(num))
            {
                occDict[num]++;
            }
            else
            {
                occDict[num] = 1;
            }
        }

        return occDict;
    }
}