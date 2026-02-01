export enum AttributeType {
    UNKNOWN = "UNKNOWN",
    STRING = "STRING",
    NUMBER = "NUMBER",
    BOOLEAN = "BOOLEAN"
}

export const allowedAttributeTypes: AttributeType[] = [
    AttributeType.STRING,
    AttributeType.NUMBER,
    AttributeType.BOOLEAN
];