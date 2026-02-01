using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Entity
{

    [Table("SignalFormOption", Schema = "DynamicSignalForms")]
    public class SignalFormOption
    {
        [Key]
        public int Id { get; set; }

        public string Label { get; set; }

        public string Value { get; set; } = string.Empty;

        public TypeOfValue TypeOfValue { get; set; }

        [ForeignKey("SignalFormField")]
        public int SignalFormFieldId { get; set; }

        public SignalFormField? SignalFormField { get; set; }
    }

}