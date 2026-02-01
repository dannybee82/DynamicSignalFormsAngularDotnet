using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.SignalFormDto
{
    public class SignalFormAdditionalDataDto
    {

        public string Attribute { get; set; }
        public AttributeType AttributeType { get; set; }
        public string Value { get; set; }

    }

}
