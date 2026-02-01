import { Injectable } from '@angular/core';
import { ApiServiceAbstract } from '../generics/api.service-abstract.class';
import { HttpClient } from '@angular/common/http';
import { SignalForm } from '../../models/signal-forms/signal-form.interface';

@Injectable({
  providedIn: 'root',
})
export class SignalFormsService extends ApiServiceAbstract<SignalForm> {
  
  constructor(private http: HttpClient) {
    super({
      http: http,
      controllerName: 'SignalForm',
      getAllFunction: '',
      getAllByIdFunction: '',
      getAllByIdQueryParam: '',
      getByIdFunction: 'GetFormById',
      getByIdQueryParam: 'id',
      createFunction: 'Create',
      updateFunction: 'Update',
      deleteFunction: 'Delete',
      deleteQueryParam: 'id',
    });
  }

}
