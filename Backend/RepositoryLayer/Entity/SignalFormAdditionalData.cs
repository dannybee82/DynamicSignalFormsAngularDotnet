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

    [Table("SignalFormAdditionalData", Schema = "DynamicSignalForms")]
    public class SignalFormAdditionalData
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Attribute { get; set; }

        [Required]
        public AttributeType AttributeType { get; set; }

        [Required]
        public string Value { get; set; }
        
        [ForeignKey("SignalFormField")]
        public int SignalFormFieldId { get; set; }

        public SignalFormField? SignalFormField { get; set; }
    }

}