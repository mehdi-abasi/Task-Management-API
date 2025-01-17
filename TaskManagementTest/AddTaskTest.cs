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
    public class AddTaskTest
    {

        private WebApplicationFactory<Program> _factory;
        private HttpClient _client;
        public AddTaskTest()
        {
            
        }
        [Test]
        public async Task InsertAsync_ShouldThrowArgumentException_WhenEntityIsNull()
        {
            // Arrange
            Entity nullEntity = null;

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _entityService.InsertAsync(nullEntity));
            Assert.Equal("Entity is invalid", exception.Message);
        }

        [Test]
        public async Task InsertAsync_ShouldThrowArgumentException_WhenRequiredFieldIsMissing()
        {
            // Arrange
            var invalidEntity = new Entity { RequiredField = null };

            // Act & Assert
            var exception = await Assert.ThrowsAsync<ArgumentException>(() => _entityService.InsertAsync(invalidEntity));
            Assert.Equal("Entity is invalid", exception.Message);
        }

    }
}
