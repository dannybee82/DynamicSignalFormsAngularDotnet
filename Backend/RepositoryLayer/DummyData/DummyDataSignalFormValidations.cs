using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Model;

namespace RepositoryLayer.DummyData
{
    public class DummyDataSignalFormValidations
    {

        public static List<SignalFormValidation> Create()
        {
            return new List<SignalFormValidation>()
            {
                // First Form + Fields.
                new SignalFormValidation()
                {
                    Id = 1,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 1
                },
                new SignalFormValidation()
                {
                    Id = 2,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 2
                },
                new SignalFormValidation()
                {
                    Id = 3,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 3
                },
                new SignalFormValidation()
                {
                    Id = 4,
                    Validation = ValidationType.MINIMUM_VALUE_INT,
                    Value = "18",
                    SignalFormFieldId = 3
                },
                new SignalFormValidation()
                {
                    Id = 5,
                    Validation = ValidationType.MAXIMUM_VALUE_INT,
                    Value = "65",
                    SignalFormFieldId = 3
                },
                new SignalFormValidation()
                {
                    Id = 6,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 4
                },
                new SignalFormValidation()
                {
                    Id = 7,
                    Validation = ValidationType.MAX_LENGTH,
                    Value = "250",
                    SignalFormFieldId = 4
                },
                // Second Form + fields
                new SignalFormValidation()
                {
                    Id = 8,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 5
                },
                new SignalFormValidation()
                {
                    Id = 9,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 6
                },
                new SignalFormValidation()
                {
                    Id = 10,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 7
                },
                new SignalFormValidation()
                {
                    Id = 11,
                    Validation = ValidationType.MINIMUM_VALUE_INT,
                    Value = "18",
                    SignalFormFieldId = 7
                },
                new SignalFormValidation()
                {
                    Id = 12,
                    Validation = ValidationType.MAXIMUM_VALUE_INT,
                    Value = "65",
                    SignalFormFieldId = 7
                },
                new SignalFormValidation()
                {
                    Id = 13,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 8
                },
                new SignalFormValidation()
                {
                    Id = 14,
                    Validation = ValidationType.MAX_LENGTH,
                    Value = "250",
                    SignalFormFieldId = 8
                },
                // The third form
                new SignalFormValidation()
                {
                    Id = 15,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 9
                },
                new SignalFormValidation()
                {
                    Id = 16,
                    Validation = ValidationType.MINIMUM_TIME_DAYS,
                    Value = "0",
                    SignalFormFieldId = 9
                },
                new SignalFormValidation()
                {
                    Id = 17,
                    Validation = ValidationType.MAXIMUM_TIME_DAYS,
                    Value = "30",
                    SignalFormFieldId = 9
                },
                new SignalFormValidation()
                {
                    Id = 18,
                    Validation = ValidationType.DATE_NOT_EQUAL,
                    Value = "enddate",
                    SignalFormFieldId = 9
                },
                new SignalFormValidation()
                {
                    Id = 19,
                    Validation = ValidationType.DATE_MUST_BE_EARLIER,
                    Value = "enddate",
                    SignalFormFieldId = 9
                },
                new SignalFormValidation()
                {
                    Id = 20,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 10
                },
                new SignalFormValidation()
                {
                    Id = 21,
                    Validation = ValidationType.MINIMUM_TIME_DAYS,
                    Value = "0",
                    SignalFormFieldId = 10
                },
                new SignalFormValidation()
                {
                    Id = 22,
                    Validation = ValidationType.MAXIMUM_TIME_DAYS,
                    Value = "30",
                    SignalFormFieldId = 10
                },
                new SignalFormValidation()
                {
                    Id = 23,
                    Validation = ValidationType.DATE_NOT_EQUAL,
                    Value = "startdate",
                    SignalFormFieldId = 10
                },
                new SignalFormValidation()
                {
                    Id = 24,
                    Validation = ValidationType.DATE_MUST_BE_LATER,
                    Value = "startdate",
                    SignalFormFieldId = 10
                },
                // The fourth form.
                new SignalFormValidation()
                {
                    Id = 25,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 11
                },
                new SignalFormValidation()
                {
                    Id = 26,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 12
                },
                // The fifth form
                new SignalFormValidation()
                {
                    Id = 27,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 13
                },
                new SignalFormValidation()
                {
                    Id = 28,
                    Validation = ValidationType.MINIMUM_VALUE_FLOAT,
                    Value = "10.00",
                    SignalFormFieldId = 13
                },
                new SignalFormValidation()
                {
                    Id = 29,
                    Validation = ValidationType.MAXIMUM_VALUE_FLOAT,
                    Value = "100.00",
                    SignalFormFieldId = 13
                },
                new SignalFormValidation()
                {
                    Id = 30,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 14
                },
                new SignalFormValidation()
                {
                    Id = 31,
                    Validation = ValidationType.MINIMUM_VALUE_FLOAT,
                    Value = "-25.00",
                    SignalFormFieldId = 14
                },
                new SignalFormValidation()
                {
                    Id = 32,
                    Validation = ValidationType.MAXIMUM_VALUE_FLOAT,
                    Value = "25.00",
                    SignalFormFieldId = 14
                },
                new SignalFormValidation()
                {
                    Id = 33,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 15
                },
                new SignalFormValidation()
                {
                    Id = 34,
                    Validation = ValidationType.MINIMUM_VALUE_INT,
                    Value = "10",
                    SignalFormFieldId = 15
                },
                new SignalFormValidation()
                {
                    Id = 35,
                    Validation = ValidationType.MAXIMUM_VALUE_INT,
                    Value = "75",
                    SignalFormFieldId = 15
                },
                new SignalFormValidation()
                {
                    Id = 36,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 16
                },
                new SignalFormValidation()
                {
                    Id = 37,
                    Validation = ValidationType.MINIMUM_VALUE_INT,
                    Value = "-75",
                    SignalFormFieldId = 16
                },
                new SignalFormValidation()
                {
                    Id = 38,
                    Validation = ValidationType.MAXIMUM_VALUE_INT,
                    Value = "-10",
                    SignalFormFieldId = 16
                },
                // The sixth form
                new SignalFormValidation()
                {
                    Id = 39,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 17
                },
                new SignalFormValidation()
                {
                    Id = 40,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 18
                },
                // The seventh form
                new SignalFormValidation()
                {
                    Id = 41,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 19
                },
                new SignalFormValidation()
                {
                    Id = 42,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 20
                },
                // The eight form
                new SignalFormValidation()
                {
                    Id = 43,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 21
                },
                new SignalFormValidation()
                {
                    Id = 44,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 22
                },
                new SignalFormValidation()
                {
                    Id = 45,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 23
                },
                new SignalFormValidation()
                {
                    Id = 46,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 24
                },
                new SignalFormValidation()
                {
                    Id = 47,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 25
                },
                new SignalFormValidation()
                {
                    Id = 48,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 26
                },
                // The ninth Form
                new SignalFormValidation()
                {
                    Id = 49,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 27
                },
                // The tenth Form
                new SignalFormValidation()
                {
                    Id = 50,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 29
                },
                new SignalFormValidation()
                {
                    Id = 51,
                    Validation = ValidationType.REQUIRED,
                    Value = string.Empty,
                    SignalFormFieldId = 30
                },

            };
        }

    }

}
