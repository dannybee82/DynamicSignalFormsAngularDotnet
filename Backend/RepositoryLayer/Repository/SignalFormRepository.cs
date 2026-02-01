using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Repository
{
    public class SignalFormRepository : ISignalFormRepository
    {
        private readonly MainDbContext _dbContext;

        public SignalFormRepository(MainDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<SignalForm> GetQueryable()
        {
            return _dbContext.SignalForms
                .AsNoTracking()
                .Include(x => x.FormFields)
                .ThenInclude(x => x.Validations)
                .Include(x => x.FormFields)
                .ThenInclude(x => x.Options)
                .Include(x => x.FormFields)
                .ThenInclude(x => x.AddionalData)
                .OrderBy(x => x.Id);
        }

        public async Task Create(SignalForm entity)
        {
            await _dbContext.SignalForms.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task Delete(int id)
        {
            var record = await GetById(id);

            if (record != null)
            {
                _dbContext.SignalForms.Remove(record);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task<List<SignalForm>> GetAll()
        {
            return await _dbContext.SignalForms
                .AsNoTracking()
                .OrderBy(x => x.Id)
                .ToListAsync()
                .ConfigureAwait(false);
        }

        public async Task<SignalForm?> GetById(int id)
        {
            return await _dbContext.SignalForms
                .AsNoTracking()
                .Include(x => x.FormFields)
                .ThenInclude(x => x.Validations)
                .Include(x => x.FormFields)
                .ThenInclude(x => x.Options)
                .Include(x => x.FormFields)
                .ThenInclude(x => x.AddionalData)
                .SingleOrDefaultAsync(x => x.Id == id)
                .ConfigureAwait(false);
        }

        public async Task Update(SignalForm entity)
        {
            var record = await GetById(entity.Id);

            if (record != null)
            {
                _dbContext.SignalForms.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
        }

        public async Task StopTracking()
        {
            await Task.Run(() => {
                _dbContext.ChangeTracker.Clear();
            });
        }

    }

}