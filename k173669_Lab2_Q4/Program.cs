using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace k173669_Lab2_Q4
{
    class Program
    {
        const string URL = "https://www.bing.com/";
        static void Main(string[] args)
        {
            Task task = new Task(FetchWebPageAsync);

            task.Start();

            /// Press Any Key - Main Thread is blocked, so the task can print to console
            Console.ReadKey(true);
            Console.WriteLine("Task Is Running");
        }

        public static async void FetchWebPageAsync()
        {
            HttpClient client = new();

            try
            {
                var response = await client.GetAsync(URL);
                var content = await response.Content.ReadAsStringAsync();

                Console.WriteLine(content);
            }
            catch (Exception exception) { Console.WriteLine(exception.ToString()); }

            
        }
    }
}
