using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.SignalFormDto
{
    public class SignalFormFieldDto
    {
        public int? Id { get; set; }
        public InputType InputType { get; set; }

        public string Label { get; set; }

        public string Property { get; set; }

        public PropertyType PropertyType { get; set; }

        public string InitialValue { get; set; } = string.Empty;

        public string CssClasses { get; set; } = string.Empty;

        public List<SignalFormValidationDto> Validations { get; set; }

        public List<SignalFormOptionDto> Options { get; set; }

        public List<SignalFormAdditionalDataDto> AdditionalData { get; set; }

        public int? FormArrayId { get; set; }

        public SignalFormDto? FormArray;
    }

}
