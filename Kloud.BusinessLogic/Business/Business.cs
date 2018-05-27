using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Kloud.BusinessLogic.Models;
using Kloud.BusinessLogic.Service;

namespace Kloud.BusinessLogic.Business
{
    //not using an interface here to keep things simple.
    public class Business
    {
        private IOwnerService _ownerService;

        public Business(IOwnerService ownerService)
        {
            _ownerService = ownerService;
        }

        public IEnumerable<TransformedModel> GetBrandsGrouped()
        {
            return Task.Run(async () => await RunTask()).Result;
        }

        private async Task<IEnumerable<TransformedModel>> RunTask()
        {
            var result = await _ownerService.GetOwners();

            return result
                    .SelectMany(x => x.Cars.Select(y => new { Name = x.Name, Brand = y.Brand, Color = y.Colour }))
                    .GroupBy(x => x.Brand)
                    .OrderBy(k => k.Key)
                    .Select(x => new TransformedModel
                    {
                        BrandName = x.Key,
                        BrandOwners = x.Where(y => !string.IsNullOrEmpty(y.Name) && !string.IsNullOrEmpty(y.Color))
                                .OrderBy(y => y.Color).Select(y => y.Name).Distinct()
                    }).ToList();
        }

    }
}
