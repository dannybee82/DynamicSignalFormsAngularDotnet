import { Component, inject, input, InputSignal, model, ModelSignal, OnDestroy, OnInit, signal, WritableSignal } from '@angular/core';
import { SignalFormAdditionalData } from '../../../models/signal-forms/signal-form-additional-data.interface';
import { ShowFormType } from '../../../models/enums/show-form-type.enum';
import { AllMaterialsModule } from '../../../all-materials.module';
import { allowedAttributeTypes, AttributeType } from '../../../models/enums/attribute-type.enum';
import { form, required, validate, FormField } from '@angular/forms/signals';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-additional-data',
  imports: [AllMaterialsModule, FormField],
  templateUrl: './additional-data.component.html',
  styleUrl: './additional-data.component.scss',
})
export class AdditionalDataComponent implements OnInit, OnDestroy {

  additionalData: ModelSignal<SignalFormAdditionalData[]> = model<SignalFormAdditionalData[]>([]);
  formType: InputSignal<ShowFormType> = input.required<ShowFormType>();

  formModel: WritableSignal<SignalFormAdditionalData> = signal({
    attribute: '',
    attributeType: AttributeType.NUMBER,
    value: ''
  });
  form = form(this.formModel, (f) => {
    required(f.attribute),
    required(f.value),
    validate(f.attributeType, ({ value }) => {
      if(value() === AttributeType.UNKNOWN) {
        return { kind: 'unknown-attribute-type', message: 'The AttributeType is unknown' };
      }

      return undefined;
    })
  });

  allowedAttributeTypes: AttributeType[] = allowedAttributeTypes;

  private toastr = inject(ToastrService);

  ngOnInit(): void {

  }

  ngOnDestroy(): void {
    this.resetData();
  }
  
  submit(event: SubmitEvent): void {
    event.preventDefault();

    if(this.form().valid()) {
      const data: SignalFormAdditionalData = this.form().value();
      this.additionalData().push(data);
      this.resetData();
    } else {
      const errors: string = this.form().errorSummary().filter(item => item.message !== undefined).join('<br />');
      this.toastr.error(errors, '', { enableHtml: true });
    }
  }

  removeData(index: number): void {
    if(index >= 0 && index < this.additionalData().length) {
      const arr: SignalFormAdditionalData[] = structuredClone(this.additionalData());
      arr.splice(index, 1);
      this.additionalData.set(arr);
    }
  }

  private resetData(): void {
    this.formModel.set({
      attribute: '',
      attributeType: AttributeType.NUMBER,
      value: ''
    });
  }

}
