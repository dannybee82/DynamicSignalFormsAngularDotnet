using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public interface ISignalFormFieldRepository
    {
        IQueryable<SignalFormField> GetQueryable();

        Task<List<SignalFormField>> GetAll();

        Task<SignalFormField?> GetById(int id);

        Task Create(SignalFormField entity);

        Task Update(SignalFormField entity);

        Task Delete(int id);
    }

}
