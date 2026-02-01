import { Component, inject, input, InputSignal, OnDestroy, OnInit, output, OutputEmitterRef, signal, WritableSignal } from '@angular/core';
import { FormArraysService } from '../../../services/formArrays/form-arrays.service';
import { ToastrService } from 'ngx-toastr';
import { AllMaterialsModule } from '../../../all-materials.module';
import { SignalFormField } from '../../../models/signal-forms/signal-form-field.interface';
import { ShowFormType } from '../../../models/enums/show-form-type.enum';
import { InputType } from '../../../models/enums/input-type.enum';
import { PropertyType } from '../../../models/enums/property-type.enum';
import { form, required, validate, FormField } from '@angular/forms/signals';
import { FormArrayOverview } from '../../../models/overview/form-array-overview.interface';

@Component({
  selector: 'app-create-form-array',
  imports: [AllMaterialsModule, FormField],
  templateUrl: './create-form-array.component.html',
  styleUrl: './create-form-array.component.scss',
})
export class CreateFormArrayComponent implements OnInit, OnDestroy {

  signalFormField: InputSignal<SignalFormField | undefined> = input<SignalFormField | undefined>(undefined);
  formType: InputSignal<ShowFormType> = input.required<ShowFormType>();

  data: OutputEmitterRef<SignalFormField> = output<SignalFormField>();

  allowedInputTypes: WritableSignal<InputType[]> = signal([]);
  isUpdateMode: WritableSignal<boolean> = signal(false);

  availableOptions: WritableSignal<FormArrayOverview[]> = signal<FormArrayOverview[]>([]);
  isLoaded: WritableSignal<boolean> = signal(false);
  formArrayIdSelected: WritableSignal<number> = signal(0);

  defaultValues: WritableSignal<SignalFormField> = signal({
    inputType: InputType.FORM_ARRAY,
    label: '',
    property: '',
    propertyType: PropertyType.FORM_ARRAY,
    initialValue: '',
    cssClasses: 'row',
    validations: [],
    options: [],
    additionalData: [],
    formArrayId: undefined
  });

  inputForm = form<SignalFormField>(this.defaultValues, (f) => {
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

  private formArraysService = inject(FormArraysService);
  private toastr = inject(ToastrService);

  ngOnInit(): void {
    if(this.signalFormField()) {      
      //Update fields.
      this.isUpdateMode.set(true);
      this.inputForm().value.set(this.signalFormField()!);
    } else { 
      this.isUpdateMode.set(false);   
    }

    this.getData();
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
      additionalData: [],
      formArrayId: undefined
    });

    this.formArrayIdSelected.set(0);
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
  
  selectFormArray(id: number): void {
    this.defaultValues().formArrayId = id;
    this.formArrayIdSelected.set(id);
  }

  private getData(): void {
    this.formArraysService.getAll<FormArrayOverview>().subscribe({
      next: (data: FormArrayOverview[]) => {
        this.availableOptions.set(data);
      },
      error: () => {
        this.toastr.error('Can\'t fetch available Form Arrays');
      },
      complete: () => {
        this.isLoaded.set(true);
      }
    });
  }

}