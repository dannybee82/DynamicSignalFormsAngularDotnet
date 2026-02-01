using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.SignalFormDto
{
    public class SignalFormDto
    {
        public int? Id { get; set; }
        public FormType FormType { get; set; }
        public string Title { get; set; }

        public string CssClasses { get; set; }

        public List<SignalFormFieldDto> FormFields { get; set; }

        public class SignalFormAdditionalDataDto
        {
        }
    }

}
