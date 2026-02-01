import { InputType } from "./input-type.enum";
import { ValidationType } from "./validation-type.enum";

export enum ShowFormType {
    NONE = "NONE",
    INPUT_TEXT = "INPUT_TEXT",
    INPUT_TEXT_AUTOCOMPLETE = "INPUT_TEXT_AUTOCOMPLETE",
    INPUT_NUMBER_INT = "INPUT_NUMBER_INT",
    INPUT_NUMBER_FLOAT = "INPUT_NUMBER_FLOAT",
    INPUT_DATE = "INPUT_DATE",
    INPUT_SELECT = "INPUT_SELECT",
    INPUT_SELECT_MULTI = "INPUT_SELECT_MULTI",
    INPUT_TEXTAREA = "INPUT_TEXTAREA",
    RADIO_BUTTON_GROUP = "RADIO_BUTTON_GROUP",
    CHECKBOX = "CHECKBOX",
    SLIDE_TOGGLE = "SLIDE_TOGGLE",
    FORM_ARRAY = "FORM_ARRAY"
}

export const allowedInputTypes: Map<ShowFormType, InputType[]> = new Map<ShowFormType, InputType[]>([
    [ShowFormType.NONE, []],
    [ShowFormType.INPUT_TEXT, [InputType.INPUT_TEXT, InputType.INPUT_TEXT_CALLBACK]],
    [ShowFormType.INPUT_TEXT_AUTOCOMPLETE, [InputType.INPUT_TEXT_AUTOCOMPLETE, InputType.INPUT_TEXT_AUTOCOMPLETE_CALLBACK]],
    [ShowFormType.INPUT_NUMBER_INT, [InputType.INPUT_NUMBER_INT, InputType.INPUT_NUMBER_INT_CALLBACK]],
    [ShowFormType.INPUT_NUMBER_FLOAT, [InputType.INPUT_NUMBER_FLOAT, InputType.INPUT_NUMBER_FLOAT_CALLBACK]],
    [ShowFormType.INPUT_DATE, [InputType.INPUT_DATE, InputType.INPUT_DATE_CALLBACK]],
    [ShowFormType.INPUT_SELECT, [InputType.INPUT_SELECT, InputType.INPUT_SELECT_CALLBACK]],
    [ShowFormType.INPUT_SELECT_MULTI, [InputType.INPUT_SELECT_MULTI, InputType.INPUT_SELECT_MULTI_CALLBACK]],
    [ShowFormType.INPUT_TEXTAREA, [InputType.INPUT_TEXTAREA, InputType.INPUT_TEXTAREA_CALLBACK]],
    [ShowFormType.RADIO_BUTTON_GROUP, [InputType.RADIO_BUTTON_GROUP, InputType.RADIO_BUTTON_GROUP_CALLBACK]],
    [ShowFormType.CHECKBOX, [InputType.CHECKBOX, InputType.CHECKBOX_CALLBACK]],
    [ShowFormType.SLIDE_TOGGLE, [InputType.SLIDE_TOGGLE, InputType.SLIDE_TOGGLE_CALLBACK]],
    [ShowFormType.FORM_ARRAY, [InputType.FORM_ARRAY]]
]);

export const allowedValidations: Map<ShowFormType, ValidationType[]> = new Map<ShowFormType, ValidationType[]>([
    [ShowFormType.NONE, []],
    [ShowFormType.INPUT_TEXT, [ValidationType.REQUIRED, ValidationType.MIN_LENGTH, ValidationType.MAX_LENGTH, ValidationType.PATTERN]],
    [ShowFormType.INPUT_TEXT_AUTOCOMPLETE, [ValidationType.REQUIRED, ValidationType.MIN_LENGTH, ValidationType.MAX_LENGTH, ValidationType.PATTERN]],
    [ShowFormType.INPUT_NUMBER_INT, [ValidationType.REQUIRED, ValidationType.MINIMUM_VALUE_INT, ValidationType.MAXIMUM_VALUE_INT]],
    [ShowFormType.INPUT_NUMBER_FLOAT, [ValidationType.REQUIRED, ValidationType.MINIMUM_VALUE_FLOAT, ValidationType.MAXIMUM_VALUE_FLOAT]],
    [ShowFormType.INPUT_DATE, [
        ValidationType.REQUIRED, 
        ValidationType.MINIMUM_TIME_DAYS, 
        ValidationType.MINIMUM_TIME_WEEKS, 
        ValidationType.MINIMUM_TIME_MONTHS, 
        ValidationType.MINIMUM_TIME_YEARS, 
        ValidationType.MAXIMUM_TIME_DAYS,
        ValidationType.MAXIMUM_TIME_WEEKS,
        ValidationType.MAXIMUM_TIME_MONTHS,
        ValidationType.MAXIMUM_TIME_YEARS,
        ValidationType.DATE_NOT_EQUAL,
        ValidationType.DATE_MUST_BE_EARLIER,
        ValidationType.DATE_MUST_BE_LATER]
    ],
    [ShowFormType.INPUT_SELECT, [ValidationType.REQUIRED, ValidationType.MIN_LENGTH, ValidationType.MAX_LENGTH, ValidationType.PATTERN]],
    [ShowFormType.INPUT_SELECT_MULTI, [ValidationType.REQUIRED, ValidationType.MIN_LENGTH, ValidationType.MAX_LENGTH, ValidationType.PATTERN]],
    [ShowFormType.INPUT_TEXTAREA, [ValidationType.REQUIRED, ValidationType.MIN_LENGTH, ValidationType.MAX_LENGTH]],
    [ShowFormType.RADIO_BUTTON_GROUP, [ValidationType.REQUIRED]],
    [ShowFormType.CHECKBOX, [ValidationType.REQUIRED]],
    [ShowFormType.SLIDE_TOGGLE, [ValidationType.REQUIRED]],
    [ShowFormType.FORM_ARRAY, []]
]);

export const inputTypeToShowFormType: Map<InputType, ShowFormType> = new Map<InputType, ShowFormType>([
    [InputType.INPUT_TEXT, ShowFormType.INPUT_TEXT],
    [InputType.INPUT_TEXT_CALLBACK, ShowFormType.INPUT_TEXT],
    [InputType.INPUT_TEXT_AUTOCOMPLETE, ShowFormType.INPUT_TEXT_AUTOCOMPLETE],
    [InputType.INPUT_TEXT_AUTOCOMPLETE_CALLBACK,  ShowFormType.INPUT_TEXT_AUTOCOMPLETE],
    [InputType.INPUT_NUMBER_INT, ShowFormType.INPUT_NUMBER_INT],
    [InputType.INPUT_NUMBER_INT_CALLBACK, ShowFormType.INPUT_NUMBER_INT],
    [InputType.INPUT_NUMBER_FLOAT, ShowFormType.INPUT_NUMBER_FLOAT],
    [InputType.INPUT_NUMBER_FLOAT_CALLBACK, ShowFormType.INPUT_NUMBER_FLOAT],
    [InputType.INPUT_DATE, ShowFormType.INPUT_DATE],
    [InputType.INPUT_DATE_CALLBACK, ShowFormType.INPUT_DATE],
    [InputType.INPUT_SELECT, ShowFormType.INPUT_SELECT],
    [InputType.INPUT_SELECT_CALLBACK, ShowFormType.INPUT_SELECT],
    [InputType.INPUT_SELECT_MULTI, ShowFormType.INPUT_SELECT_MULTI],
    [InputType.INPUT_SELECT_MULTI_CALLBACK, ShowFormType.INPUT_SELECT_MULTI],
    [InputType.INPUT_TEXTAREA, ShowFormType.INPUT_TEXTAREA],
    [InputType.INPUT_TEXTAREA_CALLBACK, ShowFormType.INPUT_TEXTAREA],
    [InputType.RADIO_BUTTON_GROUP, ShowFormType.RADIO_BUTTON_GROUP],
    [InputType.RADIO_BUTTON_GROUP_CALLBACK, ShowFormType.RADIO_BUTTON_GROUP],
    [InputType.CHECKBOX, ShowFormType.CHECKBOX],
    [InputType.CHECKBOX_CALLBACK, ShowFormType.CHECKBOX],
    [InputType.SLIDE_TOGGLE, ShowFormType.SLIDE_TOGGLE],
    [InputType.SLIDE_TOGGLE_CALLBACK, ShowFormType.SLIDE_TOGGLE],
    [InputType.FORM_ARRAY, ShowFormType.FORM_ARRAY]
]);
