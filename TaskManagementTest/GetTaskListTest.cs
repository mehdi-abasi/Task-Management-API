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
    public class GetTaskListTest
    {

        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        public GetTaskListTest()
        {
            
        }
      
    }
}
