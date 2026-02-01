using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DummyData
{
    public class DummyDataSignalForms
    {

        public static List<SignalForm> Create() 
        {
            return new List<SignalForm>()
            {
                new SignalForm()
                {
                    Id = 1,
                    FormType = FormType.REGULAR,
                    Title = "The first form (basic)",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 2,
                    FormType = FormType.REGULAR,
                    Title = "The second form (callbacks)",
                    CssClasses = "column w-50 p-1"
                }
                ,
                new SignalForm()
                {
                    Id = 3,
                    FormType = FormType.REGULAR,
                    Title = "The third form (start- and enddate)",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 4,
                    FormType = FormType.REGULAR,
                    Title = "The fourth form (autocomplete)",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 5,
                    FormType = FormType.REGULAR,
                    Title = "The fifth form (number inputs)",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 6,
                    FormType = FormType.REGULAR,
                    Title = "The sixth form (single select).",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 7,
                    FormType = FormType.REGULAR,
                    Title = "The seventh form (multiple select).",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 8,
                    FormType = FormType.REGULAR,
                    Title = "The eighth form (radiobuttons).",
                    CssClasses = "column w-50 p-1"
                },
                new SignalForm()
                {
                    Id = 9,
                    FormType = FormType.REGULAR,
                    Title = "The ninth form (todo-list parent).",
                    CssClasses = "column w-50 p-1",
                },
                new SignalForm()
                {
                    Id = 10,
                    FormType = FormType.FORM_ARRAY,
                    Title = "The tenth form (form array).",
                    CssClasses = "row w-50"
                },
            };
        }

    }

}