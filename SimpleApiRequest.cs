using FluentAssertions.Execution;
using Microsoft.Playwright;
using Newtonsoft.Json;
using NUnit.Framework;
using RestSharp;
using System.Security.Policy;

namespace SpecflowGroupExcercise
{
    public class SimpleApiRequest
    {
        [Test]
        public async Task GETAllBOOKS()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("BookStore/v1/Books", Method.Get);

            //var response = await client.ExecuteAsync(request);
            //Console.WriteLine(response.Content);

            var response = await client.ExecuteAsync<BooksResponseModel>(request);

            //Check if response is ok
            if (response.IsSuccessful == true)
            {
                //Nunit Assertion
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("OK", response.StatusCode.ToString());
                    Assert.AreEqual(200, (int)response.StatusCode);
                    Assert.AreEqual(200, Convert.ToInt32(response.StatusCode));
                    Assert.AreEqual("9781449325862", response.Data?.books[0].isbn);
                    Assert.AreEqual("Git Pocket Guide", response.Data?.books[0].title);
                    Assert.AreEqual("A Working Introduction", response.Data?.books[0].subTitle);
                    Assert.AreEqual("Richard E. Silverman", response.Data?.books[0].author);
                });

                //Fluent Assertion
                response.StatusCode.ToString().Should().Be("OK");
                Convert.ToInt32(response.StatusCode).Should().Be(200);
                response.Data?.books[0].isbn.Should().Be("9781449325862");
            }
            else
            {
                throw new Exception($"Response is not successfull, Response is : {response.StatusCode}");
            }
        }

        [Test]
        public async Task GETALLBOOKPlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.APIRequest
                .NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://demoqa.com/",
            });
            var request = await browser.GetAsync("BookStore/v1/Books");
            var response = await request.JsonAsync<BooksResponseModel>();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("9781449325862", response.books[0].isbn);
                Assert.AreEqual("Git Pocket Guide", response.books[0].title);
                Assert.AreEqual("A Working Introduction", response.books[0].subTitle);
                Assert.AreEqual("Richard E. Silverman", response.books[0].author);
            });

            //var response = await driver?.RequestContext?.GetAsync("BookStore/v1/Books")!;
            //var datas = await response.JsonAsync();
            //Console.WriteLine(datas);
            //string? jsonElement = null;
            //Assert.True(response.Ok);
            //foreach (var data in datas.Value.Deserialize<BooksResponseModel>()?.books!)
            //{
            //    if (data != null)
            //    {
            //        if (data.author == "Richard E. Silverman")
            //        {
            //            jsonElement = data.author;
            //            break;
            //        }
            //    }
            //}
            //using (new AssertionScope())
            //{
            //    Assert.NotNull(jsonElement);
            //    Assert.That(jsonElement, Is.EqualTo("Richard E. Silverman"));
            //}

        } 
    }

    public class Book
    {
        public string isbn { get; set; }
        public string title { get; set; }
        public string subTitle { get; set; }
        public string author { get; set; }
        public DateTime publish_date { get; set; }
        public string publisher { get; set; }
        public int pages { get; set; }
        public string description { get; set; }
        public string website { get; set; }
    }

    public class BooksResponseModel
    {
        public List<Book> books { get; set; }
    }
}
