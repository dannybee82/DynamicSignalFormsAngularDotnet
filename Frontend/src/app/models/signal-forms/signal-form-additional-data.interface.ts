import { AttributeType } from "../enums/attribute-type.enum";

export interface SignalFormAdditionalData {
	attribute: string,
	attributeType: AttributeType,
	value: string
}
