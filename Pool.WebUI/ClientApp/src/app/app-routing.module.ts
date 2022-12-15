import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const dashboardRoutes: Routes = [
  {
    path: '',
    loadComponent: () =>
      import('./components/dashboard/dashboard.component').then(
        (m) => m.DashboardComponent
      ),
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'devices',
      },
      {
        path: 'devices',
        loadComponent: () =>
          import('./components/devices/devices.component').then(
            (m) => m.DevicesComponent
          ),
      },
    ],
  },
];

const routes: Routes = [
  {
    path: '',
    pathMatch: 'full',
    redirectTo: 'dashboard',
  },
  {
    path: 'dashboard',
    loadChildren: () => dashboardRoutes,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
