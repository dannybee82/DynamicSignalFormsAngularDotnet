using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper.SignalFormMappers
{
    public class SignalFormOptionMapper
    {

        public static List<SignalFormOptionDto> ToDto(ICollection<SignalFormOption> collection)
        {
            List<SignalFormOptionDto> list = new();

            foreach (var item in collection)
            {
                list.Add(new SignalFormOptionDto()
                {
                    Label = item.Label,
                    Value = item.Value,
                    TypeOfValue = item.TypeOfValue
                });
            }

            return list;
        }

        public static ICollection<SignalFormOption> ToEntity(List<SignalFormOptionDto> dtos)
        {
            ICollection<SignalFormOption> collection = new List<SignalFormOption>();

            foreach(var dto in dtos)
            {
                collection.Add(new SignalFormOption()
                {
                    Label = dto.Label,
                    Value = dto.Value,
                    TypeOfValue = dto.TypeOfValue
                });
            }

            return collection;
        }

    }

}