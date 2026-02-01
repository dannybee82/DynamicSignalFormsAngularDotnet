using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper.SignalFormMappers
{
    public class SignalFormAdditionalDataMapper
    {

        public static List<SignalFormAdditionalDataDto> ToDto(ICollection<SignalFormAdditionalData> collection)
        {
            List<SignalFormAdditionalDataDto> list = new();

            foreach (var item in collection)
            {
                list.Add(new SignalFormAdditionalDataDto()
                {
                    Attribute = item.Attribute,
                    AttributeType = item.AttributeType,
                    Value = item.Value
                });
            }

            return list;
        }

        public static ICollection<SignalFormAdditionalData> ToEntity(List<SignalFormAdditionalDataDto> list)
        {
            ICollection<SignalFormAdditionalData> collection = new List<SignalFormAdditionalData>();

            foreach(var dto in list)
            {
                collection.Add(new SignalFormAdditionalData()
                {
                    Attribute = dto.Attribute,
                    AttributeType = dto.AttributeType,
                    Value = dto.Value
                });
            }

            return collection;
        }

    }

}
