import { InputType } from "../enums/input-type.enum";
import { PropertyType } from "../enums/property-type.enum";
import { SignalFormAdditionalData } from "./signal-form-additional-data.interface";
import { SignalFormOption } from "./signal-form-option.interface";
import { SignalFormValidation } from "./signal-form-validation.interface";
import { SignalForm } from "./signal-form.interface";

export interface SignalFormField {
	id?: number,
	inputType: InputType,
	label: string,
	property: string,
	propertyType: PropertyType,
	initialValue: string,
	cssClasses: string,
	validations: SignalFormValidation[],
	options: SignalFormOption[],
	additionalData: SignalFormAdditionalData[],
	formArrayId?: number,
	formArray?: SignalForm
}
