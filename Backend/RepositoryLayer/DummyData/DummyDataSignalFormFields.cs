using RepositoryLayer.Entity;
using RepositoryLayer.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.DummyData
{
    public class DummyDataSignalFormFields
    {

        public static List<SignalFormField> Create()
        {
            return new List<SignalFormField>()
            {
                // The first from
                new SignalFormField()
                {
                    Id = 1,
                    InputType = InputType.INPUT_TEXT,
                    Label = "Firstname",
                    Property = "firstname",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 1
                },
                new SignalFormField()
                {
                    Id = 2,
                    InputType = InputType.INPUT_TEXT,                    
                    Label = "Lastname",
                    Property = "lastname",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 1
                },
                new SignalFormField()
                {
                    Id = 3,
                    InputType = InputType.INPUT_NUMBER_INT,                    
                    Label = "Age",
                    Property = "age",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "18",
                    CssClasses = "column",
                    SignalFormId = 1
                },
                new SignalFormField()
                {
                    Id = 4,
                    InputType = InputType.INPUT_TEXTAREA,
                    Label = "Information about Person",
                    Property = "information",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 1
                },
                // The second from
                new SignalFormField()
                {
                    Id = 5,
                    InputType = InputType.INPUT_TEXT_CALLBACK,
                    Label = "Firstname",
                    Property = "firstname",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 2
                },
                new SignalFormField()
                {
                    Id = 6,
                    InputType = InputType.INPUT_TEXT_CALLBACK,
                    Label = "Lastname",
                    Property = "lastname",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 2
                },
                new SignalFormField()
                {
                    Id = 7,
                    InputType = InputType.INPUT_NUMBER_INT_CALLBACK,
                    Label = "Age",
                    Property = "age",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "18",
                    CssClasses = "column",
                    SignalFormId = 2
                },
                new SignalFormField()
                {
                    Id = 8,
                    InputType = InputType.INPUT_TEXTAREA_CALLBACK,
                    Label = "Information about Person",
                    Property = "information",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 2
                },
                // The third form
                new SignalFormField()
                {
                    Id = 9,
                    InputType = InputType.INPUT_DATE,
                    Label = "Startdate (from today until 30 days)",
                    Property = "startdate",
                    PropertyType = PropertyType.DATE,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 3
                },
                new SignalFormField()
                {
                    Id = 10,
                    InputType = InputType.INPUT_DATE,
                    Label = "Enddate (from today until 30 days)",
                    Property = "enddate",
                    PropertyType = PropertyType.DATE,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 3
                },
                // The fourth form
                new SignalFormField()
                {
                    Id = 11,
                    InputType = InputType.INPUT_TEXT_AUTOCOMPLETE,
                    Label = "Favorite Fruit",
                    Property = "fruit",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 4
                },
                new SignalFormField()
                {
                    Id = 12,
                    InputType = InputType.INPUT_TEXT_AUTOCOMPLETE_CALLBACK,
                    Label = "Favorite Car",
                    Property = "car",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 4
                },
                // The fifth form
                new SignalFormField()
                {
                    Id = 13,
                    InputType = InputType.INPUT_NUMBER_FLOAT,
                    Label = "Your bid for second hand book (10.00 - 100.00)",
                    Property = "bid",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "10.00",
                    CssClasses = "column",
                    SignalFormId = 5
                },
                new SignalFormField()
                {
                    Id = 14,
                    InputType = InputType.INPUT_NUMBER_FLOAT_CALLBACK,
                    Label = "Enter value between -25.00 and 25.00",
                    Property = "valuebetween",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "16.00",
                    CssClasses = "column",
                    SignalFormId = 5
                },
                new SignalFormField()
                {
                    Id = 15,
                    InputType = InputType.INPUT_NUMBER_INT,
                    Label = "Random Positive Number (10 - 75)",
                    Property = "randompositivenumber",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "25",
                    CssClasses = "column",
                    SignalFormId = 5
                },
                new SignalFormField()
                {
                    Id = 16,
                    InputType = InputType.INPUT_NUMBER_INT_CALLBACK,
                    Label = "Random Negative Number (from -10 to -75)",
                    Property = "randomnegativenumber",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "-25",
                    CssClasses = "column",
                    SignalFormId = 5
                },
                // The sixth form
                new SignalFormField()
                {
                    Id = 17,
                    InputType = InputType.INPUT_SELECT,
                    Label = "Select Girl Name",
                    Property = "selectgirlname",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "Saskia",
                    CssClasses = "column",
                    SignalFormId = 6
                },
                new SignalFormField()
                {
                    Id = 18,
                    InputType = InputType.INPUT_SELECT_CALLBACK,
                    Label = "Select Color",
                    Property = "selectcolor",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "White",
                    CssClasses = "column",
                    SignalFormId = 6
                },
                // The seventh form
                new SignalFormField()
                {
                    Id = 19,
                    InputType = InputType.INPUT_SELECT_MULTI,
                    Label = "Select Girl Names",
                    Property = "select_girl_names_multi",
                    PropertyType = PropertyType.STRING_ARRAY,
                    InitialValue = "Natasha, Jasmine",
                    CssClasses = "column",
                    SignalFormId = 7
                },
                new SignalFormField()
                {
                    Id = 20,
                    InputType = InputType.INPUT_SELECT_MULTI_CALLBACK,
                    Label = "Select Animals",
                    Property = "select_animals_multi",
                    PropertyType = PropertyType.STRING_ARRAY,
                    InitialValue = "Hamster, Rabbit",
                    CssClasses = "column",
                    SignalFormId = 7
                },
                // The eight form
                new SignalFormField()
                {
                    Id = 21,
                    InputType = InputType.RADIO_BUTTON_GROUP,
                    Label = "Select Option",
                    Property = "select_option",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "1",
                    CssClasses = "column",
                    SignalFormId = 8
                },
                new SignalFormField()
                {
                    Id = 22,
                    InputType = InputType.RADIO_BUTTON_GROUP_CALLBACK,
                    Label = "Select Choice",
                    Property = "select_choice",
                    PropertyType = PropertyType.NUMBER,
                    InitialValue = "0",
                    CssClasses = "column",
                    SignalFormId = 8
                },
                new SignalFormField()
                {
                    Id = 23,
                    InputType = InputType.CHECKBOX,
                    Label = "I agree to the general conditions",
                    Property = "general_conditions",
                    PropertyType = PropertyType.BOOLEAN,
                    InitialValue = "false",
                    CssClasses = "column",
                    SignalFormId = 8
                },
                new SignalFormField()
                {
                    Id = 24,
                    InputType = InputType.CHECKBOX_CALLBACK,
                    Label = "I agree with the service agreement (default: true)",
                    Property = "service_agreement",
                    PropertyType = PropertyType.BOOLEAN,
                    InitialValue = "true",
                    CssClasses = "column",
                    SignalFormId = 8
                },
                new SignalFormField()
                {
                    Id = 25,
                    InputType = InputType.SLIDE_TOGGLE,
                    Label = "Confirm agreements",
                    Property = "confirm_agreements",
                    PropertyType = PropertyType.BOOLEAN,
                    InitialValue = "false",
                    CssClasses = "column mb-1",
                    SignalFormId = 8
                },
                new SignalFormField()
                {
                    Id = 26,
                    InputType = InputType.SLIDE_TOGGLE_CALLBACK,
                    Label = "I read and understand all agreements",
                    Property = "read_agreements",
                    PropertyType = PropertyType.BOOLEAN,
                    InitialValue = "true",
                    CssClasses = "column mb-1",
                    SignalFormId = 8
                },
                // The ninth Form
                new SignalFormField()
                {
                    Id = 27,
                    InputType = InputType.INPUT_TEXT,
                    Label = "My Todo List",
                    Property = "title",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 9
                },
                new SignalFormField()
                {
                    Id = 28,
                    InputType = InputType.FORM_ARRAY,
                    Label = "FORM_ARRAY",
                    Property = "todos",
                    PropertyType = PropertyType.FORM_ARRAY,
                    InitialValue = "",
                    CssClasses = "",
                    SignalFormId = 9,
                    FormArrayId = 10, // Refers to Form 10 -> FORM_ARRAY
                },
                // The tenth Form
                new SignalFormField()
                {
                    Id = 29,
                    InputType = InputType.INPUT_TEXT,
                    Label = "Task",
                    Property = "task",
                    PropertyType = PropertyType.STRING,
                    InitialValue = "",
                    CssClasses = "column",
                    SignalFormId = 10
                },
                new SignalFormField()
                {
                    Id = 30,
                    InputType = InputType.SLIDE_TOGGLE,
                    Label = "Completed?",
                    Property = "completed",
                    PropertyType = PropertyType.BOOLEAN,
                    InitialValue = "false",
                    CssClasses = "column pt-1 ms-1",
                    SignalFormId = 10
                },

            };
        }

    }

}
