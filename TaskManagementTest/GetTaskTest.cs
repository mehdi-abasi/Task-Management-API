using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using UseCases;
using System.Text.Json;
using Microsoft.AspNetCore.Hosting;
using Newtonsoft.Json;
//using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace UnitTest
{
    [TestFixture]
    public class GetTaskTest
    {

        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        public GetTaskTest()
        {
            
        }
      
        [TearDown]
        public void TearDown()
        {
            _client.Dispose();
            _factory.Dispose();
        }
        [SetUp]
        public void SetUp()
        {
            _factory = new WebApplicationFactory<Program>();
            _client = _factory.CreateClient();
        }
        [Test]
        public void TestGetByID()
        {
            
            int taskId = 6;
            string url = "https://localhost:7293/Task/6";
            var response =  _client.GetAsync($"/Task/{taskId}").Result;
            response.EnsureSuccessStatusCode();
            string jsonResponse =  response.Content.ReadAsStringAsync().Result;
            var task = JsonConvert.DeserializeObject<TaskModel>(jsonResponse);
            Assert.That(task,Is.Not.Null);
            Assert.That(taskId, Is.EqualTo(task.Id));
        }
       
    }
}
