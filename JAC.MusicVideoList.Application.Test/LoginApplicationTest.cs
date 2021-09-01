using JAC.MusicVideoList.Application.Main.Interfaces;
using JAC.MusicVideoList.Domain.Core.Entities;
using JAC.MusicVideoList.Services.WebAPI;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.IO;
using System.Threading.Tasks;

namespace JAC.MusicVideoList.Application.Test
{
    [TestClass]
    public class LoginApplicationTest
    {
        private static IConfiguration _configuration;
        private static IServiceScopeFactory _scopeFactory;

        [ClassInitialize]
        public static void Initialize(TestContext _)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", true, true)
                .AddEnvironmentVariables();
            _configuration = builder.Build();

            var startup = new Startup(_configuration);
            var services = new ServiceCollection();
            startup.ConfigureServices(services);
            _scopeFactory = services.BuildServiceProvider().GetService<IServiceScopeFactory>();
        }

        [TestMethod]
        public async Task Authenticate_ReturnFalseWhenCredentialsInvalid()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ILoginApplication>();
            var expected = false;

            var user = new UserLogin { UserName = "asdf", Password = "asdfgsadg" };

            var result = await context.GetLoginByCredentials(user);

            Assert.AreEqual(expected, result.Item1);

        }

        [TestMethod]
        public async Task Authenticate_ReturnTrueWhenCredentialsIsValid()
        {
            using var scope = _scopeFactory.CreateScope();
            var context = scope.ServiceProvider.GetService<ILoginApplication>();
            var expected = true;

            var user = new UserLogin { UserName = "jhon123", Password = "123456" };

            var result = await context.GetLoginByCredentials(user);

            Assert.AreEqual(expected, result.Item1);

        }
    }
}
