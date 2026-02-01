using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using ServiceLayer.DataTransferObject.SignalFormDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace ServiceLayer.Mapper.SignalFormMappers
{
    public class SignalFormFieldMapper
    {

        public static List<SignalFormFieldDto> ToDto(ICollection<SignalFormField> collection)
        {
            List<SignalFormFieldDto> list = new();

            foreach(var item in collection)
            {
                list.Add(new SignalFormFieldDto()
                {
                    Id = item.Id,
                    InputType = item.InputType,
                    Label = item.Label,
                    Property = item.Property,
                    PropertyType = item.PropertyType,
                    InitialValue = item.InitialValue,
                    CssClasses = item.CssClasses,
                    Validations = item.Validations.Count() > 0 ? SignalFormValidationMapper.ToDto(item.Validations) : new List<SignalFormValidationDto>(),
                    Options = item.Options.Count() > 0 ? SignalFormOptionMapper.ToDto(item.Options) : new List<SignalFormOptionDto>(),
                    AdditionalData = item.AddionalData.Count() > 0 ? SignalFormAdditionalDataMapper.ToDto(item.AddionalData) : new List<SignalFormAdditionalDataDto>()
                });
            }

            return list;
        }

        public static List<SignalFormFieldDto> ToDto(ICollection<SignalFormField> collection, List<SignalForm> formArrays)
        {
            List<SignalFormFieldDto> list = new();

            foreach (var item in collection)
            {
                SignalFormFieldDto dto = new();
                dto.Id = item.Id;
                dto.InputType = item.InputType;
                dto.Label = item.Label;
                dto.Property = item.Property;
                dto.PropertyType = item.PropertyType;
                dto.InitialValue = item.InitialValue;
                dto.CssClasses = item.CssClasses;
                dto.Validations = item.Validations.Count() > 0 ? SignalFormValidationMapper.ToDto(item.Validations) : new List<SignalFormValidationDto>();
                dto.Options = item.Options.Count() > 0 ? SignalFormOptionMapper.ToDto(item.Options) : new List<SignalFormOptionDto>();
                dto.AdditionalData = item.AddionalData.Count() > 0 ? SignalFormAdditionalDataMapper.ToDto(item.AddionalData) : new List<SignalFormAdditionalDataDto>();

                if(item.PropertyType == PropertyType.FORM_ARRAY && formArrays.Count() > 0)
                {
                    SignalForm? formArray = formArrays.SingleOrDefault(x => x.Id == item.FormArrayId);

                    if(formArray != null)
                    {
                        dto.FormArray = SignalFormMapper.ToDto(formArray);
                    }                    
                }

                list.Add(dto);
            }

            return list;
        }

        public static ICollection<SignalFormField> ToEntity(List<SignalFormFieldDto> dtos)
        {
            ICollection<SignalFormField> collection = new List<SignalFormField>();

            foreach (var dto in dtos)
            {
                SignalFormField entity = new();
                                
                entity.InputType = dto.InputType;
                entity.Label = dto.Label;
                entity.Property = dto.Property;
                entity.PropertyType = dto.PropertyType;
                entity.InitialValue = dto.InitialValue;
                entity.CssClasses = dto.CssClasses;

                if (dto.Validations.Count() > 0)
                {                   
                    entity.Validations = SignalFormValidationMapper.ToEntity(dto.Validations);
                }

                if (dto.Options.Count() > 0)
                {
                    entity.Options = SignalFormOptionMapper.ToEntity(dto.Options);
                }

                if(dto.AdditionalData.Count() > 0)
                {
                    entity.AddionalData = SignalFormAdditionalDataMapper.ToEntity(dto.AdditionalData);
                }

                if(dto.FormArrayId != null)
                {
                    entity.FormArrayId = dto.FormArrayId ?? 0;
                }

                collection.Add(entity);
            }

            return collection;
        }

    }

}
