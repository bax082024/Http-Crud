using System;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace HttpMethodsExample
{
  class Program
  {
    private static readonly HttpClient client = new HttpClient();
    private const string url = "https://jsonplaceholder.typicode.com/posts";

    static async Task Main(string[] args)
    {
      await GetPostAsync();
      await CreatePostAsync();
      await UpdatePostAsync();
      await PatchPostAsync();
      await DeletePostAsync();
    }

  }

}