using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sliding_Window_Sum
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = GetNumberList();
            int windowSize = GetWindowSize(numbers.Count);

            // Calculate and display sliding window sums
            List<int> windowSums = CalculateWindowSums(numbers, windowSize);

            Console.WriteLine("\nSliding Window Sums:");
            Console.WriteLine(string.Join(", ", windowSums));
        }
        static List<int> GetNumberList()
        {
            List<int> numbers = new List<int>();
            Console.WriteLine("\nEnter at least 10 integers (one per line, enter 'done' when finished):");

            while (numbers.Count < 10 || !Console.ReadLine().Equals("done", StringComparison.OrdinalIgnoreCase))
            {
                Console.Write($"Number {numbers.Count + 1}: ");
                string input = Console.ReadLine();

                if (input.Equals("done", StringComparison.OrdinalIgnoreCase) && numbers.Count >= 10)
                    break;

                if (int.TryParse(input, out int num))
                {
                    numbers.Add(num);
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter an integer.");
                }
            }

            return numbers;
        }
        static int GetWindowSize(int listSize)
        {
            int k;
            while (true)
            {
                Console.Write("\nEnter window size (k): ");
                if (int.TryParse(Console.ReadLine(), out k) && k > 0 && k <= listSize)
                {
                    return k;
                }
                Console.WriteLine($"Invalid window size. Please enter a positive integer <= {listSize}.");
            }
        }

        static List<int> CalculateWindowSums(List<int> numbers, int k)
        {
            List<int> sums = new List<int>();
            int currentSum = numbers.Take(k).Sum();
            sums.Add(currentSum);

            for (int i = k; i < numbers.Count; i++)
            {
                currentSum += numbers[i] - numbers[i - k];
                sums.Add(currentSum);
            }

            return sums;
        }
    }
}
