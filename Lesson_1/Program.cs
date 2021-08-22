using System;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace Lesson_1
{
    class Program
    {
        private HttpClient Client = new HttpClient();
        
        public static async Task Main(string[] args)
        {
            Program program = new Program();

            for (int i = 4; i <= 13; i++)
            {
                var task = new[]
                {
                    program.GetItems(i),
                };

                try
                {
                    var tasks = await Task.WhenAny(task);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        private async Task GetItems(int id)
        {
            string response = await Client.GetStringAsync($"https://jsonplaceholder.typicode.com/posts/{id}");
            Console.WriteLine(response);
            using (StreamWriter writer = new StreamWriter("path.txt", true))
            {
                await writer.WriteLineAsync(response);
            }
        }
        
        
    }
}