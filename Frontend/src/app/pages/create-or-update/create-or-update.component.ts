import { Component, inject, input, InputSignal, OnInit, signal, WritableSignal } from '@angular/core';
import { SignalFormsService } from '../../services/signalForms/signal-forms.service';
import { ToastrService } from 'ngx-toastr';
import { SignalForm } from '../../models/signal-forms/signal-form.interface';
import { AllMaterialsModule } from '../../all-materials.module';
import { inputTypeToShowFormType, ShowFormType } from '../../models/enums/show-form-type.enum';
import { SignalFormField } from '../../models/signal-forms/signal-form-field.interface';
import { CreateInputComponent } from './create-input/create-input.component';
import { CreateInputWithOptionsComponent } from './create-input-with-options/create-input-with-options.component';
import { CreateInputIntComponent } from './create-input-int/create-input-int.component';
import { CreateInputFloatComponent } from './create-input-float/create-input-float.component';
import { CreateTextareaComponent } from './create-textarea/create-textarea.component';
import { CreateInputBooleanComponent } from './create-input-boolean/create-input-boolean.component';
import { CreateFormArrayComponent } from './create-form-array/create-form-array.component';
import { form, required, validate, FormField } from '@angular/forms/signals';
import { Observable } from 'rxjs';
import { Router } from '@angular/router';
import { FormType } from '../../models/enums/form-type.enum';

@Component({
  selector: 'app-create-or-update',
  imports: [AllMaterialsModule, FormField, CreateInputComponent, CreateInputWithOptionsComponent, CreateInputIntComponent, CreateInputFloatComponent, CreateTextareaComponent, CreateInputBooleanComponent, CreateFormArrayComponent],
  templateUrl: './create-or-update.component.html',
  styleUrl: './create-or-update.component.scss',
})
export class CreateOrUpdateComponent implements OnInit {

  protected readonly id: InputSignal<string | undefined> = input<string | undefined>();

  protected isUpdateMode: WritableSignal<boolean> = signal(false);

  formModel: WritableSignal<SignalForm> = signal<SignalForm>({
    id: undefined,
    formType: FormType.REGULAR,
    title: '',
    cssClasses: 'column w-50 p-1',
    formFields: []
  });

  signalForm = form(this.formModel, (f) => {
    required(f.title, { message: 'Title is required' })
    validate(f.formFields, ({ value }) => {
      if(value().length === 0) {
        return { kind: 'no-form-fields', message: 'The Custom Form doesn\'t have any Form Fields' }
      }

      return undefined;
    })
  });

  inputTypeToShowFormType = inputTypeToShowFormType;
  formTypeOptions: FormType[] = [FormType.REGULAR, FormType.FORM_ARRAY];

  protected isLoaded: WritableSignal<boolean> = signal(false);
  protected showFieldForm: WritableSignal<ShowFormType> = signal(ShowFormType.NONE);
  protected selectedField: WritableSignal<SignalFormField | undefined> = signal(undefined);

  private signalFormsService = inject(SignalFormsService);
  private toastr = inject(ToastrService);
  private router = inject(Router);

  ngOnInit(): void {
    if(this.id() && this.id() !== 'undefined') {  
        const id: number = parseInt(this.id() ?? '0');  
          
        if(!isNaN(id)) {  
          this.isUpdateMode.set(true);  
          this.getData(id);  
        }  
      } else {  
        this.isLoaded.set(true);  
      }
  }

  submit($event: SubmitEvent): void {
    $event.preventDefault();

    if(this.signalForm().valid()) {
      const data = this.signalForm().value();  
      console.log('Form value:', data);

      const action$: Observable<void> = this.isUpdateMode() ?
        this.signalFormsService.update<SignalForm>(data) :
        this.signalFormsService.create<SignalForm>(data);

      action$.subscribe({
        next: () => {
          this.toastr.success('Form created successfully');
        },
        error: () => {
          this.toastr.error('Can\'t create form');
        },
        complete: () => {
          this.router.navigate(['/']);
        }
      });
    } else {
      const error: string = this.signalForm().errorSummary().map(item => item.message).filter(item => item !== undefined).join('<br />');
      this.toastr.error(error, '', { enableHtml: true});
    }
  }

  getEnum(): typeof ShowFormType {
    return ShowFormType;
  }

  editField(field: SignalFormField): void {
    this.showFieldForm.set(ShowFormType.NONE);
    this.selectedField.set(field);

    const showFormType: ShowFormType | undefined = this.inputTypeToShowFormType.get(field.inputType);

    if(showFormType) {
      setTimeout(() => {
        this.showFieldForm.set(showFormType);
      }, 100); 
    } else {
      this.toastr.error('Unknown Input Type');
    }    
  }

  showForm(e: ShowFormType): void {
    this.showFieldForm.set(ShowFormType.NONE);
    this.selectedField.set(undefined);

    setTimeout(() => {
      this.showFieldForm.set(e);
    }, 100);    
  }

  addOrUpdateFormField(formField: SignalFormField): void {
    if(formField.id) {
      // Update
      const formFields: SignalFormField[] = this.signalForm.formFields().value();
      const index: number = formFields.findIndex(item => item.id === formField.id);

      if(index > -1) {
        formFields[index] = formField;
      }
      this.signalForm.formFields().setControlValue(formFields);
    } else {      
      // Create
      const ids: number[] = this.signalForm.formFields().value().map(item => item.id).filter(item => item !== undefined);
      const nextId = ids.length === 0 ? 1 : Math.max(...ids) + 1;
      formField.id = nextId;
      const formFields: SignalFormField[] = this.signalForm.formFields().value();
      formFields.push(formField);
      this.signalForm.formFields().setControlValue(formFields);
    }

    this.showFieldForm.set(ShowFormType.NONE);
    this.selectedField.set(undefined);
  }

  deleteField(index: number): void {
    const fields: SignalFormField[] = this.formModel().formFields;

    if(fields.length > 0 && index < fields.length) {
      fields.splice(index, 1);
      this.formModel.set({...this.formModel(), formFields: fields});
    }
  }

  private getData(id: number): void {
    this.signalFormsService.getById<SignalForm | null>(id).subscribe({
      next: (data: SignalForm | null) => {
        if(data) {
          this.formModel.set(data);
        }
      },
      error: () => {
        this.toastr.error('Unable to fetch Form Data');
      },
      complete: () => {
        this.isUpdateMode.set(true);
        this.isLoaded.set(true);
      }
    });
  }

}