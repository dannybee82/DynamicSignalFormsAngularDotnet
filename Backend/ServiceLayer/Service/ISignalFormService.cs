using ServiceLayer.DataTransferObject.OverviewDto;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Service
{
    public interface ISignalFormService
    {

        Task<List<FormOverviewDto>> GetAll();

        Task<SignalFormDto?> GetById(int id);

        Task Create(SignalFormDto dto);

        Task Update(SignalFormDto dto);

        Task Delete(int id);

        Task<List<FormArrayOverviewDto>> GetFormArrays();

    }

}