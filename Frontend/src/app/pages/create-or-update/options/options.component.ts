import { Component, inject, input, InputSignal, model, ModelSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { SignalFormOption } from '../../../models/signal-forms/signal-form-option.interface';
import { ShowFormType } from '../../../models/enums/show-form-type.enum';
import { availableTypes, TypeOfValue } from '../../../models/enums/type-of-value.enum';
import { form, required, validate, FormField } from '@angular/forms/signals';
import { ToastrService } from 'ngx-toastr';
import { AllMaterialsModule } from '../../../all-materials.module';

@Component({
  selector: 'app-options',
  imports: [AllMaterialsModule, FormField],
  templateUrl: './options.component.html',
  styleUrl: './options.component.scss',
})
export class OptionsComponent implements OnInit {

  options: ModelSignal<SignalFormOption[]> = model<SignalFormOption[]>([]);
  formType: InputSignal<ShowFormType> = input.required<ShowFormType>();

  formModel: WritableSignal<SignalFormOption> = signal({
    label: '',
    value: '',
    typeOfValue: TypeOfValue.UNKNOWN
  });
  form = form(this.formModel, (f) => {
    required(f.label),
    validate(f.value, ({ value }) => {
      if(this.formType() === this.getEnum().RADIO_BUTTON_GROUP) {
        if(value().trim() === '') {
          return { kind: 'no-value-for-option', message: 'There is an empty value for an option' };
        }
      }

      return undefined;
    }),
    validate(f.typeOfValue, ({ value }) => {
      if(this.formType() === this.getEnum().RADIO_BUTTON_GROUP) {
        if(value() === TypeOfValue.UNKNOWN) {
          return { kind: 'typeofvalue-unknown', message: 'The type of the value is unknown' };
        }
      }

      return undefined;
    }),
    validate(f.value, ({ value, valueOf }) => {
      if(this.formType() === this.getEnum().RADIO_BUTTON_GROUP) {
        if(valueOf(f.typeOfValue) === TypeOfValue.NUMBER) {
          try {
            const pattern: RegExp = /^\d{1,}$/;

            if(!value().match(pattern)) {
              return { kind: 'number-invalid', message: 'The value doesn\'t contain numbers' };
            }

            const parsed: number = parseInt(value());

            if(isNaN(parsed)) {
              return { kind: 'number-is-nan', message: 'The number is invalid' };
            }
          } catch {
            return { kind: 'parse-error', message: 'Can\t parse value to number' };
          }          
        }
        if(valueOf(f.typeOfValue) === TypeOfValue.BOOLEAN) {
          const allowedValues: string[] = ['true', 'false'];
          const index: number = allowedValues.findIndex(item => item === value());

          if(index === -1) {
            return { kind: 'boolean invalid', message: 'Invalid boolean - allowed are: true or false' };
          }
        }
      }

      return undefined;
    })
  });

  availableTypes = availableTypes;

  private toastr = inject(ToastrService);

  ngOnInit(): void {

  }

  getEnum(): typeof ShowFormType {
    return ShowFormType;
  }

  submit(event: SubmitEvent): void {
    event.preventDefault();

    if(this.form().valid()) {
      const data: SignalFormOption = this.form().value();
      this.options().push(data);
      this.resetData();
    } else {
      const errors: string = this.form().errorSummary().filter(item => item.message !== undefined).join('<br />');
      this.toastr.error(errors, '', { enableHtml: true });
    }
  }

  removeOption(index: number): void {
    if(index >= 0 && index < this.options().length) {
      const arr: SignalFormOption[] = structuredClone(this.options());
      arr.splice(index, 1);
      this.options.set(arr);
    }
  }

  private resetData(): void {
    this.formModel.set({
      label: '',
      value: '',
      typeOfValue: TypeOfValue.UNKNOWN
    });
  }

}
