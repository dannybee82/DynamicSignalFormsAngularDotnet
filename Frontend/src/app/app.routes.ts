import { Routes } from '@angular/router';
import { MenuComponent } from './components/menu/menu.component';
import { OverviewComponent } from './pages/overview/overview.component';
import { DetailsPageComponent } from './pages/details-page/details-page.component';
import { CreateOrUpdateComponent } from './pages/create-or-update/create-or-update.component';

export const routes: Routes = [
    {
        path: '',
        component: MenuComponent,
        children: [
            {
                path: '',
                component: OverviewComponent
            },
            {
                path: 'signal-form/:id',
                component: DetailsPageComponent
            },
            {
                path: 'create-or-update/:id',
                component: CreateOrUpdateComponent
            }
        ]
    }
];