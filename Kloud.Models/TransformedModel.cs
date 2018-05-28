using System.Collections.Generic;

namespace Kloud.Models
{
    public class TransformedModel
    {
        public string BrandName { get; set; }
        public IEnumerable<string> BrandOwners { get; set; }
    }
}
