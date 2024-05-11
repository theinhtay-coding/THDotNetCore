// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using THDotNetCore.ConsoleAppHttpClientExamples;

Console.WriteLine("Hello, World!");

//Console App - Client (Frontend)
//Asp.Net Core Web API - Servar (Backend)

//HttpClient client = new HttpClient();
//HttpResponseMessage response = await client.GetAsync("https://localhost:7132/api/Blog");
//if (response.IsSuccessStatusCode)
//{
//    string jsonStr = await response.Content.ReadAsStringAsync();
//    //Console.WriteLine(jsonStr);
//    List<BlogDto> lst = JsonConvert.DeserializeObject<List<BlogDto>>(jsonStr)!;

//    foreach(BlogDto model in lst)
//    {
//        Console.WriteLine(JsonConvert.SerializeObject(model));
//        //Console.WriteLine($"Id => {model.BlogId}");
//        //Console.WriteLine($"Title => {model.BlogTitle}");
//        //Console.WriteLine($"Author => {model.BlogAuthor}");
//        //Console.WriteLine($"Content => {model.BlogContent}");
//    }
//}

HttpClientExample example = new HttpClientExample();
await example.RunAsync();

Console.ReadLine();