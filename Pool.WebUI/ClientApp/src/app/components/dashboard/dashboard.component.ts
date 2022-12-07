import { ChangeDetectionStrategy, Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DeviceCardComponent } from './components/device-card/device-card.component';
import { Device } from '../../interfaces/device.interface';
import { DeviceTypeEnum } from '../../enums/device-type.enum';

@Component({
  selector: 'app-dashboard',
  standalone: true,
  imports: [CommonModule, DeviceCardComponent],
  templateUrl: './dashboard.component.html',
  styleUrls: ['./dashboard.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DashboardComponent implements OnInit {
  devices: Device[] = [
    {
      poolAlias: 'pool1_alias',
      controllerCode: 'cocontroller1_alias',
      type: DeviceTypeEnum.PH,
      date: '2022-12-07T15:23:53.1155448+03:00',
      value: 7.2,
    },
    {
      poolAlias: 'pool1_alias',
      controllerCode: 'cocontroller1_alias',
      type: DeviceTypeEnum.CI,
      date: '2022-12-07T15:23:53.1155547+03:00',
      value: 0.3,
    },
    {
      poolAlias: 'pool1_alias',
      controllerCode: 'cocontroller1_alias',
      type: DeviceTypeEnum.TEMP,
      date: '2022-12-07T15:23:53.1155568+03:00',
      value: 27.9,
    },
  ];

  constructor() {}

  ngOnInit(): void {}
}
