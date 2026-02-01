import { PropertyType } from "../models/enums/property-type.enum";
import { FlexibleObject } from "../models/flexible-object/flexible-object.interface";
import { SignalFormField } from "../models/signal-forms/signal-form-field.interface";

export class SharedMethods {

    convertFormFieldsToFormModel(fields: SignalFormField[]): FlexibleObject {
        const obj: FlexibleObject = {};

        fields.forEach((field: SignalFormField) => {
          switch (field.propertyType) {
            case PropertyType.STRING:
              obj[field.property] = field.initialValue;
              break;
            case PropertyType.NUMBER:
              obj[field.property] = parseInt(field.initialValue);
              break;
            case PropertyType.BOOLEAN:
              obj[field.property] = field.initialValue === 'true' ? true : false;
              break;
            case PropertyType.FORM_ARRAY:
              obj[field.property] = field.formArray ? [] : [];
              break;
            case PropertyType.DATE:
              obj[field.property] =
                field.initialValue !== '' ? new Date(field.initialValue) : new Date();
              break;
            case PropertyType.STRING_ARRAY:
              obj[field.property] =
                field.initialValue !== ''
                  ? field.initialValue.split(',').map((item) => item.trim())
                  : [];
              break;
            case PropertyType.NUMBER_ARRAY:
              const splittedNumberArr: string[] =
                field.initialValue !== '' ? field.initialValue.split(',') : [];
              const numberArr: number[] = splittedNumberArr.map((item) => parseInt(item));
              obj[field.property] = numberArr;
              break;
            case PropertyType.BOOLEAN_ARRAY:
              const splittedBooleanArr: string[] =
                field.initialValue !== '' ? field.initialValue.split(',') : [];
              const booleanArr: boolean[] = splittedBooleanArr.map((item) =>
                item === 'true' ? true : false,
              );
              obj[field.property] = booleanArr;
              break;
          }
        });

        return obj;
    }

}