using Microsoft.Playwright;
using NUnit.Framework;
using RestSharp;
using SpecFlow.Internal.Json;

namespace SpecflowGroupExcercise
{
    public class SimpleApiRequest
    {
        [Test]//RestSharp example
        public async Task GETAllBOOKS()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("BookStore/v1/Books", Method.Get);

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

        [Test]//RestSharp example
        public async Task GETASINGLEleBOOK()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("BookStore/v1/Book?ISBN=9781449325862", Method.Get);
            var response = await client.ExecuteAsync<Book>(request);

            //Check if response is ok
            if (response.IsSuccessful == true)
            {
                //Nunit Assertion
                Assert.Multiple(() =>
                {
                    Assert.AreEqual("OK", response.StatusCode.ToString());
                    Assert.AreEqual(200, (int)response.StatusCode);
                    Assert.AreEqual(200, Convert.ToInt32(response.StatusCode));
                    Assert.AreEqual("9781449325862", response.Data?.isbn);
                    Assert.AreEqual("Git Pocket Guide", response.Data?.title);
                    Assert.AreEqual("A Working Introduction", response.Data?.subTitle);
                    Assert.AreEqual("Richard E. Silverman", response.Data?.author);
                });

                //Fluent Assertion
                response.StatusCode.ToString().Should().Be("OK");
                Convert.ToInt32(response.StatusCode).Should().Be(200);
                response.Data?.isbn.Should().Be("9781449325862");
            }
            else
            {
                throw new Exception($"Response is not successfull, Response is : {response.StatusCode}");
            }
        }

        [Test]//RestSharp example
        public async Task POSTCREAT_NEWUSER()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("Account/v1/User", Method.Post);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddHeader("Content-Type", "application/json");
            request.RequestFormat = DataFormat.Json;
            //Example1 - using AddParameter
            //request.AddParameter("userName", "Jo01");
            //request.AddParameter("password", "Password001!");

            //or Example2 - using anonymouse type
            //request.AddJsonBody(new
            //{
            //    userName = "Jo2" + new Random().Next(1, 99),
            //    password = "Password001!"
            //});

            //or Example1 - using class type
            //request.AddParameter("application/json", request.AddJsonBody(new PostRequestModelNewUser
            //{
            //     userName = "Joe06" + new Random().Next(1, 99),
            //     password = "Password001!"
            //}),
            //    ParameterType.RequestBody);

            //request.AddJsonBody(new PostRequestModelNewUser2(
            //    "Jo2" + new Random().Next(1, 99), "Password001!"));

            request.AddJsonBody(new PostRequestModelNewUser
            {
                userName = "Jo2" + new Random().Next(1, 99),
                password = "Password001!"
            });
            RestResponse response = await client.ExecuteAsync(request);
            if (response.IsSuccessful == true)
            {
                Assert.True(response.StatusCode.ToString() == "Created");
            }
        }

        public class PostRequestModel
        {
            public string userID { get; set; }
            public string username { get; set; }
            public List<object> books { get; set; }
        }

        public record PostRequestModel2(string userID, string username, List<object> books) { }
        public record PostRequestModelNewUser2(string userName, string password) { }

        public class PostRequestModelNewUser
        {
            public string userName { get; set; }
            public string password { get; set; }
        }


        [Test]//Playwright API example
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
            //Alternatively use the below
            //var data = await request.JsonAsync();
            //data.Value.Deserialize<BooksResponseModel>();
            //or
            //var data = await request.TextAsync();
            //var jsonValue = data.FromJson<BooksResponseModel>();
            //or
            var responseText = await browser.GetAsync("BookStore/v1/Books")
                .Result.TextAsync();
            var jsonValue = responseText.FromJson<BooksResponseModel>();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("9781449325862", response.books[0].isbn);
                Assert.AreEqual("Git Pocket Guide", response.books[0].title);
                Assert.AreEqual("A Working Introduction", response.books[0].subTitle);
                Assert.AreEqual("Richard E. Silverman", response.books[0].author);
            });
        }

        [Test]//Playwright API example
        public async Task GETSINGLEBOOKPlaywright()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.APIRequest
            .NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://demoqa.com/",
            });
            var request = await browser.GetAsync("BookStore/v1/Book?ISBN=9781449325862");
            //var response = await request.JsonAsync<Book>();
            //Alternatively use the below
            //var resp = await request.JsonAsync();
            //var response = resp.Value.Deserialize<Book>();
            //or
            //var resp = await request.TextAsync();
            //var response = resp.FromJson<Book>();
            //or
            var resp = request.TextAsync();
            var response = resp.Result.FromJson<Book>();

            Assert.Multiple(() =>
            {
                Assert.AreEqual("9781449325862", response?.isbn);
                Assert.AreEqual("Git Pocket Guide", response?.title);
                Assert.AreEqual("A Working Introduction", response?.subTitle);
                Assert.AreEqual("Richard E. Silverman", response?.author);
            });
        }

        [Test]//RestSharp example
        public async Task PlaywrightPOSTCREAT_NEWUSER()
        {
            var playwright = await Playwright.CreateAsync();
            var browser = await playwright.APIRequest
            .NewContextAsync(new APIRequestNewContextOptions
            {
                BaseURL = "https://demoqa.com/",
            });
            var user = "Joe10" + new Random().Next(1, 99);
            var request = await browser.PostAsync("Account/v1/User", 
                new APIRequestContextOptions
                {
                     DataObject = new
                     {
                         userName = user,
                         Password = "Password001!"
                     }
                });

            var response = await request.JsonAsync<PostRequestModel>();

            Assert.True(response.userID.ToString() != null);
            Assert.True(response.username.ToString() == user);
            Assert.True(response.books.FirstOrDefault() == null);
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
