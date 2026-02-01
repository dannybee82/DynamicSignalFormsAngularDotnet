using Microsoft.EntityFrameworkCore;
using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using RepositoryLayer.Repository;
using ServiceLayer.DataTransferObject.OverviewDto;
using ServiceLayer.DataTransferObject.SignalFormDto;
using ServiceLayer.Mapper.OverviewMappers;
using ServiceLayer.Mapper.SignalFormMappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public class SignalFormService : ISignalFormService
    {
        private readonly ISignalFormRepository _signalFormRepository;
        private readonly ISignalFormFieldRepository _signalFormFieldRepository;

        public SignalFormService(
            ISignalFormRepository signalFormRepository, 
            ISignalFormFieldRepository signalFormFieldRepository)
        {
            _signalFormRepository = signalFormRepository;
            _signalFormFieldRepository = signalFormFieldRepository;
        }

        public async Task<List<FormOverviewDto>> GetAll()
        {
            var records = await _signalFormRepository.GetAll().ConfigureAwait(false);
            return records.Select(x => FormOverviewMapper.ToDto(x)).ToList();
        }

        public async Task<SignalFormDto?> GetById(int id)
        {
            var record = await _signalFormRepository.GetById(id);

            if(record != null)
            {
                List<int> formArrayIds = record.FormFields.Where(x => x.FormArrayId != null).Select(x => x.FormArrayId ?? 0).ToList();

                var formArrays = formArrayIds.Count() > 0 ?
                    await _signalFormRepository.GetQueryable()
                        .Where(x => formArrayIds.Contains(x.Id))
                        .ToListAsync()
                        .ConfigureAwait(false)
                    : new List<SignalForm>();

                return SignalFormMapper.ToDto(record, formArrays);
            }

            return null;
        }

        public async Task Create(SignalFormDto dto)
        {
            await _signalFormRepository.Create(SignalFormMapper.ToEntity(dto));
        }

        public async Task Update(SignalFormDto dto)
        {
            var record = await _signalFormRepository.GetById(dto.Id ?? 0);
            
            if(record == null)
            {
                throw new Exception("Signal Form not found.");
            }

            // Delete old fields.
            if(record.FormFields.Count() > 0)
            {
                foreach(var formfield in record.FormFields)
                {
                    await _signalFormFieldRepository.Delete(formfield.Id);
                }
            }

            var entity = SignalFormMapper.ToEntity(dto);

            if(entity.FormFields.Count() > 0)
            {
                foreach(var formField in entity.FormFields)
                {
                    await _signalFormFieldRepository.Create(formField);
                }
            }

            await _signalFormRepository.Update(entity);
        }

        public async Task Delete(int id)
        {
            await _signalFormRepository.Delete(id);
        }

        public async Task<List<FormArrayOverviewDto>> GetFormArrays()
        {
            var records = await _signalFormRepository.GetQueryable()
                .Where(x => x.FormType == FormType.FORM_ARRAY)
                .ToListAsync();

            return records.Count() > 0 ?
                records.Select(x => FormArrayOverviewMapper.ToDto(x)).ToList()
                : new List<FormArrayOverviewDto>();
        }

    }

}
