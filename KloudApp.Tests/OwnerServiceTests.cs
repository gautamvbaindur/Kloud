using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using KloudApp.ConfigManager;
using Kloud.BusinessLogic.Service;
using System.Threading.Tasks;


namespace KloudApp.Tests
{
    [TestClass]
    public class OwnerServiceTests
    {
        private IOwnerService _service;

        [TestInitialize]
        public void Setup()
        {
            var _manager = new Mock<IConfigurationManager>();
            _manager.Setup(x => x.GetCarsAndOwnersUrl()).Returns("https://kloudcodingtest.azurewebsites.net/api/cars");
            _service = new OwnerService(_manager.Object);
        }

        [TestMethod]
        public async Task Test_OwnerService_Returns_Owner()
        {
            var result = await _service.GetOwners();

            

            Assert.IsNotNull(result);
        }   
    }
}
