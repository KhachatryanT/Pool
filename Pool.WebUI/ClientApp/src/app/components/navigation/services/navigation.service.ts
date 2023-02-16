import { Injectable } from '@angular/core';

export interface NavigateButton {
  iconName: string;
  title: string;
  isActive: boolean;
  route: string;
}

@Injectable({
  providedIn: 'root',
})
export class NavigationService {
  buttons: NavigateButton[] = [
    {
      iconName: 'mdi-cog',
      title: 'Настройки',
      isActive: true,
      route: '/settings',
    },
    {
      iconName: 'mdi-water',
      title: 'Водообмен',
      isActive: false,
      route: '',
    },
    {
      iconName: 'mdi-ferris-wheel',
      title: 'Аттракционы',
      isActive: false,
      route: '',
    },
    {
      iconName: 'mdi-history',
      title: 'История',
      isActive: false,
      route: '/history',
    },
    {
      iconName: 'mdi-alert-outline',
      title: 'Журнал аварий',
      isActive: false,
      route: '',
    },
  ];
}
