using RepositoryLayer.Entity;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Mapper.SignalFormMappers
{
    public class SignalFormMapper
    {

        public static SignalFormDto ToDto(SignalForm entity)
        {
            SignalFormDto dto = new();
            dto.Id = entity.Id;
            dto.FormType = entity.FormType;
            dto.Title = entity.Title;
            dto.CssClasses = entity.CssClasses;

            if(entity.FormFields.Count() > 0)
            {
                dto.FormFields = SignalFormFieldMapper.ToDto(entity.FormFields);
            }

            return dto;
        }

        public static SignalFormDto ToDto(SignalForm entity, List<SignalForm> formArrays)
        {
            SignalFormDto dto = new();
            dto.Id = entity.Id;
            dto.FormType = entity.FormType;
            dto.Title = entity.Title;
            dto.CssClasses = entity.CssClasses;

            if (entity.FormFields.Count() > 0)
            {
                dto.FormFields = SignalFormFieldMapper.ToDto(entity.FormFields, formArrays);
            }

            return dto;
        }

        public static SignalForm ToEntity(SignalFormDto dto)
        {
            SignalForm entity = new();
                        
            if (dto.Id != null)
            {
                entity.Id = dto.Id ?? 0;
            }

            entity.FormType = dto.FormType;
            entity.Title = dto.Title;
            entity.CssClasses = dto.CssClasses;

            if(dto.FormFields.Count() > 0)
            {
                entity.FormFields = SignalFormFieldMapper.ToEntity(dto.FormFields);

                if (dto.Id != null)
                {
                    foreach(var formField in entity.FormFields)
                    {
                        formField.SignalFormId = dto.Id ?? 0;
                    }
                }
            }

            return entity;
        }

    }

}
