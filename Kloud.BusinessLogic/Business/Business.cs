using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Kloud.BusinessLogic.Service;
using Kloud.Models;

namespace Kloud.BusinessLogic.Business
{
    //not using an interface here to keep things simple.
    public class Business
    {
        private readonly IOwnerService _ownerService;

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
                    .SelectMany(x => x.Cars.Select(y => new { x.Name, y.Brand, Color = y.Colour }))
                    .GroupBy(x => x.Brand, StringComparer.OrdinalIgnoreCase)
                    .OrderBy(k => k.Key, StringComparer.OrdinalIgnoreCase)
                    .Select(x => new TransformedModel
                    {
                        BrandName = x.Key,
                        BrandOwners = x.Where(y => !string.IsNullOrEmpty(y.Name) && !string.IsNullOrEmpty(y.Color))
                                .OrderBy(y => y.Color, StringComparer.OrdinalIgnoreCase).Select(y => y.Name).Distinct()
                    }).ToList();
        }

    }
}
