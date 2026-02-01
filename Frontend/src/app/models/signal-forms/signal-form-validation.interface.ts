import { ValidationType } from "../enums/validation-type.enum";

export interface SignalFormValidation {
	validation: ValidationType,
	value: string
}
