import { Component, inject, input, InputSignal, OnDestroy, OnInit, output, OutputEmitterRef, signal, WritableSignal } from '@angular/core';
import { SignalFormField } from '../../../models/signal-forms/signal-form-field.interface';
import { form, required, validate, FormField } from '@angular/forms/signals';
import { InputType } from '../../../models/enums/input-type.enum';
import { PropertyType } from '../../../models/enums/property-type.enum';
import { allowedInputTypes, ShowFormType } from '../../../models/enums/show-form-type.enum';
import { AllMaterialsModule } from '../../../all-materials.module';
import { ValidationsComponent } from '../validations/validations.component';
import { ToastrService } from 'ngx-toastr';
import { AdditionalDataComponent } from '../additional-data/additional-data.component';

@Component({
  selector: 'app-create-textarea',
  imports: [AllMaterialsModule, FormField, ValidationsComponent, AdditionalDataComponent],
  templateUrl: './create-textarea.component.html',
  styleUrl: './create-textarea.component.scss',
})
export class CreateTextareaComponent  implements OnInit, OnDestroy {

  signalFormField: InputSignal<SignalFormField | undefined> = input<SignalFormField | undefined>(undefined);
  formType: InputSignal<ShowFormType> = input.required<ShowFormType>();

  data: OutputEmitterRef<SignalFormField> = output<SignalFormField>();

  allowedInputTypes: WritableSignal<InputType[]> = signal([]);
  isUpdateMode: WritableSignal<boolean> = signal(false);

  defaultValues: WritableSignal<SignalFormField> = signal({
    inputType: InputType.UNKNOWN,
    label: '',
    property: '',
    propertyType: PropertyType.UNKNOWN,
    initialValue: '',
    cssClasses: 'column',
    validations: [],
    options: [],
    additionalData: []
  });

  inputForm = form<SignalFormField>(this.defaultValues, (f) => {
    required(f.label),
    required(f.property),
    required(f.propertyType),
    validate(f.inputType, ({ value }) => {
      if(value() === InputType.UNKNOWN) {
        return { kind: 'unknown-input-type', message: 'InputType is unknown' };
      }

      return undefined;
    }),
    validate(f.propertyType, ({ value }) => {
      if(value() === PropertyType.UNKNOWN) {
        return { kind: 'unknown-property-type', message: 'PropertyType is unknown' };
      }

      return undefined;
    })
  });

  private _allowedInputTypes = allowedInputTypes;

  private toastr = inject(ToastrService);

  ngOnInit(): void {
    if(this.signalFormField()) {      
      //Update fields.
      this.isUpdateMode.set(true);
      this.inputForm().value.set(this.signalFormField()!);
    } else { 
      this.isUpdateMode.set(false);   
    }

    const allowedInputTypes: InputType[] | undefined = this._allowedInputTypes.get(this.formType());
    this.allowedInputTypes.set(allowedInputTypes ? allowedInputTypes : []);

    if(this.allowedInputTypes().length > 0 && !this.isUpdateMode()) {
      this.inputForm.inputType().setControlValue(this.allowedInputTypes()[0]);
    }   

    this.inputForm.propertyType().setControlValue(PropertyType.STRING); 
  }

  ngOnDestroy(): void {
    this.defaultValues.set({
      inputType: InputType.UNKNOWN,
      label: '',
      property: '',
      propertyType: PropertyType.UNKNOWN,
      initialValue: '',
      cssClasses: 'column',
      validations: [],
      options: [],
      additionalData: []
    });
  }

  submit(event: SubmitEvent): void {
    event.preventDefault();

    if(this.inputForm().valid()) {
      this.data.emit(this.inputForm().value());      
    } else {
      const error: string = this.inputForm().errorSummary().filter(item => item.message !== undefined).join('<br />');
      this.toastr.error(error, '', { enableHtml: true});
    }
  }

  getEnum(): typeof InputType {
    return InputType;
  }

}
