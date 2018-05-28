using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Kloud.BusinessLogic.Business;
using Kloud.BusinessLogic.Service;
using Kloud.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Newtonsoft.Json;

namespace KloudApp.Tests
{
    [TestClass]
    public class BusinessTests
    {
        private Business _busines;

        [TestMethod]
        public void Test_GroupByBrandName_AllFieldsPresent_Success()
        {
            //arrange
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(x => x.GetOwners()).Returns(Task.FromResult(GetOwnerList("Owners.json")));
            _busines = new Business(ownerService.Object);

            //act
            var result = _busines.GetBrandsGrouped();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 6);
            Assert.AreEqual(result.First().BrandName, "Audi");
            Assert.AreEqual(result.Last().BrandName, "Toyota");
            Assert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList().Count, 4);
            CollectionAssert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList(),
                new List<string>
                {
                    "Gautam",
                    "Kloud",
                    "Kristin",
                    "Baindur"
                });
        }

        [TestMethod]
        public void Test_GroupByBrandName_SomeFieldsAbsent_Success()
        {
            //arrange
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(x => x.GetOwners()).Returns(Task.FromResult(GetOwnerList("Owners_SomeFieldsAbsent.json")));
            _busines = new Business(ownerService.Object);

            //act
            var result = _busines.GetBrandsGrouped();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 5);
            Assert.AreEqual(result.First().BrandName, "BMW");
            Assert.AreEqual(result.Last().BrandName, "Toyota");
            Assert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList().Count, 1);
            CollectionAssert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList(),
                new List<string>
                {
                    "Kristin",
                });
        }

        [TestMethod]
        public void Test_GroupByBrandName_ColorCaseChanged_Success()
        {
            //arrange
            var ownerService = new Mock<IOwnerService>();
            ownerService.Setup(x => x.GetOwners()).Returns(Task.FromResult(GetOwnerList("Owners_ColorCaseChanged.json")));
            _busines = new Business(ownerService.Object);

            //act
            var result = _busines.GetBrandsGrouped();

            //assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result.Count(), 6);
            Assert.AreEqual(result.First().BrandName, "Audi");
            Assert.AreEqual(result.Last().BrandName, "Toyota");
            Assert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList().Count, 4);
            CollectionAssert.AreEqual(result.Where(x => x.BrandName == "Mercedes").SelectMany(x => x.BrandOwners).ToList(),
                new List<string>
                {
                    "Kloud",
                    "Gautam",
                    "Kristin",
                    "Baindur"
                });
        }

        private IEnumerable<Owner> GetOwnerList(string fileName)
        {
            var json = string.Empty;
            using (StreamReader r = new StreamReader(fileName))
            {
                json = r.ReadToEnd();
            }
            return JsonConvert.DeserializeObject<List<Owner>>(json);
        }
    }
}
