using System.Collections.Generic;

namespace Kloud.BusinessLogic.Models
{
    public class TransformedModel
    {
        public string BrandName { get; set; }
        public IEnumerable<string> BrandOwners { get; set; }
    }
}
