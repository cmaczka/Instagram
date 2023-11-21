using Instagram.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace XUnitTest.Controller
{

    public class LoginControllerTest
    {
        private HttpClient _httpClient;
        private string _urlBase = "/api/login/";
        LoginResponseDto loginResponseDto = new LoginResponseDto();

        public LoginControllerTest()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            _httpClient = webAppFactory.CreateDefaultClient();
            
        }
        [Fact]
        public async Task IsIniciarSesion()
        {
            LoginRequestDTO loginRequestDTO = new LoginRequestDTO();
            loginRequestDTO.UserName = "milei";
            loginRequestDTO.Password = "milei2024";

            HttpContent content = new StringContent(JsonConvert.SerializeObject(loginRequestDTO), Encoding.UTF8, "application/json");
            var response = await _httpClient.PostAsync($"{_urlBase}login", content);
            loginResponseDto = await response.Content.ReadFromJsonAsync<LoginResponseDto>();

            Assert.Equal("OK", response.StatusCode.ToString());
            Assert.True(!string.IsNullOrEmpty(loginResponseDto.Token));
        }
    }
}
