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

    [Table("SignalFormValidation", Schema = "DynamicSignalForms")]
    public class SignalFormValidation
    {
        [Key]
        public int Id { get; set; }

        public ValidationType Validation { get; set; }

        public string Value { get; set; } = string.Empty;

        [ForeignKey("SignalFormField")]
        public int SignalFormFieldId { get; set; }

        public SignalFormField? SignalFormField { get; set; }
    }

}
