using OrtizMed.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrtizMed.Domain.Interfaces
{
    public interface IFirebaseServiceClient
    {
        Task<IEnumerable<Medico>> GetMedicos();
    }
}
