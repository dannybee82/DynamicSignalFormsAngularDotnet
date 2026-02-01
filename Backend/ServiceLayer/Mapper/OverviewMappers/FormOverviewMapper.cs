using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.OverviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper.OverviewMappers
{
    public class FormOverviewMapper
    {

        public static FormOverviewDto ToDto(SignalForm entity)
        {
            return new FormOverviewDto()
            {
                Id = entity.Id,
                FormType = entity.FormType,
                Title = entity.Title
            };
        }

    }

}
