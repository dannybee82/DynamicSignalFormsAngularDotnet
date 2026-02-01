import { Component, inject, input, InputSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { DynamicSignalFormComponent } from '../../components/dynamic-signal-form/dynamic-signal-form.component';
import { SignalForm } from '../../models/signal-forms/signal-form.interface';
import { SignalFormsService } from '../../services/signalForms/signal-forms.service';
import { ToastrService } from 'ngx-toastr';
import { FlexibleObject } from '../../models/flexible-object/flexible-object.interface';
import { SignalFormField } from '../../models/signal-forms/signal-form-field.interface';
import { PropertyType } from '../../models/enums/property-type.enum';
import { SharedMethods } from '../../shared/shared-methods.class';
import { FormType } from '../../models/enums/form-type.enum';

@Component({
  selector: 'app-details-page',
  imports: [DynamicSignalFormComponent],
  templateUrl: './details-page.component.html',
  styleUrl: './details-page.component.scss',
})
export class DetailsPageComponent extends SharedMethods implements OnInit {

  id: InputSignal<string> = input.required<string>();

  formData: WritableSignal<SignalForm> = signal({
    formType: FormType.REGULAR,
    title: '',
    cssClasses: '',
    formFields: []
  });
  formModel: WritableSignal<FlexibleObject> = signal({});

  isLoaded: WritableSignal<boolean> = signal(false);
  hasError: WritableSignal<boolean> = signal(false);

  private signalFormsService = inject(SignalFormsService);
  private toastr = inject(ToastrService);

  ngOnInit(): void {
    if(this.id()) {
      const id: number = parseInt(this.id());

      if(!isNaN(id)) {
        this.getData(id);
      } else {
        this.toastr.error('Invalid id');
      }
    } else {
      this.toastr.error('There is no id');
    }
  }

  private getData(id: number): void {
    this.signalFormsService.getById<SignalForm | null>(id).subscribe({
      next: (data: SignalForm | null) => {
        if(data) {
          this.formData.set(data);
        }
      },
      error: () => {
        this.hasError.set(true);
        this.toastr.error('Unable to fetch Form Data');
      },
      complete: () => {
        if(this.formData()) {
          this.prepareFormModel();
        }
      }
    });
  }

  private prepareFormModel(): void {
    const obj: FlexibleObject = this.convertFormFieldsToFormModel(this.formData().formFields);
    
    //Set initial values.
    this.formModel.set(obj);    
    this.isLoaded.set(true);
  }

  showData(data: FlexibleObject | undefined): void {
    if(data) {     
      console.log(data);
      this.toastr.success(`In the details page you can do whatever you want with the data:<br/><pre>${JSON.stringify(data).replaceAll(',', ',<br/>')}</pre>`, '', { enableHtml: true });
    } else {
      this.toastr.error('data is undefined');
    }
  }

}