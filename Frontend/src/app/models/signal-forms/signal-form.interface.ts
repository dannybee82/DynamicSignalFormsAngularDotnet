import { FormType } from "../enums/form-type.enum";
import { SignalFormField } from "./signal-form-field.interface";

export interface SignalForm {
	id?: number,
	formType: FormType,
	title: string,
	cssClasses: string,
	formFields: SignalFormField[]
}
