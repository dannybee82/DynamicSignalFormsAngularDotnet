import { FormType } from "../enums/form-type.enum";

export interface FormOverview {
	id: number,
	formType: FormType,
	title: string
}
