import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FormOverview } from '../../models/overview/form-overview.interface';
import { ApiServiceAbstract } from '../generics/api.service-abstract.class';

@Injectable({
  providedIn: 'root',
})
export class SignalFormsOverviewService  extends ApiServiceAbstract<FormOverview> {
  
  constructor(private http: HttpClient) {
    super({
      http: http,
      controllerName: 'SignalForm',
      getAllFunction: 'GetAllForms',
      getAllByIdFunction: '',
      getAllByIdQueryParam: '',
      getByIdFunction: '',
      getByIdQueryParam: '',
      createFunction: '',
      updateFunction: '',
      deleteFunction: '',
      deleteQueryParam: '',
    });
  }

}