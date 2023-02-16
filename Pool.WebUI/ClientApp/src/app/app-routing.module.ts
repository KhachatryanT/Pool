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

const historyRoutes: Routes = [
  {
    path: '',
    children: [
      {
        path: '',
        pathMatch: 'full',
        redirectTo: 'main',
      },
      {
        path: 'main',
        loadComponent: () =>
          import('./components/history/history.component').then(
            (m) => m.HistoryComponent
          ),
      },
      {
        path: 'chart',
        loadComponent: () =>
          import('./components/history/components/chart-page/chart-page.component').then(
            (m) => m.ChartPageComponent
          ),
      },
      {
        path: 'event-log',
        loadComponent: () =>
          import('./components/history/components/event-log/event-log.component').then(
            (m) => m.EventLogComponent
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
  {
    path: 'settings',
    loadComponent: () =>
      import('./components/settings/settings.component').then(
        (m) => m.SettingsComponent
      ),
  },
  {
    path: 'history',
    loadChildren: () => historyRoutes,
  },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}
