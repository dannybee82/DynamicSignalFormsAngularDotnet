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

    [Table("SignalForm", Schema = "DynamicSignalForms")]
    public class SignalForm
    {

        [Key]
        public int Id { get; set; }

        public FormType FormType { get; set; }

        [Required]
        public string Title { get; set; }

        public string CssClasses { get; set; } = string.Empty;

        public ICollection<SignalFormField> FormFields { get; set; }

    }

}