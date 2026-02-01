export enum PropertyType {
    UNKNOWN = "UNKNOWN",
    STRING = "STRING",
    NUMBER = "NUMBER",
    BOOLEAN = "BOOLEAN",
    STRING_ARRAY = "STRING_ARRAY",
    NUMBER_ARRAY = "NUMBER_ARRAY",
    BOOLEAN_ARRAY = "BOOLEAN_ARRAY",
    OBJECT = "OBJECT",
    OBJECT_ARRAY = "OBJECT_ARRAY",
    FORM_ARRAY = "FORM_ARRAY",
    DATE = "DATE"
}

export const allowedPropertyTypesRadioGroup: PropertyType[] = [
    PropertyType.STRING,
    PropertyType.NUMBER,
    PropertyType.BOOLEAN
];