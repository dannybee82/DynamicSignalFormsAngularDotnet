import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { ApiServiceAbstract } from '../generics/api.service-abstract.class';
import { FormArrayOverview } from '../../models/overview/form-array-overview.interface';

@Injectable({
  providedIn: 'root',
})
export class FormArraysService extends ApiServiceAbstract<FormArrayOverview> {
  
  constructor(private http: HttpClient) {
    super({
      http: http,
      controllerName: 'SignalForm',
      getAllFunction: 'GetFormArrays',
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
