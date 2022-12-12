import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

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

const offsetOutMain = '-8%';

const POSITION_0 = {
  top: '50%',
  bottom: 'unset',
  left: 'unset',
  right: offsetOutMain,
  transform: 'translate(0, -50%)',
};

const POSITION_1 = {
  top: 'unset',
  bottom: '8%',
  left: 'unset',
  right: '6%',
  transform: 'unset',
};

const POSITION_2 = {
  top: 'unset',
  bottom: offsetOutMain,
  left: '50%',
  right: 'unset',
  transform: 'translate(-50%, 0)',
};

const POSITION_3 = {
  top: offsetOutMain,
  bottom: 'unset',
  left: '50%',
  right: 'unset',
  transform: 'translate(-50%, 0)',
};

const POSITION_4 = {
  top: '8%',
  bottom: 'unset',
  left: 'unset',
  right: '6%',
  transform: 'translate(0, 0)',
};

@Injectable({
  providedIn: 'root',
})
export class NavigationService {

  buttons: TEST_INTERFACE[] = [
    {
      iconName: 'mdi-format-list-numbered',
      title: 'Показатели',
      isActive: true,
      position: POSITION_0,
    },
    {
      iconName: 'mdi-water',
      title: 'Водообмен',
      isActive: false,
      position: POSITION_1,
    },
    {
      iconName: 'mdi-ferris-wheel',
      title: 'Аттракционы',
      isActive: false,
      position: POSITION_2,
    },
    {
      iconName: 'mdi-history',
      title: 'История',
      isActive: false,
      position: POSITION_3,
    },
    {
      iconName: 'mdi-alert-outline',
      title: 'Журнал аварий',
      isActive: false,
      position: POSITION_4,
    },
  ];

  buttons$ = new BehaviorSubject<TEST_INTERFACE[]>(this.buttons)

  constructor() {}

  selectMenuItem(index: number): void {
    const before = this.buttons$.value.slice(0, index);
    const after = this.buttons$.value.slice(index + 1);

    console.log('currentButtons', this.buttons)
    console.log({index})
    console.log({before});
    console.log({after});

    console.log('index',this.buttons$.value[index]);

    const newArray = [this.buttons$.value[index], ...after, ...before];
    const superNewArray = [...newArray].map((item, index) => {
      item.position = this.getPosition(index);
      item.isActive = index === 0;

      return item;
    });

    console.log(superNewArray);
    this.buttons$.next(superNewArray);
  }

  getPosition(index: number): any {
    switch (index) {
      case 0: {
        return POSITION_0;
      }
      case 1: {
        return POSITION_1;
      }
      case 2: {
        return POSITION_2;
      }
      case 3: {
        return POSITION_3;
      }
      case 4: {
        return POSITION_4;
      }
    }
  }
}
