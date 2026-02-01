using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ServiceLayer.Mapper.SignalFormMappers
{
    public class SignalFormValidationMapper
    {

        public static List<SignalFormValidationDto> ToDto(ICollection<SignalFormValidation> collection)
        {
            List<SignalFormValidationDto> list = new();

            foreach(var item in collection)
            {
                list.Add(new SignalFormValidationDto()
                {
                    Validation = item.Validation,
                    Value = item.Value
                });
            }

            return list;
        }

        public static ICollection<SignalFormValidation> ToEntity(List<SignalFormValidationDto> dtos)
        {
            ICollection<SignalFormValidation> collection = new List<SignalFormValidation>();

            foreach(var dto in dtos)
            {
                collection.Add(new SignalFormValidation()
                {
                    Validation = dto.Validation,
                    Value = dto.Value
                });
            }

            return collection;
        }

    }

}
