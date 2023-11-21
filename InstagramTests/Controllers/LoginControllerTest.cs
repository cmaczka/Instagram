using Instagram.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace InstagramTests.Controllers
{
    [TestFixture]
    public class LoginControllerTest
    {
        private HttpClient _httpClient;
        private string _urlBase= "/api/login/";
        public LoginControllerTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
        }

        [SetUp]
        public void Setup()
        {

        }

        //[Test]
        //public async Task Test1()
        //{
        //    LoginRequestDTO loginRequestDTO= new LoginRequestDTO();
        //    loginRequestDTO.UserName = "milei";
        //    loginRequestDTO.Password = "milei2024";

        //    HttpContent content = new StringContent(
        //                          JsonConvert.SerializeObject(loginRequestDTO), Encoding.UTF8, "application/json"); 
        //    var response = await _httpClient.PostAsync($"{_urlBase}login", content);

        //    var _respuestaGeneralOut = await response.Content.ReadFromJsonAsync<LoginRequestDTO>();

        //    Assert.IsTrue("200".Equals(response.StatusCode.ToString())); 
        //    Assert.True(!string.IsNullOrEmpty(_respuestaGeneralOut.Password));
        //}

    
       

    }
}
