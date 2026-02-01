using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataTransferObject.OverviewDto
{
    public class FormOverviewDto
    {

        public int Id { get; set; }
        public FormType FormType { get; set; }
        public string Title { get; set; }

    }

}
