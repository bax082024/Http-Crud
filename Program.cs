using System;
using System.ComponentModel.DataAnnotations;
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

    // GET : 
    private static async Task GetPostAsync()
    {
      Console.WriteLine("GET Request:");
      HttpResponseMessage response = await client.GetAsync(url + "1");
      response.EnsureSuccessStatusCode();

      string responseBody = await response.Content.ReadAsStringAsync();
      Console.WriteLine(responseBody);
      Console.WriteLine();
    }

    // POST :
    private static async Task CreatePostAsync()
    {
      Console.WriteLine("POST Request:");
      var newPost = new { title = "foo", body = "bar", userId = 1};
      string json = JsonSerializer.Serialize(newPost);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

      HttpResponseMessage response = await client.PostAsync(url, content);
      response.EnsureSuccessStatusCode();

      string responseBody = await response.Content.ReadAsStringAsync();
      Console.WriteLine(responseBody);
      Console.WriteLine();

    }

    private static async Task UpdatePostAsync()
    {
      Console.WriteLine("UPDATE Request:");
      var UpdatePost = new { id = 1, title = "updated foo", body = "updated bar", userId = 1};
      string json = JsonSerializer.Serialize(UpdatePost);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

      HttpResponseMessage response = await client.PutAsync(url + "/1", content);

      string responseBody = await response.Content.ReadAsStringAsync();
      Console.WriteLine(responseBody);
      Console.WriteLine();
      
    }

    private static async Task PatchPostAsync()
    {
      Console.WriteLine("PATCH Request:");
      var partialUpdate = new { title = "patched title" };
      string json = JsonSerializer.Serialize(partialUpdate);
      StringContent content = new StringContent(json, Encoding.UTF8, "application/json");

      HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Patch, url + "/1")
      {
        Content = content
      };

      HttpResponseMessage response = await client.SendAsync(request);
      response.EnsureSuccessStatusCode();

      
    }


  }

}