using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface ISignalFormRepository
    {
        IQueryable<SignalForm> GetQueryable();

        Task<List<SignalForm>> GetAll();

        Task<SignalForm?> GetById(int id);

        Task Create(SignalForm entity);

        Task Update(SignalForm entity);

        Task Delete(int id);

        Task StopTracking();
    }

}
