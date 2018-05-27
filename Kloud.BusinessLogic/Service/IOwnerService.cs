using KloudApp.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Kloud.BusinessLogic.Service
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetOwners();
    }
}
