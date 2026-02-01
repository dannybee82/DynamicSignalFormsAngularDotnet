using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.SignalFormDto
{
    public class SignalFormValidationDto
    {
        public ValidationType Validation { get; set; }

        public string Value { get; set; } = string.Empty;

    }

}