using System.Collections.Generic;

namespace KloudApp.Models
{
    public class Owner
    {
        public string Name { get; set; }
        public IEnumerable<Car> Cars { get; set; }
    }
}
