import { Component, inject, input, InputSignal, model, ModelSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { allowedValidations, ShowFormType } from '../../../models/enums/show-form-type.enum';
import { SignalFormValidation } from '../../../models/signal-forms/signal-form-validation.interface';
import { ValidationType } from '../../../models/enums/validation-type.enum';
import { form, validate, FormField, required } from '@angular/forms/signals';
import { AllMaterialsModule } from '../../../all-materials.module';
import { SelectedValidationType } from '../../../models/template/selected-validation-type.interface';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-validations',
  imports: [AllMaterialsModule, FormField],
  templateUrl: './validations.component.html',
  styleUrl: './validations.component.scss',
})
export class ValidationsComponent implements OnInit {

  validations: ModelSignal<SignalFormValidation[]> = model<SignalFormValidation[]>([]);
  formType: InputSignal<ShowFormType> = input.required<ShowFormType>();
  
  availableValidations: WritableSignal<ValidationType[]> = signal([]);

  formModel: WritableSignal<SelectedValidationType> = signal({
    selection: ValidationType.UNKNOWN
  });
  selectedValidator = form(this.formModel);

  allowedValidations = allowedValidations;

  validationValues: WritableSignal<SignalFormValidation> = signal({
    validation: ValidationType.UNKNOWN,
    value: ''
  });
  validationForm = form(this.validationValues, (f) => {
    validate(f.validation, ({ value }) => {
      if(value() === ValidationType.UNKNOWN){
        return { kind: 'validation-type-unknown', message: 'ValidationType is unknown' };
      }

      return undefined;
    }),
    required(f.value)
  });

  private toastr = inject(ToastrService);
  
  ngOnInit(): void {
    if(this.validations()) {
      if(this.validations().length === 0) {
        this.addRequiredValidator();
      }
    }

    const allowedValidations: ValidationType[] | undefined = this.allowedValidations.get(this.formType());

    if(allowedValidations) {
      this.availableValidations.set(allowedValidations);
    }
  }

  getEnum(): typeof ValidationType {
    return ValidationType;
  }

  addRequiredValidator(): void {
    const isNotAdded: boolean = structuredClone(this.validations()).filter(item => item.validation === ValidationType.REQUIRED).length === 0;

    if(isNotAdded) {
       this.validations().push({
        validation: ValidationType.REQUIRED,
        value: ''
      });
    } else {
      this.toastr.error('Required Validator has been already added');
    }   

    this.selectedValidator.selection().setControlValue(ValidationType.UNKNOWN);
  }

  addValidator(event: SubmitEvent): void {
    event.preventDefault();

    this.validationForm.validation().setControlValue(this.selectedValidator.selection().value());

    if(this.validationForm().valid()) {
      const isNotAdded: boolean = structuredClone(this.validations()).filter(item => item.validation === this.selectedValidator.selection().value()).length === 0;

      if(isNotAdded) {
        const data: SignalFormValidation = this.validationForm().value();
        this.validations().push(data);
      } else {
        this.toastr.error('The Validator has been already added');
      }

      this.selectedValidator.selection().setControlValue(ValidationType.UNKNOWN);
      this.resetDefaultValues();
    } else {
      const errors: string = this.validationForm().errorSummary().filter(item => item.message !== undefined).join('<br />');
      this.toastr.error(errors, '', { enableHtml: true });
    }
  }

  removeValidator(index: number): void {
    if(index < this.validations().length && index >= 0) {      
      const arr: SignalFormValidation[] = structuredClone(this.validations());
      arr.splice(index, 1);
      this.validations.set(arr);
    }
  }

  private resetDefaultValues(): void {
    this.validationValues.set({
      validation: ValidationType.UNKNOWN,
      value: ''
    });
  }

}