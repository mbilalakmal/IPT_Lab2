using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace k173669_Lab2_Q2
{
    class Program
    {
        static void Main(string[] args)
        {
            /// Length of List
            int length = 1000000;
            /// Minimum value an element can have
            int min = 0;
            /// Maximum value an element can have
            int max = 1000;
            /// The value to find in the List
            int searchNumber = 50;

            /// Both methods will use the same List for fairness
            List<int> numbers = GenerateRandomList(length, min, max);

            /// Single Threaded Method
            /// 

            var stopWatch = Stopwatch.StartNew();

            var indexes = SearchOccurencesInList(numbers, searchNumber);

            stopWatch.Stop();

            Console.WriteLine($"{indexes.Count} Occurrences Found.");
            Console.WriteLine($"Single Threaded Execution Time: {stopWatch.Elapsed}");

            /// Multiple Threads Method
            /// 
            int numberOfThreads = 5;
            int lengthPerThread = length / numberOfThreads;

            List<ThreadWorker> threadWorkers = new List<ThreadWorker>();
            for(var index = 0; index < numberOfThreads; ++index)
            {
                ThreadWorker threadWorker = new ThreadWorker(
                    numbers.GetRange(index * lengthPerThread, lengthPerThread),
                    searchNumber,
                    new ResultCallback(ResultCallback)
                    );
                threadWorkers.Add(threadWorker);
            }

            List<Thread> threads = new List<Thread>();
            for(var index = 0; index < numberOfThreads; ++index)
            {
                threads.Add(new Thread(new ThreadStart(
                    threadWorkers[index].SearchAndInvokeCallback
                    )));
            }

            stopWatch.Restart();

            Console.WriteLine("Starting Threads");
            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
            Console.WriteLine("Threads Have Completed");

            stopWatch.Stop();

            Console.WriteLine($"{indexes.Count} Occurrences Found.");
            Console.WriteLine($"Multi Threaded Execution Time: {stopWatch.Elapsed}");

        }

        public static List<int> GenerateRandomList(int length, int minimum, int maximum)
        {
            Random random = new Random();
            List<int> numbers = Enumerable.Repeat(0, length).
                Select(index => random.Next(minimum, maximum)).ToList();

            return numbers;
        }

        public static List<int> SearchOccurencesInList(List<int> numbers, int searchNumber)
        {
            List<int> indexes = new List<int>();

            int searchFromIndex = 0;
            int foundIndex = -1;

            do
            {
                foundIndex = numbers.IndexOf(searchNumber, searchFromIndex);

                if (foundIndex == -1) break;

                indexes.Add(foundIndex);
                searchFromIndex = foundIndex + 1;
            } while (foundIndex != -1 && searchFromIndex < numbers.Count);

            return indexes;
        }

        public static void ResultCallback(List<int> indexes)
        {
            Console.WriteLine("Thread Completed.");
        }
    }

    public class ThreadWorker
    {
        private List<int> numbers;
        private int searchNumber;

        private ResultCallback resultCallback;

        public ThreadWorker(List<int> numbers, int searchNumber, ResultCallback resultCallback) {
            this.numbers = numbers;
            this.searchNumber = searchNumber;
            this.resultCallback = resultCallback;
        }

        public void SearchAndInvokeCallback()
        {
            var indexes = Program.SearchOccurencesInList(numbers, searchNumber);
            resultCallback(indexes);
        }
    }

    public delegate void ResultCallback(List<int> indexes);
}
