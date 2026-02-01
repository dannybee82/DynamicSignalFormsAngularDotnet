using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.OverviewDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper.OverviewMappers
{
    public class FormArrayOverviewMapper
    {

        public static FormArrayOverviewDto ToDto(SignalForm entity)
        {
            return new FormArrayOverviewDto()
            {
                Id = entity.Id,
                Title = entity.Title,
            };
        }

    }

}
