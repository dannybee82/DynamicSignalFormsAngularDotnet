import { Component, effect, inject, Injector, model, ModelSignal, OnInit, output, OutputEmitterRef, runInInjectionContext, signal, WritableSignal } from '@angular/core';
import { FlexibleObject } from '../../models/flexible-object/flexible-object.interface';
import { FieldTree, form, max, maxLength, min, minLength, pattern, required, validate, FormField } from '@angular/forms/signals';
import { SignalForm } from '../../models/signal-forms/signal-form.interface';
import { FormType } from '../../models/enums/form-type.enum';
import { SignalFormField } from '../../models/signal-forms/signal-form-field.interface';
import { maximumTimeMap, minimumTimeMap, ValidationType } from '../../models/enums/validation-type.enum';
import { SignalFormValidation } from '../../models/signal-forms/signal-form-validation.interface';
import { default as moment } from 'moment'
import { AllMaterialsModule } from '../../all-materials.module';
import { InputType } from '../../models/enums/input-type.enum';
import { TypeOfValue } from '../../models/enums/type-of-value.enum';
import { SignalFormAdditionalData } from '../../models/signal-forms/signal-form-additional-data.interface';
import { AttributeType } from '../../models/enums/attribute-type.enum';
import { ValueLabelPair } from '../../models/template/value-label-pair.interface';
import { SignalFormOption } from '../../models/signal-forms/signal-form-option.interface';
import { SharedMethods } from '../../shared/shared-methods.class';

@Component({
  selector: 'app-dynamic-signal-form-array',
  imports: [AllMaterialsModule, FormField],
  templateUrl: './dynamic-signal-form-array.component.html',
  styleUrl: './dynamic-signal-form-array.component.scss',
})
export class DynamicSignalFormArrayComponent extends SharedMethods implements OnInit {
  private injector = inject(Injector);

  formData: ModelSignal<SignalForm> = model<SignalForm>({
    formType: FormType.UNKNOWN,
    title: '',
    cssClasses: '',
    formFields: []
  });
  formModel: ModelSignal<{ formArray: FlexibleObject[] }> = model({ formArray: [{}]})
  form!: any;
  private _defaultObject: WritableSignal<FlexibleObject> = signal({});

  private _minimumTimeMap = minimumTimeMap;
  private _maximumTimeMap = maximumTimeMap;

  formValueChange: OutputEmitterRef<FlexibleObject[] | undefined> = output();

  ngOnInit(): void {
    let previousValue: any = undefined;

    // Create form within injection context
    this.form = runInInjectionContext(this.injector, () => {
      const singleModel: FlexibleObject = this.convertFormFieldsToFormModel(this.formData().formFields);
      this._defaultObject.set(singleModel);
      this.formModel.set({ formArray: [singleModel] });

      effect(() => {
        if (JSON.stringify(this.form().value()) !== JSON.stringify(previousValue)) {  
          try {
          previousValue = structuredClone(this.form().value().formArray); // Deep clone 
          const values: FlexibleObject[] = this.form().value().formArray;

          values.forEach(item => {
            item = structuredClone(item);
          });

          this.formValueChange.emit(values);
          } catch {}
        }
      });

      return form(this.formModel, (f) => {        
        this.formData().formFields.forEach((field: SignalFormField) => {
          const fieldRef = (f as any)[field.property];  
          
          if (fieldRef) {
            field.validations.forEach((validator: SignalFormValidation) => {  
              switch (validator.validation) {  
                case ValidationType.REQUIRED:  
                  required(fieldRef, { message: `${field.label} is required` });  
                  break;  
                case ValidationType.MIN_LENGTH:  
                  if (validator.value) {  
                    minLength(fieldRef, parseInt(validator.value), { message: `${field.label} is too short` });  
                  }  
                  break;  
                case ValidationType.MAX_LENGTH:  
                  if (validator.value) {  
                    maxLength(fieldRef, parseInt(validator.value), { message: `${field.label} is too long` });  
                  }  
                  break;  
                case ValidationType.MINIMUM_VALUE_INT:
                  if(validator.value) {
                    min(fieldRef, parseInt(validator.value), { message: `${field.label} is too low` });
                  }
                  break;
                case ValidationType.MAXIMUM_VALUE_INT:
                  if(validator.value) {
                    max(fieldRef, parseInt(validator.value), { message: `${field.label} is too high` });
                  }
                  break;
                case ValidationType.PATTERN:
                  if(validator.value) {
                    pattern(fieldRef, new RegExp(validator.value), { message: `${field.label}: invalid pattern` });
                  }
                  break;
                case ValidationType.MINIMUM_VALUE_FLOAT:
                  if(validator.value) {
                    min(fieldRef, parseFloat(validator.value), { message: `${field.label} is too low` });
                  }
                  break;
                case ValidationType.MAXIMUM_VALUE_FLOAT:
                  if(validator.value) {
                    max(fieldRef, parseFloat(validator.value), { message: `${field.label} is too high` });
                  }
                  break;
                case ValidationType.MINIMUM_TIME_DAYS || ValidationType.MINIMUM_TIME_WEEKS || ValidationType.MINIMUM_TIME_MONTHS || ValidationType.MINIMUM_TIME_YEARS:
                  const minimumUnit: string | undefined = this._minimumTimeMap.get(validator.validation);
                  if(validator.value && minimumUnit) {
                    //Custom validator                    
                    validate(fieldRef, ({value}) => {
                      const currentDate: moment.Moment = moment();
                      const compareDate: moment.Moment = moment(new Date(value() as string));

                      const compareUnit = minimumUnit as moment.unitOfTime.DurationConstructor;

                      const difference: number = currentDate.diff(compareDate, compareUnit);

                      if(difference < parseInt(validator.value)) {
                        return { kind: 'invalid-minimum-time', message: `The difference in ${minimumUnit} is too low` };
                      }

                      return undefined;
                    });
                  }
                  break;
                case ValidationType.MAXIMUM_TIME_DAYS || ValidationType.MAXIMUM_TIME_WEEKS || ValidationType.MAXIMUM_TIME_MONTHS || ValidationType.MAXIMUM_TIME_YEARS:
                  const maximumUnit: string | undefined = this._maximumTimeMap.get(validator.validation);
                  if(validator.value && maximumUnit) {
                    //Custom validator                    
                    validate(fieldRef, ({value}) => {
                      const currentDate: moment.Moment = moment();
                      const compareDate: moment.Moment = moment(new Date(value() as string));

                      const compareUnit = maximumUnit as moment.unitOfTime.DurationConstructor;

                      const difference: number = currentDate.diff(compareDate, compareUnit);

                      if(difference > parseInt(validator.value)) {
                        return { kind: 'invalid-maximum-time', message: `The difference in ${maximumUnit} is too high` };
                      }

                      return undefined;
                    });
                  }
                  break;
                case ValidationType.DATE_NOT_EQUAL:
                  if(validator.value) {
                     //Custom validator                    
                    validate(fieldRef, ({value}) => {
                      const compareCurrentField: moment.Moment = moment(new Date(value() as string));
                      const compareOtherField: moment.Moment = moment(this.getValue(validator.value) as Date);                

                      const dayUnit:  moment.unitOfTime.DurationConstructor = 'days';
                      const difference: number = compareCurrentField.diff(compareOtherField, dayUnit);

                      if(difference === 0 && compareCurrentField.day() === compareOtherField.day()) {
                        return { kind: 'dates-are-equal', message: `${field.label} is equal to ${this.getLabelByProperty(validator.value)}` };
                      }

                      return undefined;
                    });
                  }
                  break;
                case ValidationType.DATE_MUST_BE_EARLIER:
                  if(validator.value) {
                     //Custom validator                    
                    validate(fieldRef, ({value}) => {
                      const compareCurrentField: moment.Moment = moment(new Date(value() as string));
                      const compareOtherField: moment.Moment = moment(this.getValue(validator.value) as Date);

                      const difference: number = compareCurrentField.clone()
                        .startOf('day')
                        .diff(compareOtherField.clone()
                        .startOf('day'), 'days');

                      if(difference > 0) {
                        return { kind: 'dates-too-late', message: `${field.label} is later than ${this.getLabelByProperty(validator.value)}` };
                      }

                      return undefined;
                    });
                  }
                  break;
                case ValidationType.DATE_MUST_BE_LATER:
                  if(validator.value) {
                     //Custom validator                    
                    validate(fieldRef, ({value}) => {
                      const compareCurrentField: moment.Moment = moment(new Date(value() as string));
                      const compareOtherField: moment.Moment = moment(this.getValue(validator.value) as Date);

                      const difference: number = compareCurrentField.clone()
                        .startOf('day')
                        .diff(compareOtherField.clone()
                        .startOf('day'), 'days');

                      if(difference < 0) {
                        return { kind: 'dates-too-early', message: `${field.label} is earlier than ${this.getLabelByProperty(validator.value)}` };
                      }

                      return undefined;
                    });
                  }
                  break;
              }  
            });
          }
        });  
      });
    });    
  }

  getValue(property: string): string | number | boolean | Date {
    const currentValues: FlexibleObject = this.form().value();
    const p = property as keyof FlexibleObject;

    if(Object.prototype.toString.call(currentValues[p]) === '[object Array]') {
      return (currentValues[p] as string[]).join(', ');
    }

    return currentValues[p];
  }

  getfieldTypeEnum(): typeof InputType {
    return InputType;
  }

  getField(index: number, property: string): FieldTree<string> {
    const form = (this.form as FieldTree<FlexibleObject>);
    const formArrProperty = 'formArray' as keyof FlexibleObject;
    const arr: FlexibleObject[] = form[formArrProperty] as FlexibleObject[];
    return (arr[index] as FieldTree<FlexibleObject>)[property]; 
  }

  private getLabelByProperty(property: string): string {
    if(this.formData()) {
      if(this.formData().formFields.length > 0) {
        const fields: SignalFormField[] = this.formData().formFields;
        const target: SignalFormField | undefined = fields.find(item => item.property === property);

        if(target) {
          return target.label;
        }
      }
    }

    return '';
  }

  getFilteredOptions(property: string, value: string): string[] {
    if(this.formData()) {
      const fields: SignalFormField[] = this.formData()!.formFields;
      const field: SignalFormField | undefined = fields.find(item => item.property === property);

      if(field) {
        const options: string[] = field.options ? field.options.map(item => {
          return item.typeOfValue === TypeOfValue.UNKNOWN ? item.label : item.value;
        }) : [];
        
        if(options) {
          const arr: string[] = [];
          options.forEach(item => {
            if(item.toLowerCase().indexOf(value) > -1 ) {
              arr.push(item);
            }
          });
          return arr;
        }
      }
    }

    return [];
  }

  getOptions(property: string): (string | number | boolean)[] {
    if(this.formData()) {
      const fields: SignalFormField[] = this.formData()!.formFields;
      const field: SignalFormField | undefined = fields.find(item => item.property === property);

      if(field) {
        return field.options ? field.options.map(item => {
          return item.typeOfValue === TypeOfValue.UNKNOWN ? item.label : item.value;
        }) : [];
      }
    }

    return [];
  }

  getAttribute(property: string, attribute: string): string | number | boolean | undefined {
    if(this.formData()) {
      const fields: SignalFormField[] = this.formData()!.formFields;
      const field: SignalFormField | undefined = fields.find(item => item.property === property);

      if(field) {
        const additionalData: SignalFormAdditionalData[] = field.additionalData;
        const data: SignalFormAdditionalData | undefined = additionalData.find(item => item.attribute === attribute);

        if(data) {
          switch(data.attributeType) {
            case AttributeType.STRING:
              return data.value;
            case AttributeType.NUMBER:
              return parseInt(data.value);
            case AttributeType.BOOLEAN:
              return data.value === 'true' ? true : false;
          }
        }
      }
    }

    return undefined;
  }

  getKeyValuePairs(property: string): ValueLabelPair[] {
      if(this.formData()) {
        const fields: SignalFormField[] = this.formData()!.formFields;
        const field: SignalFormField | undefined = fields.find(item => item.property === property);
  
        if(field) {
          const fieldOptions = field.options ? field.options : [];
  
          if(fieldOptions) {
            const arr: ValueLabelPair[] = [];
  
            fieldOptions.forEach((option: SignalFormOption) => {
              switch(option.typeOfValue) {
                case TypeOfValue.UNKNOWN:
                  arr.push({ value: option.label, label: option.label });
                  break;
                case TypeOfValue.STRING:
                  arr.push({ value: option.value, label: option.label });
                  break;
                case TypeOfValue.NUMBER:
                  const parsed: number = parseInt(option.value);
                  arr.push({ value: parsed, label: option.label });
                  break;
                case TypeOfValue.BOOLEAN:
                  const value: boolean = option.value === 'true' ? true : false;
                  arr.push({ value: value, label: option.label });
                  break;
              }
            });
  
            return arr;
          }
        }
      }
      
    return [];
  }

  addItem(): void {
    const newArr: FlexibleObject[] = structuredClone(this.formModel().formArray);
    newArr.push(this._defaultObject());
    this.formModel.set({formArray: newArr});
  }

  removeItem(index: number): void {
    let newArr: FlexibleObject[] = structuredClone(this.formModel().formArray);

    if(newArr.length > 0 && index < newArr.length) {
      newArr.splice(index, 1);
      this.formModel.set({formArray: newArr});
    }
  }

  swapItem(index: number, isDownwards: boolean): void {
    const newArr: FlexibleObject[] = structuredClone(this.formModel().formArray);
    const currentIndex: number = index;
    const nextIndex: number = isDownwards ? index + 1 : index - 1;

    if(newArr.length >= 2 && currentIndex >= 0 && currentIndex < newArr.length && nextIndex >= 0 && nextIndex < newArr.length) {
      const firstItem: FlexibleObject = newArr[currentIndex];
      const secondItem: FlexibleObject = newArr[nextIndex];

      newArr[currentIndex] = secondItem;
      newArr[nextIndex] = firstItem;
      this.formModel.set({formArray: newArr});
    }
  }
  
}