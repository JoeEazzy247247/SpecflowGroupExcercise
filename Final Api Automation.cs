using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using RestSharp;

namespace SpecflowGroupExcercise
{
    public class Final_Api_Automation
    {
        [Test]
        public async Task CreateNewUserFinal()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("Account/v1/User", 
                Method.Post);
            //request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            //request.AddParameter("userName", "Ma01" + new Random().Next(1, 999));
            //Example 1
            //request.AddParameter("userName", "Ma01" + 
            //    DateTime.Now.ToString("yyMMddHHMMssfff"));
            //request.AddParameter("password", "Password001!");

            //Example 2
            //request.AddJsonBody(new
            //{
            //    userName = "Jo2" + new Random().Next(1, 999),
            //    password = "Password001!"
            //});

            //Example 3
            //var payload = new
            //{
            //    userName = "Jo2" + new Random().Next(1, 999),
            //    password = "Password001!"
            //};
            //request.AddParameter("application/json", payload, ParameterType.RequestBody);

            //Example 4
            //request.AddJsonBody(new PostRequestModelNewUser
            //{
            //    userName = "Jo2" + new Random().Next(1, 999),
            //    password = "Password001!"
            //});

            request.AddJsonBody(new PostRequestModelNewUser2
            (
                "Jo2" + new Random().Next(1, 999),
                "Password001!"
            ));
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);
        }

        public record PostRequestModelNewUser2(string userName, string password) { }

        public class PostRequestModelNewUser
        {
            public string userName { get; set; }
            public string password { get; set; }
        }

        [Test]
        public async Task LoginWithApi()
        {
            var options = new RestClientOptions()
            {
                BaseUrl = new Uri("https://demoqa.com/"),
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("Account/v1/User",
                Method.Post);
            var user = "Jo2" + new Random().Next(1, 999);
            var password = "Password001!";
            request.AddJsonBody(new PostRequestModelNewUser2
            (
                user,
                password
            ));
            RestResponse response = await client.ExecuteAsync(request);


            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://demoqa.com/login");
            driver.FindElement(By.Id("userName")).SendKeys(user);
            driver.FindElement(By.Id("password")).SendKeys(password);

            Thread.Sleep(5000);

            driver.Quit();
        }
    }
}
