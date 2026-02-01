using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class SignalFormFieldRepository : ISignalFormFieldRepository
    {
        private readonly MainDbContext _dbContext;

        public SignalFormFieldRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<SignalFormField> GetQueryable()
        {
            return _dbContext.SignalFormFields
                .AsNoTracking()
                .Include(x => x.Validations)
                .Include(x => x.Options)
                .Include(x => x.AddionalData)
                .OrderBy(x => x.Id);
        }

        public async Task Create(SignalFormField entity)
        {
            await _dbContext.SignalFormFields.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.SignalFormFields.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SignalFormField>> GetAll()
        {
            return await _dbContext.SignalFormFields
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<SignalFormField?> GetById(int id)
        {
            return await _dbContext.SignalFormFields
                .AsNoTracking()
                .Include(x => x.Validations)
                .Include(x => x.Options)
                .Include(x => x.AddionalData)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(SignalFormField entity)
        {
            var record = await GetById(entity.Id);

            if (record != null)
            {
                _dbContext.SignalFormFields.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

    }

}
