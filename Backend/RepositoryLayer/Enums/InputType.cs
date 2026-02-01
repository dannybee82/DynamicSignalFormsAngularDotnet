using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Enums
{

    public enum InputType
    {
        UNKNOWN = 0,
        INPUT_TEXT = 1,
        INPUT_TEXT_CALLBACK = 2,
        INPUT_TEXT_AUTOCOMPLETE = 3,
        INPUT_TEXT_AUTOCOMPLETE_CALLBACK = 4,
        INPUT_NUMBER_INT = 5,
        INPUT_NUMBER_INT_CALLBACK = 6,
        INPUT_NUMBER_FLOAT = 7,
        INPUT_NUMBER_FLOAT_CALLBACK = 8,
        INPUT_DATE = 9,
        INPUT_DATE_CALLBACK = 10,
        INPUT_SELECT = 11,
        INPUT_SELECT_CALLBACK = 12,
        INPUT_SELECT_MULTI = 13,
        INPUT_SELECT_MULTI_CALLBACK = 14,
        INPUT_TEXTAREA = 15,
        INPUT_TEXTAREA_CALLBACK = 16,
        RADIO_BUTTON_GROUP = 17,
        RADIO_BUTTON_GROUP_CALLBACK = 18,
        CHECKBOX = 19,
        CHECKBOX_CALLBACK = 20,
        SLIDE_TOGGLE = 21,
        SLIDE_TOGGLE_CALLBACK = 22,
        FORM_ARRAY = 23
    }

}
