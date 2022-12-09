import { Injectable } from '@angular/core';

// TODO
interface TEST_INTERFACE {
  iconName: string;
  title: string;
  isActive: boolean;
  position: {
    top: number | string;
    bottom: number | string;
    left: number | string;
    right: number | string;
    transform: string;
  };
}

const offsetOutMain = '-8%'

@Injectable({
  providedIn: 'root'
})
export class NavigationService {
  buttons: TEST_INTERFACE[] = [
    {
      iconName: 'mdi-format-list-numbered',
      title: 'Показатели',
      isActive: true,
      position: {
        top: '50%',
        bottom: 'unset',
        left: 'unset',
        right: offsetOutMain,
        transform: 'translate(0, -50%)',
      },
    },
    {
      iconName: 'mdi-water',
      title: 'Водообмен',
      isActive: false,
      position: {
        top: 'unset',
        bottom: '8%',
        left: 'unset',
        right: '6%',
        transform: 'unset',
      },
    },
    {
      iconName: 'mdi-ferris-wheel',
      title: 'Аттракционы',
      isActive: false,
      position: {
        top: 'unset',
        bottom: offsetOutMain,
        left: '50%',
        right: 'unset',
        transform: 'translate(-50%, 0)',
      },
    },
    {
      iconName: 'mdi-history',
      title: 'История',
      isActive: false,
      position: {
        top: offsetOutMain,
        bottom: 'unset',
        left: '50%',
        right: 'unset',
        transform: 'translate(-50%, 0)',
      },
    },
    {
      iconName: 'mdi-alert-outline',
      title: 'Журнал аварий',
      isActive: false,
      position: {
        top: '8%',
        bottom: 'unset',
        left: 'unset',
        right: '6%',
        transform: 'translate(0, 0)',
      },
    },
  ];

  constructor() { }

  selectMenuItem(index: number): void {
    const buttonsListLength = this.buttons.length;
    const offset = index === buttonsListLength ? 1 : index;

    for (let i = 0; i < offset; i++) {

    }


    console.log(offset)
  }
}
