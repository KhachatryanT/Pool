import {
  ChangeDetectionStrategy,
  Component,
  Input,
  OnInit,
} from '@angular/core';
import { CommonModule } from '@angular/common';
import { Device } from '../../../../interfaces/device.interface';
import { DeviceType, DeviceTypeEnum } from '../../../../enums/device-type.enum';

@Component({
  selector: 'app-device-card',
  standalone: true,
  imports: [CommonModule],
  templateUrl: './device-card.component.html',
  styleUrls: ['./device-card.component.scss'],
  changeDetection: ChangeDetectionStrategy.OnPush,
})
export class DeviceCardComponent implements OnInit {
  @Input() set device(value: Device) {
    this.name = DeviceType[value.type];
    this.value = value.value;
    this.isBlueValue = [DeviceTypeEnum.PH, DeviceTypeEnum.RX].includes(
      value.type
    );
  }

  name!: string;
  value!: number;
  isBlueValue!: boolean;

  constructor() {}

  ngOnInit(): void {}
}
