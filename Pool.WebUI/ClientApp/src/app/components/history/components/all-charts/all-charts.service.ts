import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { DeviceTypeEnum } from '../../../../enums/device-type.enum';

@Injectable({
  providedIn: 'root',
})
export class AllChartsService {
  constructor() {}

  getCharts(): Observable<
    { data: number[]; labels: number[]; deviceType: DeviceTypeEnum }[]
  > {
    return of([
      {
        data: [40, 70, 75, 78, 80, 75, 72],
        labels: [],
        deviceType: DeviceTypeEnum.PH,
      },
      {
        data: [2, 2.4, 3.5, 4.2, 4.2, 4.3, 4.6],
        labels: [],
        deviceType: DeviceTypeEnum.TEMP,
      },
      {
        data: [675, 150, 200, 540, 670, 700, 690],
        labels: [],
        deviceType: DeviceTypeEnum.CL,
      },
      {
        data: [0.2, 0.3, 0.3, 0.35, 0.47, 0.4, 0.42],
        labels: [],
        deviceType: DeviceTypeEnum.RX,
      },
    ]);
  }
}
