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

    [Table("SignalFormField", Schema = "DynamicSignalForms")]
    public class SignalFormField
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public InputType InputType { get; set; }

        [Required]
        public string Label { get; set; }

        [Required]
        public string Property { get; set; }

        [Required]
        public PropertyType PropertyType { get; set; }
        public string InitialValue { get; set; } = string.Empty;

        public string CssClasses { get; set; } = string.Empty;

        [ForeignKey("SignalForm")]
        public int? SignalFormId { get; set; }
        public SignalForm? SignalForm { get; set; }

        public ICollection<SignalFormValidation> Validations { get; set; }

        public ICollection<SignalFormOption> Options { get; set; }

        public ICollection<SignalFormAdditionalData> AddionalData { get; set; }

        // FormArrayId refers to another form in the database.
        public int? FormArrayId { get; set; }

    }

}
