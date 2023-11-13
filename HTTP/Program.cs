using System.Net.Http.Headers;
using System.Net.Mime;

namespace HTTP
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //string result = HttpClient.Get("todos/").Result;
            //Console.WriteLine(result);

            HttpResponseMessage response = HttpClient.GetResponse("todos/").Result;
            HttpContent content = response.Content;
            HttpHeaders headers = content.Headers;
            foreach(var header in headers)
            {
                Console.WriteLine(header.Key);
                foreach(var value in header.Value)
                {
                    Console.WriteLine($"\t{header.Key}: {value}");
                }
            }
        }
    }
}