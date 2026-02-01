import { Component, inject, OnInit } from '@angular/core';
import { catchError, map, Observable } from 'rxjs';
import { AsyncPipe } from '@angular/common';
import { RouterModule } from '@angular/router';
import { AllMaterialsModule } from '../../all-materials.module';
import { FormType } from '../../models/enums/form-type.enum';
import { SignalFormsOverviewService } from '../../services/overview/signal-forms-overview.service';
import { FormOverview } from '../../models/overview/form-overview.interface';

@Component({
  selector: 'app-overview',
  imports: [AllMaterialsModule, AsyncPipe, RouterModule],
  templateUrl: './overview.component.html',
  styleUrl: './overview.component.scss',
})
export class OverviewComponent implements OnInit {

  allForms$?: Observable<FormOverview[]>;
  
  private SignalFormsOverviewService = inject(SignalFormsOverviewService);

  ngOnInit(): void {
    this.allForms$ = this.SignalFormsOverviewService.getAll<FormOverview>().pipe(
      map((data: FormOverview[]) => {
        if(data) {
          return data;
        }
        throw new Error('err');
      }),
      catchError((err) => {
        //Error here.
        return [];
      })
    );
  }

  getFormType(): typeof FormType {
    return FormType;
  }

}
