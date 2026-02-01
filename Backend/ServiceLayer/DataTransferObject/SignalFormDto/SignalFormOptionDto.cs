using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.SignalFormDto
{
    public class SignalFormOptionDto
    {
        public string Label { get; set; }

        public string Value { get; set; } = string.Empty;

        public TypeOfValue TypeOfValue { get; set; } = TypeOfValue.UNKNOWN;

    }

}