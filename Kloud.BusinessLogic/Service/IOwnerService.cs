using System.Collections.Generic;
using System.Threading.Tasks;
using Kloud.Models;

namespace Kloud.BusinessLogic.Service
{
    public interface IOwnerService
    {
        Task<IEnumerable<Owner>> GetOwners();
    }
}
